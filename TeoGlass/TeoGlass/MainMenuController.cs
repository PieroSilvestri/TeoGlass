using Foundation;
using System;
using Plugin.Media;
using UIKit;
using Plugin.Media.Abstractions;


namespace TeoGlass
{
	public partial class MainMenuController : UIViewController
	{

		private PhotoEvents _photoEvents;
		UIAlertController alertView;
		MediaFile imageToBePassed;

		public MainMenuController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			_photoEvents = new PhotoEvents();
			// Perform any additional setup after loading the view, typically from a nib.
			ReadBarcodeButton.TouchUpInside += PickPhoto;
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
				alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

				// Present Alert
				PresentViewController(alertView, true, null);

				return;
			}
			imageToBePassed = image;

			PerformSegue("GotoBarcodeScan", this);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "GotoBarcodeScan")
			{
				var barcodeScanController = segue.DestinationViewController as BarcodeScanController;
				if (barcodeScanController != null)
				{
					barcodeScanController.ImagePassed = imageToBePassed;
				}
			}
		}
	}
}