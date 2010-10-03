using System;
using Pigmeo.Extensions;

namespace Pigmeo {
	/// <summary>
	/// Variable that represents any kind of unit of measurement
	/// </summary>
	public abstract class Unit {
		protected float value;

		public float ConvertPrefix(float value, SIPrefixes CurrentPrefix, SIPrefixes NewPrefix) {
			return value * GetMultiplier(CurrentPrefix) / GetMultiplier(NewPrefix);
		}

		protected float GetMultiplier(SIPrefixes prefix) {
			float multip = 0;
			switch(prefix) {
				case SIPrefixes.p:
					multip = (float)Math.Pow(10, -12);
					break;
				case SIPrefixes.n:
					multip = (float)Math.Pow(10, -9);
					break;
				case SIPrefixes.µ:
					multip = (float)Math.Pow(10, -6);
					break;
				case SIPrefixes.m:
					multip = (float)Math.Pow(10, -3);
					break;
				case SIPrefixes.Unit:
					multip = 1;
					break;
				case SIPrefixes.k:
					multip = (float)Math.Pow(10, 3);
					break;
				case SIPrefixes.M:
					multip = (float)Math.Pow(10, 6);
					break;
				default:
					throw new Exception("Prefix \"" + prefix.ToString() + "\" not supported yet");
			}
			return multip;
		}
	}
}
