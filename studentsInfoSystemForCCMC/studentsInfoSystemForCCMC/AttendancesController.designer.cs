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
    [Register ("AttendancesController")]
    partial class AttendancesController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView attendancesGraph { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (attendancesGraph != null) {
                attendancesGraph.Dispose ();
                attendancesGraph = null;
            }
        }
    }
}