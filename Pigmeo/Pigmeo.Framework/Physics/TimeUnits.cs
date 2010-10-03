namespace Pigmeo.Physics {
	/// <summary>
	/// Units in which time is measured
	/// </summary>
	public enum TimeUnits {
		/// <summary>
		/// Second
		/// </summary>
		second,

		/// <summary>
		/// Minute
		/// </summary>
		minute,

		/// <summary>
		/// Hour
		/// </summary>
		hour,
	}

	/// <summary>
	/// Units in which time is measured. International System of Units
	/// </summary>
	public enum TimeUnitsSI {
		/// <summary>
		/// Yoctosecond. 10^-23 seconds
		/// </summary>
		ys,
		/// <summary>
		/// Zeptosecond. 10^-21 seconds
		/// </summary>
		zs,
		/// <summary>
		/// Attoosecond. 10^-18 seconds
		/// </summary>
		/// <remarks>
		/// "as" is a special keyword
		/// </remarks>
		attos,
		/// <summary>
		/// Femtosecond. 10^-15 seconds
		/// </summary>
		fs,
		/// <summary>
		/// Picosecond. 10^-12 seconds
		/// </summary>
		ps,
		/// <summary>
		/// Nanosecond. 10^-9 seconds
		/// </summary>
		ns,
		/// <summary>
		/// Microsecond. 10^-6 seconds
		/// </summary>
		µs,
		/// <summary>
		/// Millisecond. 10^-3 seconds
		/// </summary>
		ms,
		/// <summary>
		/// Centisecond. 10^-2 seconds
		/// </summary>
		cs,
		/// <summary>
		/// Decisecond. 10^-1 seconds
		/// </summary>
		ds,
		/// <summary>
		/// Second
		/// </summary>
		s
	}
}
