using Foundation;
using System;
using System.IO;
using System.Collections;
using System.Drawing;

using SQLite;
using UIKit;

namespace studentsInfoSystemForCCMC
{
    public partial class TabBarTimeTable : UIViewController
    {
		ArrayList dayApiList = new ArrayList();
        DateTime dt = DateTime.Now;

		private string path = "";
		string[] day = { "日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日" };
		string[] dayOfWeekApi = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

		int[] rgbOn = { 67, 116, 217 };
		int[] rgbOff = { 103, 153, 255 };


        public TabBarTimeTable (IntPtr handle) : base (handle)
        {
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
        }
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//string toDay = dt.DayOfWeek.ToString();
			DayOfWeek week = dt.DayOfWeek;

			int toDay = (int)dt.DayOfWeek;
			int tommorowOne = (int)dt.DayOfWeek + 1;
			int tommorowTwo = (int)dt.DayOfWeek + 2;
			int tommorowThree = (int)dt.DayOfWeek + 3;
			int tommorowFour = (int)dt.DayOfWeek + 4;
            int dayPositionX = 55;
            int dayPositionY = 250;

			for (int i = 0; i < dayOfWeekApi.Length; i++)
			{
				dayApiList.Add(dayOfWeekApi[i]);
			}

			var w = View.Bounds.Width;
			var h = View.Bounds.Height;

			const int pageSize = 5; //ページ数
									//スクロールビューの生成（ページ分のサイズで初期化する）
			var scrollView = new UIScrollView(View.Bounds);
			//スクロールビューの背景色
            scrollView.BackgroundColor = UIColor.FromRGB(5, 5, 5);
			//ページ単位でスクロールさせるかどうか
			scrollView.PagingEnabled = true;
			//スクロールの有効無効
			scrollView.UserInteractionEnabled = true;
			// スクロールの範囲を設定(現在のページを基準に、縦１倍、横５倍)
			scrollView.ContentSize = new SizeF((int)w * pageSize, (int)h);

