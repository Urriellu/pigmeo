using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Variable that represents a temperature
	/// </summary>
	public abstract class Temperature {
		/// <summary>
		/// Temperature value
		/// </summary>
		public float value;

		/// <summary>
		/// Converts the current temperature to Degrees Fahrenheit
		/// </summary>
		public abstract TempFahrenheit ToFahrenheit();

		/// <summary>
		/// Converts the current temperature to Degrees Celsius
		/// </summary>
		public abstract TempCelsius ToCelsius();

		/// <summary>
		/// Converts the current temperature to Kelvins
		/// </summary>
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
