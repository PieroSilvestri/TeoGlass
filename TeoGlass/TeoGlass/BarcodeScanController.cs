using Foundation;
using System;
using Plugin.Media;
using UIKit;
using Plugin.Media.Abstractions;
using ZXing.Mobile;
using System.IO;

namespace TeoGlass
{
	public partial class BarcodeScanController : UIViewController
	{

		private PhotoEvents _photoEvents;
		UIAlertController alertView;
		public MediaFile ImagePassed { get; set; }

		public BarcodeScanController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			_photoEvents = new PhotoEvents();
			// Perform any additional setup after loading the view, typically from a nib
			if (ImagePassed != null)
			{
				BarcodeImage.Image = UIImage.FromFile(ImagePassed.Path);
			}
			//OkButton.TouchUpInside += ScannerEvent;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in us   }
		}

		private async void PickPhoto(object sender, EventArgs e)
		{
			var image = await _photoEvents.PickPhotoEvent();

			if (image == null)
			{
				alertView = UIAlertController.Create("Camera Error", "Camera is not available on this device.", UIAlertControllerStyle.Alert);
				alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null)); ;

				// Present Alert
				PresentViewController(alertView, true, null);

				return;
			}

			BarcodeImage.Image = UIImage.FromFile(image.Path);
		}
	}
}