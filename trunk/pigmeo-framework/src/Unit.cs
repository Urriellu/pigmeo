using System;
using Pigmeo.Extensions;

namespace Pigmeo {
	public abstract class Unit {
		protected float value;

		public float ConvertPrefix(float value, SIPrefixes CurrentPrefix, SIPrefixes NewPrefix) {
			return value*GetMultiplier(CurrentPrefix)/GetMultiplier(NewPrefix);
		}

		protected float GetMultiplier(SIPrefixes prefix) {
			float multip = 0;
			switch(prefix) {
				case SIPrefixes.µ:
					multip = MathExtended.Pow(10, -6);
					break;
				case SIPrefixes.Unit:
					multip = 1;
					break;
				case SIPrefixes.k:
					multip = MathExtended.Pow(10, 3);
					break;
				case SIPrefixes.M:
					multip = MathExtended.Pow(10, 6);
					break;
				default:
					throw new Exception("Prefix not supported yet");
			}
			return multip;
		}
	}
}
