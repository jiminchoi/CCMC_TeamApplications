using Foundation;
using System;
using System.IO;
using System.Drawing;
using UIKit;

using SQLite;
using Syncfusion.SfChart.iOS;
using Xamarin.Forms;

namespace studentsInfoSystemForCCMC
{

    public partial class AttendancesController : UIViewController
    {
        SFChart chartObj;
		public int[] rgbLabel = { 67, 116, 217 };

		public AttendancesController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //チャートの呼び出し、設定
            chartObj = new SFChart();
            //Define the title for the Chart.
            chartObj.Title.Text = new NSString(UserName + "様の出席状況");
            chartObj.Title.TextColor = UIColor.FromRGB(3, 0, 102);
            chartObj.Title.TextAlignment = UITextAlignment.Center;
            //Adding legend to the Chart.
            chartObj.Legend.Visible = true;

            //Adding Primary Axis for the Chart.
            SFCategoryAxis primaryAxis = new SFCategoryAxis();

            primaryAxis.Title.Text = new NSString("学期");
            primaryAxis.Title.Color = UIColor.FromRGB(3, 0, 102);

            chartObj.PrimaryAxis = primaryAxis;

            //Adding Secondary Axis for the Chart.
            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Title.Text = new NSString("出席率");
            secondaryAxis.Title.Color = UIColor.FromRGB(3, 0, 102);

            chartObj.SecondaryAxis = secondaryAxis;

            //Defining the data source for the Chart.
            ChartDataModel dataModel = new ChartDataModel();
            chartObj.DataSource = dataModel as SFChartDataSource;

            attendancesGraph.Add(chartObj);

			/*↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ここまでがSFChartのコード↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑*/


			/*↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ここからラベルのコード↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓*/

			int xPositionLabel = 0;
            int xPositionLabelExpected = 195;
			int yPosition= 550;
            string currentAttendanceData;
            string expectingAttendanceData;

            currentAttendanceData = "現在出席率：" + CurrentData(3).ToString("##.##") + "%";
            expectingAttendanceData = "予想出席率：" + ExpectingData(3).ToString("##.##") + "%";


