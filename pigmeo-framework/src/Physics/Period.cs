using System;
using Pigmeo;

namespace Pigmeo.Physics {
	public class Period:Unit {
		/// <summary>
		/// International System of Units prefix in which the value will be stored in memory
		/// </summary>
		protected static SIPrefixes StoragePrefix = SIPrefixes.Unit;

		/// <summary>
		/// Units in which the value will be stored in memory
		/// </summary>
		protected static TimeUnits StorageUnit = TimeUnits.second;

		public Period(float value, SIPrefixes prefix, TimeUnits Punit) {
			this.value = Convert(ConvertPrefix(value, prefix, StoragePrefix), Punit, StorageUnit);
		}

		public Period(float value, TimeUnitsSI Punits) {
			SIPrefixes prefix = SIPrefixes.Unit;

			switch(Punits) {
				case TimeUnitsSI.ms:
					prefix = SIPrefixes.m;
					break;
				case TimeUnitsSI.s:
					prefix = SIPrefixes.Unit;
					break;
				default:
					throw new Exception("SI time unit not supported yet");
			}

			this.value = ConvertPrefix(value, prefix, StoragePrefix);
		}

		protected static float GetTimeMultiplier(TimeUnits unit) {
			float multip = 0;
			switch(unit) {
				case TimeUnits.hour:
					multip = 3600;
					break;
				case TimeUnits.minute:
					multip = 60;
					break;
				case TimeUnits.second:
					multip = 1;
					break;
				default:
					throw new Exception("Time unit not supported yet");
			}
			return multip;
		}

		/*public Period(Frequency freq) {
			value = 1 / freq;
		}*/

		public static float Convert(float value, TimeUnits CurrentUnit, TimeUnits NewUnit) {
			return value * GetTimeMultiplier(CurrentUnit) / GetTimeMultiplier(NewUnit);
		}

		/*public Frequency ToFrequency() {
			return new Frequency(this);
		}*/
	}
}
