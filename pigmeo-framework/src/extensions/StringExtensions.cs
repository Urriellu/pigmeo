using System;

namespace Pigmeo.Extensions {
	public static class StringExtensions {
		/// <summary>
		/// Parses a string written in binary and converts it to a 8-bit unsigned integer
		/// </summary>
		public static byte Bin2Byte(this string BinaryString) {
			return Convert.ToByte(BinaryString, 2);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 8-bit unsigned integer
		/// </summary>
		public static byte Bin2UInt8(this string BinaryString) {
			return Bin2UInt8(BinaryString);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 16-bit unsigned integer
		/// </summary>
		public static UInt16 Bin2UInt16(this string BinaryString) {
			return Convert.ToUInt16(BinaryString, 2);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 32-bit unsigned integer
		/// </summary>
		public static UInt32 Bin2UInt32(this string BinaryString) {
			return Convert.ToUInt32(BinaryString, 2);
		}
	}
}
