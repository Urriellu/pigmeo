using System;
using System.Drawing;

namespace Pigmeo.Extensions {
	public static class ImageExtensions {
		/// <summary>
		/// Scales the image to fit the specified maximum width and height
		/// </summary>
		/// <param name="source"></param>
		/// <param name="MaxWidth">Maximum width</param>
		/// <param name="MaxHeight">Maximum height</param>
		public static void Scale(this Image source, int MaxWidth, int MaxHeight) {
			float ImgRatio = source.Width / (float)source.Height;

			if(source.Width > MaxWidth) {
				source = new Bitmap(source, new Size(MaxWidth, (int)Math.Round(MaxWidth / ImgRatio, 0)));
			}

			if(source.Height > MaxHeight) {
				source = new Bitmap(source, new Size((int)Math.Round(MaxWidth * ImgRatio, 0), MaxHeight));
			}
		}
	}
}
