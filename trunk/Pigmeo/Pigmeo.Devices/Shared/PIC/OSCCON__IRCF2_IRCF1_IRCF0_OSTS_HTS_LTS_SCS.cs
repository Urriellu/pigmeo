using Pigmeo.Extensions;
using Pigmeo.Internal.PIC;

namespace Pigmeo.Internal {
	/// <summary>
	/// Controls the system clock and frequency selection options
	/// </summary>
	public struct OSCCON {
		public OSCCON(byte value) {
			_OSCCON = value;
		}

		[AsmName("OSCCON"), Location(true)]
		public volatile static byte _OSCCON = 0x68;

		/// <summary>Internal Oscillator Frequency Select bits. IRCF=7: 8MHz, IRCF=6: 4MHz (default), IRCF=5: 2MHz, IRCF=4: 1MHz, IRCF=3: 500kHz, IRCF=2: 250kHz, IRCF=1: 125kHz, IRCF=0: 31kHz(LFINTOSC)</summary>
		public byte IRCF {
			get {
				return new UInt3(IRCF2, IRCF1, IRCF0); //implicit conversion to Byte
			}
			set {
				_OSCCON.SetBit(0, value.GetBit(0));
				_OSCCON.SetBit(1, value.GetBit(1));
				_OSCCON.SetBit(2, value.GetBit(2));
			}
		}

		/// <summary>Internal Oscillator Frequency Select bit 2. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
		public bool IRCF2 {
			get { return _OSCCON.GetBit(6); }
			set { _OSCCON = _OSCCON.SetBit(6, value); }
		}

		/// <summary>Internal Oscillator Frequency Select bit 1. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
		public bool IRCF1 {
			get { return _OSCCON.GetBit(5); }
			set { _OSCCON = _OSCCON.SetBit(5, value); }
		}

		/// <summary>Internal Oscillator Frequency Select bit 0. IRCFx: 111=8MHz, 110=4MHz (default), 101=2MHz, 100=1MHz, 011=500kHz, 010=250kHz, 001=125kHz, 000=31kHz(LFINTOSC)</summary>
		public bool IRCF0 {
			get { return _OSCCON.GetBit(4); }
			set { _OSCCON = _OSCCON.SetBit(4, value); }
		}

		/// <summary>Oscillator Start-up Time-out Status bit. true=Device is running from the external clock defined by FOSC[2:0] of the CONFIG1 register. false=Device is running from the internal oscillator (HFINTOSC or LFINTOSC)</summary>
		/// <remarks>Bit resets to false with Two-Speed Start-up and LP, XT or HS selected as the Oscillator mode or Fail-Safe mode is enabled</remarks>
		public bool OSTS {
			get { return _OSCCON.GetBit(3); }
		}

		/// <summary>HFINTOSC Stable bit (High Frequency: 8 MHz to 125 kHz). true=HFINTOSC is stable. false=HFINTOSC is not stable</summary>
		public bool HTS {
			get { return _OSCCON.GetBit(2); }
		}

		/// <summary>LFINTOSC Stable bit (Low Frequency: 31 kHz). true=LFINTOSC is stable. false=LFINTOSC is not stable</summary>
		public bool LTS {
			get { return _OSCCON.GetBit(1); }
		}

		/// <summary>System Clock Select bit. true=Internal oscillator is used for system clock. false=Clock source defined by FOSC[2:0] of the CONFIG1 register</summary>
		public bool SCS {
			get { return _OSCCON.GetBit(0); }
			set { _OSCCON = _OSCCON.SetBit(0, value); }
		}

		public static implicit operator OSCCON(byte value) {
			return new OSCCON(value);
		}
	}
}

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Controls the system clock and frequency selection options
		/// </summary>
		public static Pigmeo.Internal.OSCCON OSCCON = new Pigmeo.Internal.OSCCON();
	}

	/*public static partial class Registers {
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
	}*/
}