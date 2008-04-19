using System;

namespace Pigmeo.Physics {
	public class Frequency:Unit {
		/// <summary>
		/// International System of Units prefix in which the value will be stored in memory
		/// </summary>
		public static SIPrefixes StoragePrefix = SIPrefixes.Unit;

		/// <summary>
		/// Units in which the value will be stored in memory
		/// </summary>
		public static FrequencyUnits StorageUnit = FrequencyUnits.Hz;

		public Frequency(float value, SIPrefixes prefix, FrequencyUnits funit) {
			this.value = Convert(ConvertPrefix(value, prefix, StoragePrefix), funit, StorageUnit);
		}

		public Frequency(float value, FrequencyUnitsSI funits) {
			SIPrefixes prefix = SIPrefixes.Unit;

			switch(funits) {
				case FrequencyUnitsSI.kHz:
					prefix = SIPrefixes.k;
					break;
				case FrequencyUnitsSI.MHz:
					prefix = SIPrefixes.M;
					break;
				default:
					throw new Exception("SI frequency unit not supported yet");
			}

			this.value = ConvertPrefix(value, prefix, StoragePrefix);
		}

		/*public Frequency(Period period) {
			value = 1 / period;
		}*/

		public float GetValue(SIPrefixes prefix, FrequencyUnits funit) {
			return Convert(ConvertPrefix(this.value, StoragePrefix, prefix), StorageUnit, funit);
		}

		protected static float GetFreqMultiplier(FrequencyUnits unit) {
			float multip = 0;
			switch(unit) {
				case FrequencyUnits.BPM:
					multip = 60;
					break;
				case FrequencyUnits.cps:
					multip = 1;
					break;
				case FrequencyUnits.Hz:
					multip = 1;
					break;
				case FrequencyUnits.rpm:
					multip = 1 / 60;
					break;
				default:
					throw new Exception("Frequency unit not supported yet");
			}
			return multip;
		}

		public static float Convert(float value, FrequencyUnits CurrentUnit, FrequencyUnits NewUnit) {
			return value * GetFreqMultiplier(CurrentUnit) / GetFreqMultiplier(NewUnit);
		}

		/*public Period ToPeriod() {
			return new Period(this);
		}*/
	}
}
