using System;

namespace Pigmeo.Extensions {
	/// <summary>
	/// Extension Methods for String
	/// </summary>
	public static class StringExtensions {
		/// <summary>
		/// Parses a string written in binary and converts it to a 3-bit unsigned integer
		/// </summary>
		public static UInt3 BinToUInt3(this string BinaryString) {
			return new UInt3(Convert.ToByte(BinaryString));
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 8-bit unsigned integer
		/// </summary>
		public static byte BinToByte(this string BinaryString) {
			return Convert.ToByte(BinaryString, 2);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 8-bit unsigned integer
		/// </summary>
		public static byte BinToUInt8(this string BinaryString) {
			return BinToByte(BinaryString);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 16-bit unsigned integer
		/// </summary>
		public static UInt16 BinToUInt16(this string BinaryString) {
			return Convert.ToUInt16(BinaryString, 2);
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 32-bit unsigned integer
		/// </summary>
		public static UInt32 BinToUInt32(this string BinaryString) {
			return Convert.ToUInt32(BinaryString, 2);
		}
	}
}
