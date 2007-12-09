namespace Pigmeo.Extensions {
	public static class uint8Extensions {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary
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
			return BinaryString.Bin2Byte();
		}

		/// <summary>
		/// Gets the specified bit value
		/// </summary>
		/// <param name="b"></param>
		/// <param name="bit"></param>
		/// <returns></returns>
		public static bool GetBit(this byte b, byte bit) {
			return ( ( ( b >> bit ) & 1 ) == 1 ) ? true : false;
		}

		/*public static void SetBit(this byte b, byte bit, bool value) {
			if(value) {
				b |= (byte)(1 << bit);
			} else {
				b ^= (byte)(1 << bit);
			}
		}*/
	}
}
