using System;
using Pigmeo.Extensions;

namespace Pigmeo {
	/// <summary>
	/// Math library with extra methods not found in System.Math
	/// </summary>
	public static class MathExtended {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="TheBase">Number to be raised to a power</param>
		/// <param name="exponent">Exponent: number that specifies a power</param>
		/// <returns>returned=base^exponent</returns>
		public static byte Pow(byte TheBase, byte exponent) {
			return TheBase.RiseTo(exponent);
		}

		public static float Pow(float TheBase, float exponent) {
			return (float)Math.Pow(TheBase, exponent);
		}
	}
}
