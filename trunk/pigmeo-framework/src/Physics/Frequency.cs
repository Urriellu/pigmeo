using System;

namespace Pigmeo.Physics {
	public class Frequency:Unit {
		/// <summary>
		/// International System of Units prefix in which the value will be stored in memory
		/// </summary>
		protected static SIPrefixes StoragePrefix = SIPrefixes.Unit;

		/// <summary>
		/// Units in which the value will be stored in memory
		/// </summary>
		protected static FrequencyUnits StorageUnit = FrequencyUnits.Hz;

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

		public void SetValue(float NewValue, SIPrefixes prefix, FrequencyUnits funit){
			float ValueInStorageUnit = ConvertPrefix(NewValue, prefix, StoragePrefix);
			value = Convert(ValueInStorageUnit, funit, StorageUnit);
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

		/// <summary>
		/// Change prefix and units in which the values are stored in RAM
		/// </summary>
		/// <param name="NewPrefix">New prefix in which the values will be stored</param>
		/// <param name="NewFreqUnits">New Frequency units in which the values will be stored</param>
		/// <param name="UpdateObjects">List of Frequency objects to be updated (all the objects not updated here will be corrupted!)</param>
		public static void ChangeStorageUnits(SIPrefixes NewPrefix, FrequencyUnits NewFreqUnits, params Frequency[] UpdateObjects) {
			for(int i=0;i<UpdateObjects.Length;i++){
				Frequency obj = UpdateObjects[i];
				//force the new value to be the basic unit
				obj.SetValue(obj.GetValue(NewPrefix, NewFreqUnits), SIPrefixes.Unit, FrequencyUnits.Hz);
			}
			StoragePrefix = NewPrefix;
			StorageUnit = NewFreqUnits;
		}

		/*public Period ToPeriod() {
			return new Period(this);
		}*/
	}
}
