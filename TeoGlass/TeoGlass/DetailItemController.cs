using Foundation;
using System;
using UIKit;
using Plugin.Media.Abstractions;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace TeoGlass
{
	public partial class DetailItemController : UIViewController
	{

		private PhotoEvents PhotoEvents;
		private UIAlertController alertView;
		private MainViewModel MainViewModel;
		MediaFile photoMade;
		public string ItemName { get; set; }

		public DetailItemController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a ni
			Title = "Detail Item";
			PickPhotoButton.TouchUpInside += PickPhoto;
			DoneButton.TouchUpInside += SendImage;
			CancelButton.TouchUpInside += GotoBackPage;
			PhotoEvents = new PhotoEvents();
			MainViewModel = new MainViewModel();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in us   
		}

		async void PickPhoto(object sender, EventArgs e)
		{
			var image = await PhotoEvents.PickPhotoEvent();

			if (image == null)
			{
				alertView = UIAlertController.Create("Camera Error", "Camera is not available on this device.", UIAlertControllerStyle.Alert);
				alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

				// Present Alert
				PresentViewController(alertView, true, null);

				return;
			}

			ImageBox1.Image = UIImage.FromFile(image.Path);
			TextView1.Text = image.Path;
			photoMade = image;

		}

		async void SendImage(object sender, EventArgs e)
		{
			var image = ImageBox1.Image;
			var result = new JObject();
			try
			{
				result = await MainViewModel.PostImage(photoMade);
				Debug.WriteLine(result);

				if ((bool)result["success"])
				{

					alertView = UIAlertController.Create("Send Success", "Image sent correctly.", UIAlertControllerStyle.Alert);
					alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
					// Present Alert
					PresentViewController(alertView, true, null);

					var fileManager = NSFileManager.DefaultManager;

					NSError err = new NSError();
					bool remove = fileManager.Remove(photoMade.Path, out err);
					if (remove)
					{
						Debug.WriteLine("Elemento cancellato");
					}
					else
					{
						Debug.WriteLine("Elemento NON cancellato");
						alertView = UIAlertController.Create("Error", "File maybe not been cancelled.", UIAlertControllerStyle.Alert);
						alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
					}
				}
			}
			catch (Exception exc)
			{
				alertView = UIAlertController.Create("Error", "Something went wrong. File not found", UIAlertControllerStyle.Alert);
				alertView.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
				// Present Alert
				PresentViewController(alertView, true, null);
			
			}

		}

		void GotoBackPage(object sender, EventArgs e)
		{
			NavigationController.PopViewController(true);
		}

	}
}