using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using UIKit;

namespace TeoGlass
{
	public class PhotoEvents
	{
		public PhotoEvents()
		{
		}

		public async Task<MediaFile> PickPhotoEvent()
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsPickPhotoSupported)
				return null;
			

			var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());

			if (file == null)
				return null;
			else
				return file;

			//ImageBoxView.Image = UIImage.FromFile(file.Path);
			//ImageBoxView.(
		}
	}
}
