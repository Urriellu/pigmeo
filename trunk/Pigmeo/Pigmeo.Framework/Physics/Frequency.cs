using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Variable that represents a frequency
	/// </summary>
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
				case FrequencyUnitsSI.pHz:
					prefix = SIPrefixes.p;
					break;
				case FrequencyUnitsSI.nHz:
					prefix = SIPrefixes.n;
					break;
				case FrequencyUnitsSI.µHz:
					prefix = SIPrefixes.µ;
					break;
				case FrequencyUnitsSI.mHz:
					prefix = SIPrefixes.m;
					break;
				case FrequencyUnitsSI.cHz:
					prefix = SIPrefixes.c;
					break;
				case FrequencyUnitsSI.dHz:
					prefix = SIPrefixes.d;
					break;
				case FrequencyUnitsSI.Hz:
					prefix = SIPrefixes.Unit;
					break;
				case FrequencyUnitsSI.daHz:
					prefix = SIPrefixes.da;
					break;
				case FrequencyUnitsSI.hHz:
					prefix = SIPrefixes.h;
					break;
				case FrequencyUnitsSI.kHz:
					prefix = SIPrefixes.k;
					break;
				case FrequencyUnitsSI.MHz:
					prefix = SIPrefixes.M;
					break;
				case FrequencyUnitsSI.GHz:
					prefix = SIPrefixes.G;
					break;
				case FrequencyUnitsSI.THz:
					prefix = SIPrefixes.T;
					break;
				case FrequencyUnitsSI.PHz:
					prefix = SIPrefixes.P;
					break;
				case FrequencyUnitsSI.EHz:
					prefix = SIPrefixes.E;
					break;
				case FrequencyUnitsSI.ZHz:
					prefix = SIPrefixes.Z;
					break;
				case FrequencyUnitsSI.YHz:
					prefix = SIPrefixes.Y;
					break;
				default:
					throw new Exception("SI frequency unit \"" + funits.ToString() + "\" not supported yet");
			}

			this.value = ConvertPrefix(value, prefix, StoragePrefix);
		}

		public Frequency(Period T) {
			value = Convert(1f / T.GetValue(SIPrefixes.Unit, TimeUnits.second), FrequencyUnits.Hz, Frequency.StorageUnit);
		}

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

		public Period ToPeriod() {
			return new Period(this);
		}

		public static Frequency operator *(Frequency freq, float n) {
			return new Frequency(freq.GetValue(Frequency.StoragePrefix, Frequency.StorageUnit) * n, Frequency.StoragePrefix, Frequency.StorageUnit);
		}

		public static Frequency operator /(Frequency freq, float n) {
			return new Frequency(freq.GetValue(Frequency.StoragePrefix, Frequency.StorageUnit) / n, Frequency.StoragePrefix, Frequency.StorageUnit);
		}
	}
}
