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
    [Register ("MainMenuController")]
    partial class MainMenuController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView barcodeClick { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView codeImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logoImage2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PackingButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ReadBarcodeButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (barcodeClick != null) {
                barcodeClick.Dispose ();
                barcodeClick = null;
            }

            if (codeImage != null) {
                codeImage.Dispose ();
                codeImage = null;
            }

            if (logoImage2 != null) {
                logoImage2.Dispose ();
                logoImage2 = null;
            }

            if (PackingButton != null) {
                PackingButton.Dispose ();
                PackingButton = null;
            }

            if (ReadBarcodeButton != null) {
                ReadBarcodeButton.Dispose ();
                ReadBarcodeButton = null;
            }
        }
    }
}