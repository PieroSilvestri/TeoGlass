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

namespace TeoGlass
{
    [Register ("HomePageController")]
    partial class HomePageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logoImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logoImageIphone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Packing { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Tests { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (logoImage != null) {
                logoImage.Dispose ();
                logoImage = null;
            }

            if (logoImageIphone != null) {
                logoImageIphone.Dispose ();
                logoImageIphone = null;
            }

            if (Packing != null) {
                Packing.Dispose ();
                Packing = null;
            }

            if (Tests != null) {
                Tests.Dispose ();
                Tests = null;
            }
        }
    }
}