﻿using System;

namespace Pigmeo.Extensions {
	public static class uint16Extensions {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary
		public static UInt16 RiseTo(this UInt16 TheBase, UInt16 exponent) {
			UInt16 result = 1;
			for(UInt16 i = 0 ; i < exponent ; i++) {
				result *= TheBase;
			}
			return result;
		}

		/// <summary>
		/// Parses a string written in binary and converts it to a 16-bit unsigned integer
		/// </summary>
		public static UInt16 LoadBinaryString(this UInt16 n, string BinaryString) {
			return BinaryString.Bin2UInt16();
		}
	}
}
