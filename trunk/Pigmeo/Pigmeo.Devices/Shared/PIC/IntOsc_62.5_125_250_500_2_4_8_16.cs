using System;

namespace Pigmeo.MCU {
	public enum IntOscFreq {
		/// <summary>
		/// 62.5kHz. PLL must be disabled
		/// </summary>
		_62_5kHz,
		_125kHz,
		_250kHz,
		_500kHz,
		_2MHz,
		_4MHz,
		_8MHz,
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
			if (ConfigBits.PLLEnable) {
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
						throw new Exception("PLL must be disabled in the config bits for using the lower frequencies of the internal oscillator");
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
						throw new Exception("PLL must be enabled in the config bits for using the highest frequencies of the internal oscillator");
				}
			}
		}
	}
}
