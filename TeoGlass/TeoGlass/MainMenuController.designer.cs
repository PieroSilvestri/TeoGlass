// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
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
        UIKit.UIButton ReadBarcodeButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ReadBarcodeButton != null) {
                ReadBarcodeButton.Dispose ();
                ReadBarcodeButton = null;
            }
        }
    }
}