			var currentLabel = new CurrentAttendanceLabel(xPositionLabel, yPosition, currentAttendanceData
                                                      , rgbLabel[0], rgbLabel[1], rgbLabel[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var expectingLabel = new ExpectingAttendanceLabel(xPositionLabelExpected, yPosition, 
                                                              expectingAttendanceData, rgbLabel[0], rgbLabel[1], rgbLabel[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

            Add(currentLabel);
            Add(expectingLabel);
        }

		sealed class CurrentAttendanceLabel : UILabel
		{
			public CurrentAttendanceLabel(int x, int y,
								 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 180, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
				TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
			}
		}

		sealed class ExpectingAttendanceLabel : UILabel
		{
			public ExpectingAttendanceLabel(int x, int y,
								 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 180, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
				TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
			}
		}
	}

    //TabBarTimeTableからのデータ取得
    public partial class AttendancesController 
    {
        public AttendancesController(){
            
        }
		public string UserIdentify { get; set; }
		public string UserName { get; set; }
		public string UserSex { get; set; }
		public string UserBirthday { get; set; }
		public string UserNationality { get; set; }
		
	}

    //実際の出席の計算
    public partial class AttendancesController
    {
		public double[] lessons = new double[4];
        public double[] attendances;
        public double[] attendancesPercentage;

        //現出席率の算出
		public double CurrentData(int monthIndex)
		{
            //実際のデータ
			attendances = new double[] { 23, 45, 65, 65 };
			attendancesPercentage = new double[4];// attendancesPercentage Member = { 0, 0, 0, 0 };

			// lessons Member = { 24, 48, 72, 96 };
			for (int i = 0; i < lessons.Length; i++)
			{
				if (i > 0)
				{
					lessons[i] = lessons[i - 1] + 24;
				}
				else
				{
					lessons[i] = 24;
				}
			}

			for (int i = 0; i < attendances.Length; i++)
			{
				attendancesPercentage[i] = attendances[i] / lessons[i] * 100;
			}

            for (int i = 0; i < attendances.Length; i++){
                if(i > 0){
                    if((int)attendances[i] == (int)attendances[i-1]){
                        attendancesPercentage[i] = attendancesPercentage[i-1];
					}
                }
            }
			return attendancesPercentage[monthIndex];
		}

        //予想出席率を算出
        public double ExpectingData(int monthIndex)
		{
			double[] monthAttendances = new double[4];

            //実際のデータ
			attendances = new double[] { 23, 45, 65, 65 };
			attendancesPercentage = new double[4];// {0, 0, 0, 0}가 들어있는 상태

			for (int i = 0; i < lessons.Length; i++)
			{
				if (i > 0)
				{
					lessons[i] = lessons[i - 1] + 24;
				}
				else
				{
					lessons[i] = 24;
				}
			}

			for (int i = 0; i < attendances.Length; i++)
			{
				attendancesPercentage[i] = attendances[i] / lessons[i] * 100;
			}

			for (int i = 0; i < monthAttendances.Length; i++)
			{
				if (i > 0)
				{
					monthAttendances[i] = attendances[i] - attendances[i - 1];
				}
				else if (i == 0)
				{
					monthAttendances[i] = attendances[i];
				}
			}

			double average = 0.0;
			double total = 0.0;
			for (int i = 0; i < attendances.Length; i++)
			{
				total = 0.0;
				if (i > 0)
				{
					if ((int)attendances[i] == (int)attendances[i - 1])
					{
						for (int j = 0; j < i; j++)
						{
							total += monthAttendances[j];
						}
						average = total / i;
						monthAttendances[i] = (int)average;
					}
				}
			}

			total = 0.0;
			for (int i = 0; i < monthAttendances.Length; i++)
			{
				total += monthAttendances[i];
				if (i > 0)
				{
                    if ((int)attendances[i] == (int)attendances[i - 1])
					{
						/* Console.WriteLine( i + " = " + attendancesPercentage[i].ToString("##.##") + ", total : "
                                    + total + ", lessons : " + lessons[i]);*/
						attendancesPercentage[i] = total / lessons[i] * 100;
					}
				}
			}

			return attendancesPercentage[monthIndex];
		}
    }

    public class ChartDataModel : SFChartDataSource
    {
		
		NSMutableArray currentPercentOfAttendances;
        NSMutableArray expectingPercentOfAttendances;
        AttendancesController ac = new AttendancesController();

        //ここにデーターの値を代入すること！
        public ChartDataModel()
        {
            currentPercentOfAttendances = new NSMutableArray();
            expectingPercentOfAttendances = new NSMutableArray();

            int month = 3;
            for (int i = 0; i < 4; i++)
            {
                month++;
                AddDataPointsForChart(month.ToString() + "月", ac.CurrentData(i), ac.ExpectingData(i));
            }


		}

        void AddDataPointsForChart(String month, Double current, Double expecting)
        {
            currentPercentOfAttendances.Add(new SFChartDataPoint(NSObject.FromObject(month), NSObject.FromObject(current)));
            expectingPercentOfAttendances.Add(new SFChartDataPoint(NSObject.FromObject(month), NSObject.FromObject(expecting)));
        }

        [Export("numberOfSeriesInChart:")]
        public override nint NumberOfSeriesInChart(SFChart chart)
        {
            return 2;
            //returns no of series required for the chart.
        }

        [Export("chart:seriesAtIndex:")]
        public override SFSeries GetSeries(SFChart chart, nint index)
        {
            //returns the series for the chart.
            if(index == 1){
				SFLineSeries series = new SFLineSeries();
                series.Label = new NSString("現在出席率");
				series.Color = UIColor.FromRGB(10, 5, 130);
				series.DataMarker.ShowLabel = true;

				return series;

			}
            else
			{
				SFLineSeries series = new SFLineSeries();
				series.Label = new NSString("予想出席率");
                series.DataMarker.ShowLabel = true;

				SFNumericalAxis axis = new SFNumericalAxis();
				axis.OpposedPosition = true;
				axis.ShowMajorGridLines = false;
				series.YAxis = axis;

				return series;
			}
            //series.DataMarker.ShowMarker = true;
        }

        [Export("chart:dataPointAtIndex:forSeriesAtIndex:")]
        public override SFChartDataPoint GetDataPoint(SFChart chart, nint index, nint seriesIndex)
        {
			//returns the datapoint for each series.
			if (seriesIndex == 1)
			{
                return currentPercentOfAttendances.GetItem<SFChartDataPoint>((nuint)index);			
            }
            else
			{
                return expectingPercentOfAttendances.GetItem<SFChartDataPoint>((nuint)index);
			}

        }

        [Export("chart:numberOfDataPointsForSeriesAtIndex:")]
        public override nint GetNumberOfDataPoints(SFChart chart, nint index)
        {
            return 4;
            //No of datapoints needed for each series.
        }

        public override void PrepareForInterfaceBuilder()
        {
            base.PrepareForInterfaceBuilder();

        }
    }

}