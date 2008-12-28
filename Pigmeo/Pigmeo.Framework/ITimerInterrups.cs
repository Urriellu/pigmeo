using Pigmeo.Physics;

namespace Pigmeo {
	/// <summary>
	/// Timer that executes an event periodically
	/// </summary>
	public interface ITimerInterrupts:ITimer {
		void Configure(float frequency, SIPrefixes FreqPrefix, FrequencyUnits FreqUnit, float Period, SIPrefixes PerPrefix, TimeUnits PeriodUnit);
	}
}
