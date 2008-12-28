using System;

namespace Pigmeo.Physics {
	/// <summary>
	/// Units in which frequency is measured
	/// </summary>
	public enum FrequencyUnits {
		/// <summary>
		/// Hertzs. International System of Units
		/// </summary>
		Hz,
		/// <summary>
		/// Cycles per second. The same as Hertzs
		/// </summary>
		cps,
		/// <summary>
		/// Beats per minute. Used in heart rate and musical tempo
		/// </summary>
		BPM,
		/// <summary>
		/// Revolutions per minute
		/// </summary>
		rpm
	}

	/// <summary>
	/// Units in which frequency is measured. International System of Units
	/// </summary>
	public enum FrequencyUnitsSI {
		/// <summary>
		/// Yoktohertz. 10^-24 Hz
		/// </summary>
		yHz,
		/// <summary>
		/// Zeptohertz. 10^-21 Hz
		/// </summary>
		zHz,
		/// <summary>
		/// Attohertz. 10^-18 Hz
		/// </summary>
		aHz,
		/// <summary>
		/// Femtohertz. 10^-15 Hz
		/// </summary>
		fHz,
		/// <summary>
		/// Picohertz. 10^-12 Hz
		/// </summary>
		pHz,
		/// <summary>
		/// Nanohertz. 10^-9 Hz
		/// </summary>
		nHz,
		/// <summary>
		/// Microhertz. 10^-6 Hz
		/// </summary>
		µHz,
		/// <summary>
		/// Millihertz. 10^-3 Hz
		/// </summary>
		mHz,
		/// <summary>
		/// Centihertz. 10^-2 Hz
		/// </summary>
		cHz,
		/// <summary>
		/// Decihertz. 10^-1 Hz
		/// </summary>
		dHz,
		/// <summary>
		/// Hertz. 1 Hz
		/// </summary>
		Hz,
		/// <summary>
		/// Dekahertz. 10^1 Hz
		/// </summary>
		daHz,
		/// <summary>
		/// Hektohertz. 10^2 Hz
		/// </summary>
		hHz,
		/// <summary>
		/// Kilohertz. 10^3 Hz
		/// </summary>
		kHz,
		/// <summary>
		/// Megahertz. 10^6 Hz
		/// </summary>
		MHz,
		/// <summary>
		/// Gigahertz. 10^9 Hz
		/// </summary>
		GHz,
		/// <summary>
		/// Terahertz. 10^12 Hz
		/// </summary>
		THz,
		/// <summary>
		/// Petahertz. 10^15 Hz
		/// </summary>
		PHz,
		/// <summary>
		/// Exahertz. 10^18 Hz
		/// </summary>
		EHz,
		/// <summary>
		/// Zettahertz. 10^21 Hz
		/// </summary>
		ZHz,
		/// <summary>
		/// Yottahertz. 10^24 Hz
		/// </summary>
		YHz
	}
}
