using System;

namespace Pigmeo.Extensions {
	public static class uint8Extensions {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		public static byte RiseTo(this byte TheBase, byte exponent) {
			byte result=1;
			for(byte i = 0 ; i < exponent ; i++) {
				result *= TheBase;
			}
			return result;
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 8-bit unsigned integer
		/// </summary>
		public static byte LoadBinaryString(this byte n, string BinaryString) {
			return BinaryString.BinToByte();
		}

		/// <summary>
		/// Gets the specified bit value
		/// </summary>
		public static bool GetBit(this byte b, byte bit) {
			return ( ( ( b >> bit ) & 1 ) == 1 ) ? true : false;
		}

		/// <summary>
		/// Gets the the value of the given byte with one of its bits set to the given value
		/// </summary>
		public static byte SetBit(this byte b, byte bit, bool value) {
			if(value) {
				return (byte)(b | (byte)(1 << bit));
			} else {
				return (byte)(b ^ (byte)(1 << bit));
			}
		}
	}
}
