using Foundation;
using System;
using System.IO;

using SQLite;
using UIKit;

namespace studentsInfoSystemForCCMC
{
    public partial class AddController : UIViewController
    {

        private string path = "";
        private string msgTitle = "SQLite DB Access";
        private string btnTitle = "確認";

        private UserInfo data;
        //FileHelper fh;

        public AddController (IntPtr handle) : base (handle)
        {
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
            /* fh = new FileHelper();
            path = fh.GetLocalFilePath("");*/
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            userInfoList.Text = "";

            createBtn.TouchUpInside += CreateBtn_TouchUpInside;
            addUser.TouchUpInside += AddUser_TouchUpInside;
            displayData.TouchUpInside += DisplayData_TouchUpInside;
        }

        //データーベースの生成ボタン
        void CreateBtn_TouchUpInside(object sender, EventArgs e)
        {
			CreateDataBase(path);
        }

        //ユーザー登録ボタン
        void AddUser_TouchUpInside(object sender, EventArgs e)
        {
            data = new UserInfo()
            {
                LoginIdentity = createID.Text,
                LoginPassword = createPWD.Text,
                UserName = userName.Text,
                UserSex = userSex.Text,
                UserBirthday = userBrithDay.Text,
                UserNationality = userNationality.Text,
                //UserClassID = naem;
			};

			if (createPWD.Text.Equals(createSecurityPWD.Text))
			{
				InsertUpdateData(data, path);
			}
   //         if (createPWD.Equals(createSecurityPWD))
   //         {
                
   //         }else {
			//	ShowAlertMessage("パース−ワードが一致していません。");
			//}
        }

        //生成の機能
		private void CreateDataBase(string path)
		{
			try
			{
				var connection = new SQLiteConnection(path);
				{
                    connection.CreateTable<UserInfo>();
                    ShowAlertMessage("生成に成功しました。");
				}
			}
            catch
			{
                ShowAlertMessage("生成に失敗しました。");
				return;
			}
		}

        //登録の機能
        private void InsertUpdateData(UserInfo data, string path)
		{
			try
			{
				var db = new SQLiteConnection(path);

				if (db.Insert(data) != 0)
				{
					db.Update(data);
				}

                ShowAlertMessage("データの登録完了!");

				return;
			}
			catch
			{
                ShowAlertMessage("データの登録失敗");
				return;
			}
		}

        void DisplayData_TouchUpInside(object sender, EventArgs e)
        {
			var db = new SQLiteConnection(path);
			var table = db.Table<UserInfo>();

            userInfoList.Text = "";

			foreach (var list in table)
			{
                userInfoList.Text += list.ID + ", ID : " +list.LoginIdentity + ", PWD : " 
                    + list.LoginPassword + ", Name : " + list.UserName + ", Nationality : " 
                    + list.UserNationality + "\n";
			}
        }

        //Alert Method
        private void ShowAlertMessage(string msgContent)
		{
			var alert = UIAlertController.Create(msgTitle, msgContent, UIAlertControllerStyle.Alert);

			alert.AddAction(UIAlertAction.Create(btnTitle, UIAlertActionStyle.Cancel, null));
			PresentViewController(alert, animated: true, completionHandler: null);
		}
    }



	//public class FileHelper
	//{
	//	public string GetLocalFilePath(string filename)
	//	{
	//		string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
	//		string libFolder = Path.Combine(docFolder, "..", "Documents", "masterFolder", "Databases");

	//		if (!Directory.Exists(libFolder))
	//		{
	//			Directory.CreateDirectory(libFolder);
	//		}

	//		return Path.Combine(libFolder, filename);
	//	}
	//}
}