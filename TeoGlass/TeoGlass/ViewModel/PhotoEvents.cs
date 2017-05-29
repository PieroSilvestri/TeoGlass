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
			return file;
		}

		public async Task<MediaFile> GetPhotoEvent()
		{
			await CrossMedia.Current.Initialize();
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				return null;
			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				Directory = "Sample",
				Name = "test.jpg"
			});
			return file;
		}
	}
}
