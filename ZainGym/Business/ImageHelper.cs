using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace ZainGym.Business
{
	class ImageHelper
	{
		public static Binary GetBinaryFromImageSource(string imagePath)
		{

			BitmapImage image = new BitmapImage(new Uri(imagePath));

			using (var ms = new MemoryStream())
			{
				JpegBitmapEncoder encoder = new JpegBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(image));
				encoder.Save(ms);
				return new Binary(ms.GetBuffer());
			}
		}

		public static BitmapImage GetImageFromBinary(Binary displayPic)
		{
			byte[] bitmapBuffer = displayPic.ToArray();
			
			MemoryStream bitmapStream = new MemoryStream(bitmapBuffer);
			
			BitmapImage image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = bitmapStream;
			image.CacheOption = BitmapCacheOption.OnLoad;
			image.EndInit();
			image.Freeze();

			return image;
		}
	}
}
