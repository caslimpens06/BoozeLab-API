using System;
using System.IO;

namespace WebApi1.Model
{
	public class ImageDecoder
	{
		public static void ConvertBase64ToImageFile(string base64String, string outputFilePath)
		{
			try
			{
				byte[] imageBytes = Convert.FromBase64String(base64String);
				File.WriteAllBytes(outputFilePath, imageBytes);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error converting Base64 to image: {ex.Message}");
			}
		}
	}
}