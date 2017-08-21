using Foundation;
using System;
using System.IO;
using System.Collections;
using System.Drawing;

using SQLite;
using UIKit;


namespace studentsInfoSystemForCCMC
{
	public partial class TimeTableViewController : UIViewController
	{
		//色変更プログラムの配列
		public string[] dayOfWeekApi = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
		public string[] dayOfWeek = { "月", "火", "水", "木", "金" };
        private string path = "";

		//デザインの色
		public int[] rgbColor = { 67, 116, 217 };

		//時間割表の構成
		//配列の説明["授業日数" = 5, "授業数" = 3, "該当授業の授業名・担当先生・教室名" = 3]
		string[,,] classOfDay = new string[5, 3, 3]{
			{ { "WordPress/DreamWeaber", "初野", "WebLab" }, { "日本語３(留学生のみ)", "小堺", "202" }, { "キャリア教育3", "小松", "207" } },
			{ { "", "", "" }, { "", "", "" }, { "", "", "" } },
			{ { "", "", "" }, { "", "", "" }, { "", "", "" } },
			{ { "", "", "" }, { "", "", "" }, { "", "", "" } },
			{ { "", "", "" }, { "", "", "" }, { "", "", "" } } };

		public TimeTableViewController(IntPtr handle) : base(handle)
		{
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//時間の呼び出し
			DateTime dt = DateTime.Now;
			ArrayList dayApiList = new ArrayList();
			//曜日の変数化(string)
			string toDay = dt.DayOfWeek.ToString();

			int xPositionWeekOfDay = 10;
			int xPositionFirst = 105;
			int xPostionSec = 195;
			int xPositionThird = 285;

			int yPositionMon = 166;
			int yPositionTues = 232;
			int yPositionWednes = 298;
			int yPositionThurs = 364;
			int yPositionFri = 430;

			var mondayOn = new mondayOnClass(xPositionWeekOfDay, yPositionMon, dayOfWeek[0]
								, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondayOff = new mondayOffClass(xPositionWeekOfDay, yPositionMon, dayOfWeek[0]
											  , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondayfirstOn = new mondayFirstTimeOn(xPositionFirst, yPositionMon,
													  classOfDay[0, 0, 0] + "\n" + classOfDay[0, 0, 1] + "\n" + classOfDay[0, 0, 2]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondayfirstOff = new mondayFirstTimeOff(xPositionFirst, yPositionMon,
														classOfDay[0, 0, 0] + "\n" + classOfDay[0, 0, 1] + "\n" + classOfDay[0, 0, 2]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値 
			};

			var mondaysecOn = new mondaySecTimeOn(xPostionSec, yPositionMon,
												  classOfDay[0, 1, 0] + "\n" + classOfDay[0, 1, 1] + "\n" + classOfDay[0, 1, 2]
												 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondaysecOff = new mondaySecTimeOff(xPostionSec, yPositionMon,
													classOfDay[0, 1, 0] + "\n" + classOfDay[0, 1, 1] + "\n" + classOfDay[0, 1, 2]
												   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondaythirdOn = new mondayThirdTimeOn(xPositionThird, yPositionMon,
													  classOfDay[0, 2, 0] + "\n" + classOfDay[0, 2, 1] + "\n" + classOfDay[0, 2, 2]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var mondaythirdOff = new mondayThirdTimeOff(xPositionThird, yPositionMon,
														classOfDay[0, 2, 0] + "\n" + classOfDay[0, 2, 1] + "\n" + classOfDay[0, 2, 2]
													   , rgbColor[0], rgbColor[1], rgbColor[2])

			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値 
			};

			//tuesday
			var tuesdayOn = new tuesdayOnClass(xPositionWeekOfDay, yPositionTues, dayOfWeek[1]
											  , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var tuesdayOff = new tuesdayOffClass(xPositionWeekOfDay, yPositionTues, dayOfWeek[1]
												, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f
			};

			var tuesdayfirstOn = new tuesdayFirstTimeOn(xPositionFirst, yPositionTues, classOfDay[1, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f
			};

			var tuesdayfirstOff = new tuesdayFirstTimeOff(xPositionFirst, yPositionTues, classOfDay[1, 0, 0]
														 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var tuesdaysecOn = new tuesdaySecTimeOn(xPostionSec, yPositionTues, classOfDay[1, 0, 0]
												   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var tuesdaysecOff = new tuesdaySecTimeOff(xPostionSec, yPositionTues, classOfDay[1, 0, 0]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var tuesdaythirdOn = new tuesdayThirdTimeOn(xPositionThird, yPositionTues, classOfDay[1, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var tuesdaythirdOff = new tuesdayThirdTimeOff(xPositionThird, yPositionTues, classOfDay[1, 0, 0]
														 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};


			//wednesday
			var wednesdayOn = new wednesdayOnClass(xPositionWeekOfDay, yPositionWednes, dayOfWeek[2]
												  , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdayOff = new wednesdayOffClass(xPositionWeekOfDay, yPositionWednes, dayOfWeek[2]
													, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdayfirstOn = new wednesdayFirstTimeOn(xPositionFirst, yPositionWednes, classOfDay[2, 0, 0]
														   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

            var wednesdayfirstOff = new wednesdayFirstTimeOff(xPositionFirst, yPositionWednes, classOfDay[2, 0, 0]
															, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdaysecOn = new wednesdaySecTimeOn(xPostionSec, yPositionWednes, classOfDay[2, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdaysecOff = new wednesdaySecTimeOff(xPostionSec, yPositionWednes, classOfDay[2, 0, 0]
														 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdaythirdOn = new wednesdayThirdTimeOn(xPositionThird, yPositionWednes, classOfDay[2, 0, 0]
														   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var wednesdaythirdOff = new wednesdayThirdTimeOff(xPositionThird, yPositionWednes, classOfDay[2, 0, 0]
															 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};


			//thursday
			var thursdayOn = new thursdayOnClass(xPositionWeekOfDay, yPositionThurs, dayOfWeek[3]
												, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdayOff = new thursdayOffClass(xPositionWeekOfDay, yPositionThurs, dayOfWeek[3]
												  , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdayfirstOn = new thursdayFirstTimeOn(xPositionFirst, yPositionThurs, classOfDay[3, 0, 0]
														 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdayfirstOff = new thursdayFirstTimeOff(xPositionFirst, yPositionThurs, classOfDay[3, 0, 0]
														   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdaysecOn = new thursdaySecTimeOn(xPostionSec, yPositionThurs, classOfDay[3, 0, 0]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdaysecOff = new thursdaySecTimeOff(xPostionSec, yPositionThurs, classOfDay[3, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdaythirdOn = new thursdayThirdTimeOn(xPositionThird, yPositionThurs, classOfDay[3, 0, 0]
														 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var thursdaythirdOff = new thursdayThirdTimeOff(xPositionThird, yPositionThurs, classOfDay[3, 0, 0]
														   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};


			//friday
			var fridayOn = new fridayOnClass(xPositionWeekOfDay, yPositionFri, dayOfWeek[4]
											, rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridayOff = new fridayOffClass(xPositionWeekOfDay, yPositionFri, dayOfWeek[4]
											   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridayfirstOn = new fridayFirstTimeOn(xPositionFirst, yPositionFri, classOfDay[4, 0, 0]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridayfirstOff = new fridayFirstTimeOff(xPositionFirst, yPositionFri, classOfDay[4, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridaysecOn = new fridaySecTimeOn(xPostionSec, yPositionFri, classOfDay[4, 0, 0]
												 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridaysecOff = new fridaySecTimeOff(xPostionSec, yPositionFri, classOfDay[4, 0, 0]
												   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridaythirdOn = new fridayThirdTimeOn(xPositionThird, yPositionFri, classOfDay[4, 0, 0]
													 , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

			var fridaythirdOff = new fridayFirstTimeOff(xPositionThird, yPositionFri, classOfDay[4, 0, 0]
													   , rgbColor[0], rgbColor[1], rgbColor[2])
			{
				AdjustsFontSizeToFitWidth = true, //ラベルのサイズにフォントサイズを調整する
				MinimumScaleFactor = 0.5f//調整する場合の、最小限界値
			};

            //ArrayList dayList = new ArrayList();
            //初期化
			dayList.Text = "授業日";
			firstTime.Text = "1時間目\n09:10\n~10:40";
			secondTime.Text = "2時間目\n10:50\n~12:20";
			thirdTime.Text = "3時間目\n13:10\n~14:40";
            timeTableNaviItem.Title = UserName+"さんの時間割";

			//サイズ自動調整
			//mondayOn.SizeToFit();
			//______________________
			//Labelの実行
			if (toDay.Equals(dayOfWeekApi[0]))
			{
				Add(mondayOn);
				Add(mondayfirstOn);
				Add(mondaysecOn);
				Add(mondaythirdOn);
			}

			else
			{
				Add(mondayOff);
				Add(mondayfirstOff);
				Add(mondaysecOff);
				Add(mondaythirdOff);
			}

			if (toDay.Equals(dayOfWeekApi[1]))
			{
				Add(tuesdayOn);
				Add(tuesdayfirstOn);
				Add(tuesdaysecOn);
				Add(tuesdaythirdOn);
			}
			else
			{
				Add(tuesdayOff);
				Add(tuesdayfirstOff);
				Add(tuesdaysecOff);
				Add(tuesdaythirdOff);
			}

			if (toDay.Equals(dayOfWeekApi[2]))
			{
				Add(wednesdayOn);
				Add(wednesdayfirstOn);
				Add(wednesdaysecOn);
				Add(wednesdaythirdOn);
			}
			else
			{
				Add(wednesdayOff);
				Add(wednesdayfirstOff);
				Add(wednesdaysecOff);
				Add(wednesdaythirdOff);
			}

			if (toDay.Equals(dayOfWeekApi[3]))
			{
				Add(thursdayOn);
				Add(thursdayfirstOn);
				Add(thursdaysecOn);
				Add(thursdaythirdOn);
			}
			else
			{
				Add(thursdayOff);
				Add(thursdayfirstOff);
				Add(thursdaysecOff);
				Add(thursdaythirdOff);
			}

			if (toDay.Equals(dayOfWeekApi[4]))
			{
				Add(fridayOn);
				Add(fridayfirstOn);
				Add(fridaysecOn);
				Add(fridaythirdOn);
			}
			else
			{
				Add(fridayOff);
				Add(fridayfirstOff);
				Add(fridaysecOff);
				Add(fridaythirdOff);
			}



			//dayOfWeekApiのArrayList化
			for (int i = 0; i < dayOfWeekApi.Length; i++)
			{
				dayApiList.Add(dayOfWeekApi[i]);
			}

			int count = 0;
			foreach (string dayApi in dayApiList)
			{
				if (toDay.Equals(dayApi))
				{
					todaysTime.Text = dt.Year + "年" + dt.Month + "月"
						+ dt.Day + "日" + dayOfWeek[count] + "曜日";
					break;
				}
				else
				{
					todaysTime.Text = "今日は授業がありません。";
				}
				count++;
			}

            checkAttendances.TouchUpInside += CheckAttendances_TouchUpInside;
		}

        void CheckAttendances_TouchUpInside(object sender, EventArgs e)
        {
            PerformSegue("segueAttendances", this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

			if (String.Equals(segue.Identifier, "segueAttendances"))
			{
				var vc = segue.DestinationViewController as AttendancesController;
				vc.UserName = UserName;
				vc.UserSex = UserSex;
				vc.UserIdentify = UserIdentify;
				vc.UserBirthday = UserBirthday;
				vc.UserNationality = UserNationality;
			}
        }
        //Labelの設定・Designコード

        //月曜日の時間割Design
        //引数の構成
        // - int x, int y(対象のposition)
        // - string z (時間割の内容)
        // - int r, int g, int b (rgbの値)
        sealed class mondayOnClass : UILabel
		{
			public mondayOnClass(int x, int y,
								 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class mondayOffClass : UILabel
		{
			public mondayOffClass(int x, int y,
								  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class mondayFirstTimeOn : UILabel
		{
			public mondayFirstTimeOn(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class mondayFirstTimeOff : UILabel
		{
			public mondayFirstTimeOff(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class mondaySecTimeOn : UILabel
		{
			public mondaySecTimeOn(int x, int y,
								   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class mondaySecTimeOff : UILabel
		{
			public mondaySecTimeOff(int x, int y,
									string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2; 
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class mondayThirdTimeOn : UILabel
		{
			public mondayThirdTimeOn(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class mondayThirdTimeOff : UILabel
		{
			public mondayThirdTimeOff(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2; 
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}



		//火曜日の時間割Desgin
		sealed class tuesdayOnClass : UILabel
		{
			public tuesdayOnClass(int x, int y,
								  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class tuesdayOffClass : UILabel
		{
			public tuesdayOffClass(int x, int y,
								   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class tuesdayFirstTimeOn : UILabel
		{
			public tuesdayFirstTimeOn(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class tuesdayFirstTimeOff : UILabel
		{
			public tuesdayFirstTimeOff(int x, int y,
									   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class tuesdaySecTimeOn : UILabel
		{
			public tuesdaySecTimeOn(int x, int y,
									string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class tuesdaySecTimeOff : UILabel
		{
			public tuesdaySecTimeOff(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class tuesdayThirdTimeOn : UILabel
		{
			public tuesdayThirdTimeOn(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class tuesdayThirdTimeOff : UILabel
		{
			public tuesdayThirdTimeOff(int x, int y,
									   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		//水曜日の時間割Design
		sealed class wednesdayOnClass : UILabel
		{
			public wednesdayOnClass(int x, int y,
									string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！


			}
		}

		sealed class wednesdayOffClass : UILabel
		{
			public wednesdayOffClass(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class wednesdayFirstTimeOn : UILabel
		{
			public wednesdayFirstTimeOn(int x, int y,
										string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class wednesdayFirstTimeOff : UILabel
		{
			public wednesdayFirstTimeOff(int x, int y,
										 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class wednesdaySecTimeOn : UILabel
		{
			public wednesdaySecTimeOn(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class wednesdaySecTimeOff : UILabel
		{
			public wednesdaySecTimeOff(int x, int y,
									   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class wednesdayThirdTimeOn : UILabel
		{
			public wednesdayThirdTimeOn(int x, int y,
										string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class wednesdayThirdTimeOff : UILabel
		{
			public wednesdayThirdTimeOff(int x, int y,
										 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		//木曜日の時間割
		sealed class thursdayOnClass : UILabel
		{
			public thursdayOnClass(int x, int y,
								   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class thursdayOffClass : UILabel
		{
			public thursdayOffClass(int x, int y,
									string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class thursdayFirstTimeOn : UILabel
		{
			public thursdayFirstTimeOn(int x, int y,
									   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class thursdayFirstTimeOff : UILabel
		{
			public thursdayFirstTimeOff(int x, int y,
										string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class thursdaySecTimeOn : UILabel
		{
			public thursdaySecTimeOn(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class thursdaySecTimeOff : UILabel
		{
			public thursdaySecTimeOff(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class thursdayThirdTimeOn : UILabel
		{
			public thursdayThirdTimeOn(int x, int y,
									   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class thursdayThirdTimeOff : UILabel
		{
			public thursdayThirdTimeOff(int x, int y,
										string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}


		//金曜日の時間割
		sealed class fridayOnClass : UILabel
		{
			public fridayOnClass(int x, int y,
								 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class fridayOffClass : UILabel
		{
			public fridayOffClass(int x, int y,
								  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！

			}
		}

		sealed class fridayFirstTimeOn : UILabel
		{
			public fridayFirstTimeOn(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class fridayFirstTimeOff : UILabel
		{
			public fridayFirstTimeOff(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class fridaySecTimeOn : UILabel
		{
			public fridaySecTimeOn(int x, int y,
								   string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class fridaySecTimeOff : UILabel
		{
			public fridaySecTimeOff(int x, int y,
									string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2;
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class fridayThirdTimeOn : UILabel
		{
			public fridayThirdTimeOn(int x, int y,
									 string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				BackgroundColor = UIColor.FromRGB(r, g, b); //背景色
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}

		sealed class fridayThirdTimeOff : UILabel
		{
			public fridayThirdTimeOff(int x, int y,
									  string z, int r, int g, int b)
			{
				Frame = new RectangleF(x, y, 80, 60);//親ビューからの相対位置
				TextAlignment = UITextAlignment.Center;//センタリング
				Layer.BorderColor = UIColor.FromRGB(r, g, b).CGColor;
				Layer.BorderWidth = 2; 
                TextColor = UIColor.White;
				Text = z;//表示文字列
				Font = UIFont.FromName("Arial", 17f);//フォント
				Lines = 0;//制限無しで改行出来る！
			}
		}
	}



    //データベースのデータ
    public partial class TimeTableViewController
    {
        public TimeTableViewController(){}

		public string UserIdentify { get; set; }
		public string UserName { get; set; }
		public string UserSex { get; set; }
		public string UserBirthday { get; set; }
		public string UserNationality { get; set; }

    }
}