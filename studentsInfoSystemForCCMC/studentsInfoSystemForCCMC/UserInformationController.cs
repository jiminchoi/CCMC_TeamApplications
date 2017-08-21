using Foundation;
using System;
using System.IO;
using System.Data.Common;

using SQLite;
using UIKit;
using System.Collections.Generic;

namespace studentsInfoSystemForCCMC
{
    public partial class UserInformationController : UIViewController
    {
        string path = "";

        public UserInformationController (IntPtr handle) : base (handle)
        {
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			//ListView.Text = findName(0, path);
            IEnumerable<UserInfo> plist = findName(path, 2);
            userInfoList.Text = "";
			foreach (var p in plist)
			{
                //if(p.UserName.Equals(UserName)){
                //    userInfoList.Text = "お名前：" + p.UserName + "\n"
                //        + "クラス" + p.UserClassID + "\n" + "性別" + p.UserSex + "\n" + "誕生日：" + p.UserBirthday +"\n"
                //        + "国籍：" + p.UserNationality + "\n";
                //}
                userInfoList.Text += p + "\n";
			}
        }

        private IEnumerable<UserInfo> findName(string path, int id)
		{
			try
			{
				var db = new SQLiteConnection(path);
				// this counts all records in the database, it can be slow depending on the size of the database
				string sql = string.Format("SELECT UserName FROM UserInfo where ID = {0}", id);
                var val = db.Query<UserInfo>(sql);
				//var name = db.ExecuteScalar<string>("SELECT * From Person Where FirstName like '%BC'");
				// var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

				return val;
			}
			catch (SQLiteException ex)
			{


				return null;
			}
		}

		private void ShowAlertMessage(string msgContent)
		{
			var alert = UIAlertController.Create("エーラー", msgContent, UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create("エーラー", UIAlertActionStyle.Cancel, null));
			PresentViewController(alert, animated: true, completionHandler: null);
		}
    }


    public partial class UserInformationController{
        
		public string UserIdentify { get; set; }
		public string UserName { get; set; }
		public string UserSex { get; set; }
		public string UserBirthday { get; set; }
		public string UserNationality { get; set; }

    }
}