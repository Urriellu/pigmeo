using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Temperature value represented in the Fahrenheit scale
	/// </summary>
	public class TempFahrenheit:Temperature {
		const string Suffix = "ºF";

		#region constructors
		public TempFahrenheit(float value) {
			this.value = value;
		}
		#endregion

		#region overriders
		public override TempCelsius ToCelsius() {
			return new TempCelsius((value - 32) * 5 / 9);
		}

		public override TempFahrenheit ToFahrenheit() {
			return this;
		}

		public override TempKelvin ToKelvin() {
			return new TempKelvin((value + 459.67f) * 5 / 9);
		}

		public override string ToString() {
			return value.ToString() + Suffix;
		}
		#endregion

		#region implicit conversions
		public static implicit operator TempFahrenheit(TempCelsius TC) {
			return TC.ToFahrenheit();
		}

		public static implicit operator TempFahrenheit(TempKelvin TK) {
			return TK.ToFahrenheit();
		}
		#endregion
	}
}
