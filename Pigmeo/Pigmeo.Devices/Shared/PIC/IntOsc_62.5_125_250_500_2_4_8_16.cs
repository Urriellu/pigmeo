using System;

namespace Pigmeo.MCU {
	/// <summary>
	/// Internal oscillator frequency
	/// </summary>
	public enum IntOscFreq:byte {
		/// <summary>
		/// 62.5kHz. PLL must be disabled
		/// </summary>
		_62_5kHz,

		/// <summary>
		/// 125kHz. PLL must be disabled
		/// </summary>
		_125kHz,

		/// <summary>
		/// 250kHz. PLL must be disabled
		/// </summary>
		_250kHz,

		/// <summary>
		/// 500kHz. PLL must be disabled
		/// </summary>
		_500kHz,

		/// <summary>
		/// 2MHz. PLL must be enabled
		/// </summary>
		_2MHz,

		/// <summary>
		/// 4MHz. PLL must be enabled
		/// </summary>
		_4MHz,

		/// <summary>
		/// 8MHz. PLL must be enabled
		/// </summary>
		_8MHz,

		/// <summary>
		/// 16MHz. PLL must be enabled
		/// </summary>
		_16MHz
	}

	/// <summary>
	/// Internall Oscillator
	/// </summary>
	public static class IntOsc {
		/// <summary>
		/// Set the internal oscillator to the specified frequency.
		/// </summary>
		/// <param name="Freq"></param>
		public static void Setup(IntOscFreq Freq) {
			if (ConfigBits.IntOscRange == IntOscRange.HighFreqs) {
				switch (Freq) {
					case IntOscFreq._16MHz:
						Registers.OSCCON.IRCF1 = true;
						Registers.OSCCON.IRCF0 = true;
						break;
					case IntOscFreq._8MHz:
						Registers.OSCCON.IRCF1 = true;
						Registers.OSCCON.IRCF0 = false;
						break;
					case IntOscFreq._4MHz:
						Registers.OSCCON.IRCF1 = false;
						Registers.OSCCON.IRCF0 = true;
						break;
					case IntOscFreq._2MHz:
						Registers.OSCCON.IRCF1 = false;
						Registers.OSCCON.IRCF0 = false;
						break;
					default:
						throw new Exception("You have to set the internal oscillator range to its highest frequencies (in the configuration bits/words)");
				}
			} else {
				switch (Freq) {
					case IntOscFreq._500kHz:
						Registers.OSCCON.IRCF1 = true;
						Registers.OSCCON.IRCF0 = true;
						break;
					case IntOscFreq._250kHz:
						Registers.OSCCON.IRCF1 = true;
						Registers.OSCCON.IRCF0 = false;
						break;
					case IntOscFreq._125kHz:
						Registers.OSCCON.IRCF1 = false;
						Registers.OSCCON.IRCF0 = true;
						break;
					case IntOscFreq._62_5kHz:
						Registers.OSCCON.IRCF1 = false;
						Registers.OSCCON.IRCF0 = false;
						break;
					default:
						throw new Exception("You have to set the internal oscillator range to its lowest frequencies (in the configuration bits/words)");
				}
			}
		}
	}
}