			// スクロールビューの各ページの中央にページ数を表示する
			int count = 0;
			string[] dayJp = new string[5];
			foreach (string dayApi in dayApiList)
			{
				if (count == toDay)
				{
					int i = 0;
					if (tommorowOne > 6)
					{

						dayJp[0] = day[toDay];
						dayJp[1] = day[i++];
						dayJp[2] = day[i++];
						dayJp[3] = day[i++];
						dayJp[4] = day[i];
					}
					else if (tommorowTwo > 6)
					{
						dayJp[0] = day[toDay];
						dayJp[1] = day[tommorowOne];
						dayJp[2] = day[i++];
						dayJp[3] = day[i++];
						dayJp[4] = day[i];
					}
					else if (tommorowThree > 6)
					{
						dayJp[0] = day[toDay];
						dayJp[1] = day[tommorowOne];
						dayJp[2] = day[tommorowTwo];
						dayJp[3] = day[i++];
						dayJp[4] = day[i];
					}
					else if (tommorowFour > 6)
					{
						dayJp[0] = day[toDay];
						dayJp[1] = day[tommorowOne];
						dayJp[2] = day[tommorowTwo];
						dayJp[3] = day[tommorowThree];
						dayJp[4] = day[i];
					}
					else
					{
						dayJp[0] = day[toDay];
						dayJp[1] = day[tommorowOne];
						dayJp[2] = day[tommorowTwo];
						dayJp[3] = day[tommorowThree];
						dayJp[4] = day[tommorowFour];
					}


                    //本日
                    var todayLabel = new todayLabel(0, 0, dayJp[0], rgbOff[0], rgbOff[1], rgbOff[2])
					{
						//ラベルのサイズに合わせてフォントサイズを調整する
						AdjustsFontSizeToFitWidth = true, 
                        //ページの相対的な位置"X", ページ(現在のページ), ページの相対的な位置"Y"
                        Center = new PointF(dayPositionX + (int)w * 0, dayPositionY), 
						Lines = 0,
						MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
					};

                    var lessonsLabelFirst = new lessonsLabelTitle(0, 0, rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true, 
                        Center = new PointF((dayPositionX + 95) + (int)w * 0, dayPositionY - 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

                    var lessonLabelCountFrist = new lessonsLabelCount(0, 0, "No data", rgbOff[0], rgbOff[1], rgbOff[2])
					{
						//ラベルのサイズに合わせてフォントサイズを調整する
						AdjustsFontSizeToFitWidth = true,
						//ページの相対的な位置"X", ページ(現在のページ), ページの相対的な位置"Y"
                        Center = new PointF((dayPositionX + 95) + (int)w * 0, dayPositionY + 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
					};


                    //明日
					var tommorowOneLabel = new todayLabel(0, 0, dayJp[1], rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true, 
                        Center = new PointF(dayPositionX + (int)w * 1, dayPositionY), 
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

					var lessonsLabelSecond = new lessonsLabelTitle(0, 0, rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true,
						Center = new PointF(dayPositionX + 95 + (int)w * 1, dayPositionY - 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};



					var tommorowTwoLabel = new todayLabel(0, 0, dayJp[2], rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true, 
                        Center = new PointF(dayPositionX + (int)w * 2, dayPositionY), 
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

					var lessonsLabelThird = new lessonsLabelTitle(0, 0, rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true,
						Center = new PointF(dayPositionX + 95 + (int)w * 2, dayPositionY - 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};



					var tommorowThreeLabel = new todayLabel(0, 0, dayJp[3], rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true,
                        Center = new PointF(dayPositionX + (int)w * 3, dayPositionY),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

					var lessonsLabelForth = new lessonsLabelTitle(0, 0, rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true,
						Center = new PointF(dayPositionX + 95 + (int)w * 3, dayPositionY - 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};



					var tommorowFourLabel = new todayLabel(0, 0, dayJp[4], rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true, 
                        Center = new PointF(dayPositionX + (int)w * 4, dayPositionY), 
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

					var lessonsLabelFifth = new lessonsLabelTitle(0, 0, rgbOff[0], rgbOff[1], rgbOff[2])
					{
						AdjustsFontSizeToFitWidth = true,
						Center = new PointF(dayPositionX + 95 + (int)w * 4, dayPositionY - 30),
						Lines = 0,
						MinimumScaleFactor = 0.5f
					};

                    userNameLabel.Text =  UserName + "様";

                    // 1Page
					scrollView.Add(todayLabel); //スクロールビューに追加する
                    scrollView.Add(lessonsLabelFirst);
                    scrollView.Add(lessonLabelCountFrist);

                    // 2Page
					scrollView.Add(tommorowOneLabel);
                    scrollView.Add((lessonsLabelSecond));

                    // 3Page
					scrollView.Add(tommorowTwoLabel);
                    scrollView.Add(lessonsLabelThird);

                    // 4Page
					scrollView.Add(tommorowThreeLabel);
                    scrollView.Add((lessonsLabelForth));

                    // 5Page
					scrollView.Add(tommorowFourLabel);
                    scrollView.Add(lessonsLabelFifth);
				}
				count++;
			}
			//スクロールビューを追加する
			View.Add(scrollView);

            //checkAttendances.TouchUpInside += CheckAttendances_TouchUpInside;
            viewTimetableBtn.TouchUpInside += ViewTimetableBtn_TouchUpInside;
		}


        //曜日を表すラーベル
		sealed class todayLabel : UILabel
		{
			public todayLabel(int x, int y,
								 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 60, 118);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
			}
		}

        //当日の単位数タイトルを表示するラーベル
		sealed class lessonsLabelTitle : UILabel
		{
			public lessonsLabelTitle(int x, int y,
								 int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 120, 59);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = "単位数";//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
			}
		}

        //当日お単位数を表すラーベル
		sealed class lessonsLabelCount : UILabel
		{
			public lessonsLabelCount(int x, int y, string z,
								 int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 120, 59);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
			}
		}


        void ViewTimetableBtn_TouchUpInside(object sender, EventArgs e)
        {
            PerformSegue("segueViewingTimetable", this);
        }

        //void CheckAttendances_TouchUpInside(object sender, EventArgs e)
        //{
        //    PerformSegue("segueAttendances", this);
        //}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

			if (String.Equals(segue.Identifier, "segueAttendances"))
			{
                var vc = segue.DestinationViewController as AttendancesController;
                vc.UserName = UserName;
                vc.UserSex = UserSex;
                vc.UserIdentify = UserIdentify;
                //vc.UserBirthday = UserBirthday;
                vc.UserNationality = UserNationality;
			}
        }
    }




    //DBデータの引き続き... 
    public partial class TabBarTimeTable
    {
		public string UserIdentify { get; set; }
		public string UserName { get; set; }
		public string UserSex { get; set; }
		public string UserBrithday { get; set; }
		public string UserNationality { get; set; }
    }
}