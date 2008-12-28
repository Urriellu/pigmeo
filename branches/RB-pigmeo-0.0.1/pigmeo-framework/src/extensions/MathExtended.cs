namespace Pigmeo.Extensions {
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
	}
}
