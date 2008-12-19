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
		private static TimeUnits _StorageUnit = TimeUnits.second;
		public static TimeUnits StorageUnit {
			get {
				return _StorageUnit;
			}
			protected set {
				_StorageUnit = value;
			}
		}

		public Period(float value, SIPrefixes prefix, TimeUnits Punit) {
			this.value = Convert(ConvertPrefix(value, prefix, StoragePrefix), Punit, StorageUnit);
		}

		public Period(float value, TimeUnitsSI Punits) {
			SIPrefixes prefix = SIPrefixes.Unit;

			switch(Punits) {
				case TimeUnitsSI.µs:
					prefix = SIPrefixes.µ;
					break;
				case TimeUnitsSI.ms:
					prefix = SIPrefixes.m;
					break;

				case TimeUnitsSI.s:
					prefix = SIPrefixes.Unit;
					break;
				default:
					throw new Exception("SI time unit \"" + Punits.ToString() + "\" not supported yet");
			}

			this.value = ConvertPrefix(value, prefix, StoragePrefix);
		}

		public Period(Frequency freq) {
			value = Convert(1 / freq.GetValue(SIPrefixes.Unit, FrequencyUnits.Hz), TimeUnits.second, Period.StorageUnit);
		}

		public float GetValue(SIPrefixes prefix, TimeUnits Tunit) {
			return Convert(ConvertPrefix(this.value, StoragePrefix, prefix), StorageUnit, Tunit);
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

		public static float Convert(float value, TimeUnits CurrentUnit, TimeUnits NewUnit) {
			return value * GetTimeMultiplier(CurrentUnit) / GetTimeMultiplier(NewUnit);
		}

		public Frequency ToFrequency() {
			return new Frequency(this);
		}

		public static Period operator +(Period T1, Period T2) {
			return new Period(T1.value + T2.value, Period.StoragePrefix, Period.StorageUnit);
		}

		public static Period operator -(Period T1, Period T2) {
			return new Period(T1.value - T2.value, Period.StoragePrefix, Period.StorageUnit);
		}

		public static Period operator *(Period T, float n) {
			return new Period(T.GetValue(Period.StoragePrefix, Period.StorageUnit) * n, Period.StoragePrefix, Period.StorageUnit);
		}

		public static Period operator /(Period T, float n) {
			return new Period(T.GetValue(Period.StoragePrefix, Period.StorageUnit) / n, Period.StoragePrefix, Period.StorageUnit);
		}

		public static float operator /(Period T1, Period T2) {
			return T1.value / T2.value;
		}

		public static bool operator <(Period T1, Period T2) {
			return T1.value < T2.value;
		}

		public static bool operator >(Period T1, Period T2) {
			return T1.value > T2.value;
		}

		public static bool operator ==(Period T1, Period T2) {
			return T1.value == T2.value;
		}

		public static bool operator !=(Period T1, Period T2) {
			return T1.value != T2.value;
		}

		public override bool Equals(object obj) {
			if(obj == null) return false;
			if(!(obj is Period)) return false;
			return this == (obj as Period);
		}

		public override int GetHashCode() {
			return (int)this.value;
		}
	}
}
