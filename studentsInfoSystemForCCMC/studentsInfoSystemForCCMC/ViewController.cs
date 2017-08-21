using System;
using System.IO;
using SQLite;
using System.Collections;
using UIKit;

namespace studentsInfoSystemForCCMC
{
    public partial class ViewController : UIViewController
    {
        private string path = "";
        private string msgTitle = "ログイン";
        private string btnTitle = "確認";

        ArrayList userInfoList;

        protected ViewController(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            loginBtn.TouchUpInside += LoginBtn_TouchUpInside;
        }

        //ログイン
        void LoginBtn_TouchUpInside(object sender, EventArgs e)
        {
			var db = new SQLiteConnection(path);
			var tableUserInfo = db.Table<UserInfo>();
            var tableTimeTable = db.Table<TimeTable>();

            try {
                userInfoList = new ArrayList();

				if (textboxId.Text.Equals("") || textboxPwd.Text.Equals(""))
				{
					ShowAlertMessage("ID又はパース−ワードを入力して下さい");
				}



                foreach (var infolist in tableUserInfo)
				{
                    if ((infolist.LoginIdentity.Equals(textboxId.Text) &&
                         infolist.LoginPassword.Equals(textboxPwd.Text)))
					{
                        userInfoList.Add(infolist.LoginIdentity);
                        userInfoList.Add(infolist.UserName);
                        userInfoList.Add(infolist.UserSex);
                        userInfoList.Add(infolist.UserBirthday);
                        userInfoList.Add(infolist.UserNationality);


                        PerformSegue("segueLogin", this);
                        ShowAlertMessage("ログインに成功しました！");

						break;
					}
				}
				ShowAlertMessage("ID又はパース−ワードが間違ってます！");
            } catch{
				ShowAlertMessage("データーが存在しておりません。");
			}
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            UITabBarController ctrl = segue.DestinationViewController as UITabBarController;

            foreach (var vc in ctrl.ViewControllers) {
                if (vc != null && vc.GetType() == typeof(TimeTableViewController)) {
                    ((TimeTableViewController)vc).UserIdentify = userInfoList[0].ToString();
                    ((TimeTableViewController)vc).UserName = userInfoList[1].ToString();
                    ((TimeTableViewController)vc).UserSex = userInfoList[2].ToString();
                    ((TimeTableViewController)vc).UserBirthday = userInfoList[3].ToString();
                    ((TimeTableViewController)vc).UserNationality = userInfoList[4].ToString();
				}
                if(vc != null && vc.GetType() == typeof(DirectMessageController)){
					((DirectMessageController)vc).UserName = userInfoList[1].ToString();
				}
                //else if (vc != null && vc.GetType() == typeof(TabBarTimeTable)) { 
                //    ((TabBarTimeTable)vc).UserName = data; 
                //} 
            }
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
			};
			this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default); // 背景透明
			this.NavigationController.NavigationBar.ShadowImage = new UIImage(); // 境界線透明

			this.NavigationController.Toolbar.TintColor = UIColor.White;
			this.NavigationController.Toolbar.SetBackgroundImage(new UIImage(), UIToolbarPosition.Any, UIBarMetrics.Default); // 背景透明
			this.NavigationController.Toolbar.ClipsToBounds = true; // 境界線非表示

		}

		//Alert Method
		private void ShowAlertMessage(string msgContent)
		{
			var alert = UIAlertController.Create(msgTitle, msgContent, UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create(btnTitle, UIAlertActionStyle.Cancel, null));
			PresentViewController(alert, animated: true, completionHandler: null);
		}
    }

}
