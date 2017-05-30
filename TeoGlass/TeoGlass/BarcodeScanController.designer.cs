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
    [Register ("BarcodeScanController")]
    partial class BarcodeScanController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView BarcodeImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton OkButton { get; set; }

        [Action ("OkButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OkButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BarcodeImage != null) {
                BarcodeImage.Dispose ();
                BarcodeImage = null;
            }

            if (OkButton != null) {
                OkButton.Dispose ();
                OkButton = null;
            }
        }
    }
}