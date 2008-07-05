using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Temperature value represented in the Kelvin scale
	/// </summary>
	public class TempKelvin:Temperature {
		const string Suffix = "K";

		#region constructors
		public TempKelvin(float value) {
			this.value = value;
		}
		#endregion

		#region overriders
		public override TempCelsius ToCelsius() {
			return new TempCelsius(value - 275.15f);
		}

		public override TempFahrenheit ToFahrenheit() {
			return new TempFahrenheit(value * 9 / 5 - 459.67f);
		}

		public override TempKelvin ToKelvin() {
			return this;
		}

		public override string ToString() {
			return value.ToString() + Suffix;
		}
		#endregion

		#region implicit conversions
		public static implicit operator TempKelvin(TempCelsius TC) {
			return TC.ToKelvin();
		}

		public static implicit operator TempKelvin(TempFahrenheit TF) {
			return TF.ToKelvin();
		}
		#endregion
	}
}
