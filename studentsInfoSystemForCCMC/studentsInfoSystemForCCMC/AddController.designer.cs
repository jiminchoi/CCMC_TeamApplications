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
    [Register ("AddController")]
    partial class AddController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton createBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField createID { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField createPWD { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField createSecurityPWD { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton displayData { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField userBrithDay { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView userInfoList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField userName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField userNationality { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField userSex { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (addUser != null) {
                addUser.Dispose ();
                addUser = null;
            }

            if (createBtn != null) {
                createBtn.Dispose ();
                createBtn = null;
            }

            if (createID != null) {
                createID.Dispose ();
                createID = null;
            }

            if (createPWD != null) {
                createPWD.Dispose ();
                createPWD = null;
            }

            if (createSecurityPWD != null) {
                createSecurityPWD.Dispose ();
                createSecurityPWD = null;
            }

            if (displayData != null) {
                displayData.Dispose ();
                displayData = null;
            }

            if (userBrithDay != null) {
                userBrithDay.Dispose ();
                userBrithDay = null;
            }

            if (userInfoList != null) {
                userInfoList.Dispose ();
                userInfoList = null;
            }

            if (userName != null) {
                userName.Dispose ();
                userName = null;
            }

            if (userNationality != null) {
                userNationality.Dispose ();
                userNationality = null;
            }

            if (userSex != null) {
                userSex.Dispose ();
                userSex = null;
            }
        }
    }
}