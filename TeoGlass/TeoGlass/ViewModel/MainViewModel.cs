using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Plugin.Media.Abstractions;

namespace TeoGlass
{
	public class MainViewModel
	{
		public MainViewModel()
		{
		}

		static byte[] GetImageAsByteArray(MediaFile imageFile)
		{
			BinaryReader binaryReader = new BinaryReader(imageFile.GetStream());
			return binaryReader.ReadBytes((int)imageFile.GetStream().Length);
		}

		public async Task<JObject> PostImage(MediaFile imageFile)
		{
			Byte[] b = File.ReadAllBytes(imageFile.Path);
			string s = Convert.ToBase64String(b);

			var client = new HttpClient();

			JObject temp1 = new JObject(
				new JProperty("type", "image"),
				new JProperty("base64", s));

			JArray tempJArray = new JArray() { temp1 };

			JObject tempJobject = new JObject(
				new JProperty("files", tempJArray));

			var content = new StringContent(tempJobject.ToString(), null, "application/json");

			var response = await client.PostAsync("http://l-raggioli2/api/send", content);
			response.EnsureSuccessStatusCode();

			var JsonResult = response.Content.ReadAsStringAsync().Result;

			return JObject.Parse(JsonResult);;
		}

		public async Task<string> GetFaceIdFromCognitiveServices(MediaFile imageFile)
		{
			var client = new HttpClient();
			//client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceKey);

			//string uri = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false";
			string url = "";

			HttpResponseMessage response;

			// Request body. Try this sample with a locally stored JPEG image.
			byte[] byteData = GetImageAsByteArray(imageFile);

			using (var content = new ByteArrayContent(byteData))
			{
				// This example uses content type "application/octet-stream".
				// The other content types you can use are "application/json" and "multipart/form-data".
				content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				response = await client.PostAsync(url, content);

			}

			var JsonResult = response.Content.ReadAsStringAsync().Result;

			JArray tempArray = JArray.Parse(JsonResult);
			JObject tempObject = (JObject)tempArray.First;

			return tempObject["faceId"].ToString();
		}
	}
}
