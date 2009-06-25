using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Controls the system clock and frequency selection options
		/// </summary>
		public static class OSCCON {
			/// <summary>Internal Oscillator Frequency Select bit 1. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
			[AsmName("IRCF1"), Location(true)]
			public volatile static bool IRCF1 = true;

			/// <summary>Internal Oscillator Frequency Select bit 0. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
			[AsmName("IRCF0"), Location(true)]
			public volatile static bool IRCF0 = false;

			/// <summary>Internal Clock Oscillator Status Locked bit (2% Stable)</summary>
			[AsmName("ICSL"), Location(true)]
			public static readonly bool ICSL = true;

			/// <summary>Internal Clock Oscillator Status Stable bit (0.5% Stable)</summary>
			[AsmName("ICSS"), Location(true)]
			public static readonly bool ICSS = true;
		}
	}
}