using Foundation;
using System;
using System.IO;

using SQLite;
using UIKit;

namespace studentsInfoSystemForCCMC
{
    public partial class DirectMessageController : UIViewController
    {
		private string path = "";

		public DirectMessageController (IntPtr handle) : base (handle)
        {
			path = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					"userInfo.db3");
        }

        public string UserName { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DirectMessageTitle.Title = UserName;
        }
    }
}