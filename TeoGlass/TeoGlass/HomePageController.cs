using Foundation;
using System;
using UIKit;

namespace TeoGlass
{
    public partial class HomePageController : UIViewController
    {
        public HomePageController (IntPtr handle) : base (handle)
        {
            

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            logoImage.Image = UIImage.FromFile("Images/inglassLogo.png");
            logoImageIphone.Image = UIImage.FromFile("Images/inglassLogo.png");
            Packing.BackgroundColor = UIColor.Blue;
            Packing.SetTitleColor(UIColor.White, UIControlState.Normal);
            Packing.Layer.CornerRadius = 10;
            Tests.BackgroundColor = UIColor.Blue;
            Tests.SetTitleColor(UIColor.White, UIControlState.Normal);
            Tests.Layer.CornerRadius = 10;
        }

        00
    }
}