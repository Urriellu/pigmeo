using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Temperature value represented in the Celsius scale
	/// </summary>
	public class TempCelsius:Temperature {
		const string Suffix = "ºC";

		#region constructors
		public TempCelsius(float value) {
			this.value = value;
		}
		#endregion

		#region overriders
		public override TempCelsius ToCelsius() {
			return this;
		}

		public override TempFahrenheit ToFahrenheit() {
			return new TempFahrenheit(value * 9 / 5 + 32);
		}

		public override TempKelvin ToKelvin() {
			return new TempKelvin(value + 273.15f);
		}

		public override string ToString() {
			return value.ToString() + Suffix;
		}
		#endregion

		#region implicit conversions
		public static implicit operator TempCelsius(TempFahrenheit TF) {
			return TF.ToCelsius();
		}

		public static implicit operator TempCelsius(TempKelvin TK) {
			return TK.ToCelsius();
		}
		#endregion
	}
}
