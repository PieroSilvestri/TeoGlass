using Foundation;
using System;
using UIKit;

namespace TeoGlass
{
	public partial class ItemDashboardController : UIViewController
	{
		public ItemDashboardController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Item Dashboard";
			DoneButton1.TouchUpInside += GotoDetailPage;
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
	}
}