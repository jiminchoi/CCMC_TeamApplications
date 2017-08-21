// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace studentsInfoSystemForCCMC
{
    [Register ("TimeTableViewController")]
    partial class TimeTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton checkAttendances { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dayList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel firstTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel secondTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel thirdTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem timeTableNaviItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel todaysTime { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (checkAttendances != null) {
                checkAttendances.Dispose ();
                checkAttendances = null;
            }

            if (dayList != null) {
                dayList.Dispose ();
                dayList = null;
            }

            if (firstTime != null) {
                firstTime.Dispose ();
                firstTime = null;
            }

            if (secondTime != null) {
                secondTime.Dispose ();
                secondTime = null;
            }

            if (thirdTime != null) {
                thirdTime.Dispose ();
                thirdTime = null;
            }

            if (timeTableNaviItem != null) {
                timeTableNaviItem.Dispose ();
                timeTableNaviItem = null;
            }

            if (todaysTime != null) {
                todaysTime.Dispose ();
                todaysTime = null;
            }
        }
    }
}