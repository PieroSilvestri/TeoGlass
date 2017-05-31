using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TeoGlass
{
	public partial class ItemDashboardController : UIViewController
	{


		public List<JObject> blisterPhotosList;
		public List<JObject> systemPhotosList;
		public List<JObject> otherPhotosList;

		public ItemDashboardController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Item Dashboard";
			DoneButton1.TouchUpInside += GotoDetailPage;
			blisterPhotosList = new List<JObject>();
			systemPhotosList = new List<JObject>();
			otherPhotosList = new List<JObject>();
			BlisterLabel.Text = "Blister Photos (" + blisterPhotosList.Count + ")";
			SystemLabel.Text = "System Photos (" + systemPhotosList.Count + ")";
			OtherLabel.Text = "Other Photos (" + otherPhotosList.Count + ")";
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in us   
		}

		void GotoDetailPage(object sender, EventArgs e)
		{
			
			PerformSegue("GotoDetailPage", this);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "GotoDetailPage")
			{
				var barcodeScanController = segue.DestinationViewController as DetailItemController;
				if (barcodeScanController != null)
				{
					//barcodeScanController.ImagePassed = imageToBePassed;
				}
			}
		}
	}
}