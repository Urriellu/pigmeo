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
		public static Image Scale(this Image source, int MaxWidth, int MaxHeight) {
			int NewWidth = MaxWidth;
			int NewHeight = source.Height * NewWidth / source.Width;
			if(NewHeight > MaxHeight) {
				NewWidth = source.Width * MaxHeight / source.Height;
				NewHeight = MaxHeight;
			}

			Image NewImage = source.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

			return NewImage;
		}
	}
}
