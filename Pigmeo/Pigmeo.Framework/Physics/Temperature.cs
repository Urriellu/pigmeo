using System;

namespace Pigmeo.Physics {
	public abstract class Temperature {
		public float value;

		public abstract TempFahrenheit ToFahrenheit();
		public abstract TempCelsius ToCelsius();
		public abstract TempKelvin ToKelvin();

		/// <summary>
		/// Returns a string representing the current value in the given temperature scale
		/// </summary>
		public string ToString(TempUnits TempUnit) {
			switch(TempUnit) {
				case TempUnits.Celsius:
					return this.ToCelsius().ToString();
				case TempUnits.Fahrenheit:
					return this.ToFahrenheit().ToString();
				default:
					throw new NotSupportedException("Unit temperature " + TempUnit.ToString() + " not supported yet");
			}
		}
	}
}
