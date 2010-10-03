using Pigmeo.Physics;

namespace Pigmeo {
	/// <summary>
	/// Timer that executes an event periodically
	/// </summary>
	public interface ITimerInterrupts:ITimer {
		/// <summary>
		/// Configures a timer (without interrupts and internal clock source)
		/// </summary>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqPrefix">Prefix to the units in which oscillator frequency is measured</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured</param>
		/// <param name="Period">Period of timer overflow/flag/interrupt. Time elapsed between two consecutive timer overflows/flags/interrupts</param>
		/// <param name="PerPrefix">Prefix to the units in which the period is measured</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		void Configure(float frequency, SIPrefixes FreqPrefix, FrequencyUnits FreqUnit, float Period, SIPrefixes PerPrefix, TimeUnits PeriodUnit);
	}
}
