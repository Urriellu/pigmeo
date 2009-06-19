using System;

namespace Pigmeo.Extensions {
	public static class uint32Extensions {
		/// <summary>
		/// Gets the four bytes that represent this UInt16
		/// </summary>
		public static byte[] GetBytes(this UInt32 n) {
			byte[] bytes = new byte[4];
			bytes[3] = (byte)(n >> 24);
			bytes[2] = (byte)(n >> 16);
			bytes[1] = (byte)(n >> 8);
			bytes[0] = (byte)n;
			return bytes;
		}
	}
}
