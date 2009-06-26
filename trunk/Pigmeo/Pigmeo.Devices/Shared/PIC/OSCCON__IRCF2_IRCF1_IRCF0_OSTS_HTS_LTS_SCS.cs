using Pigmeo.Extensions;
using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Controls the system clock and frequency selection options
		/// </summary>
		public static class OSCCON {
			/// <summary>Internal Oscillator Frequency Select bit 2. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
			[AsmName("IRCF2"), Location(true)]
			public volatile static bool IRCF2 = true;

			/// <summary>Internal Oscillator Frequency Select bit 1. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
			[AsmName("IRCF1"), Location(true)]
			public volatile static bool IRCF1 = true;

			/// <summary>Internal Oscillator Frequency Select bit 0. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
			[AsmName("IRCF0"), Location(true)]
			public volatile static bool IRCF0 = false;

			/// <summary>Oscillator Start-up Time-out Status bit. true=Device is running from the external clock defined by FOSC[2:0] of the CONFIG1 register. false=Device is running from the internal oscillator (HFINTOSC or LFINTOSC)</summary>
			/// <remarks>Bit resets to false with Two-Speed Start-up and LP, XT or HS selected as the Oscillator mode or Fail-Safe mode is enabled</remarks>
			[AsmName("OSTS"), Location(true)]
			public volatile static bool OSTS = true;

			/// <summary>HFINTOSC Stable bit (High Frequency: 8 MHz to 125 kHz). true=HFINTOSC is stable. false=HFINTOSC is not stable</summary>
			[AsmName("HTS"), Location(true)]
			public volatile static bool HTS = false;

			/// <summary>LFINTOSC Stable bit (Low Frequency: 31 kHz). true=LFINTOSC is stable. false=LFINTOSC is not stable</summary>
			[AsmName("LTS"), Location(true)]
			public volatile static bool LTS = false;

			/// <summary>System Clock Select bit. true=Internal oscillator is used for system clock. false=Clock source defined by FOSC[2:0] of the CONFIG1 register</summary>
			[AsmName("SCS"), Location(true)]
			public volatile static bool SCS = false;
		}
	}
}