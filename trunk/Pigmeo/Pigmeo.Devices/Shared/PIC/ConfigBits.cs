﻿// Available constants (the required ones must be defined when compiling each device library):
//#define ConfigBits_FOSC_3bits
//#define ConfigBit_WDT
//#define ConfigBit_IntOscPLL
//#define ConfigBit_PowerUpTimer
//#define ConfigBit_MCLR
//#define ConfigBit_ProgCodeProtect
//#define ConfigBit_BrownOut_2bits_3opt
//#define ConfigBit_BrownOutV_19_25

/* Most of configuration bits require 4 groups of code:
 *	1-An enum including all its possible values
 *	2-A local variable in the ConfigBitsAttribute class
 *	3-A parameter in the constructor of ConfigBitsAttribute using the previous enum
 *	4-Inside de constructor: assign the parameter to the local variable
 *	5-A getter property in the ConfigBits so the user can access that setting on run time
*/


using System;
using Pigmeo.Internal;

namespace Pigmeo.MCU {
	#region 1-enums
	#if ConfigBits_FOSC_3bits
	public enum OscType:byte {
		/// <summary>
		/// Low-power crystal on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		[AsmName("_LP_OSC")]
		LP,

		/// <summary>
		/// Crystal/resonator on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		[AsmName("_XT_OSC")]
		XT,
		
		/// <summary>
		/// High-speed crystal/resonator on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		[AsmName("_HS_OSC")]
		HS,

		/// <summary>
		/// Externally generated clock. I/O function on OSC2/CLKOUT pin, CLKIN on OSC1/CLKIN
		/// </summary>
		[AsmName("_EC_OSC")]
		EC,

		/// <summary>
		/// Internal oscillator: I/O function on OSC2/CLKOUT pin, I/O function on OSC1/CLKIN
		/// </summary>
		[AsmName("_INTOSCIO")]
		IntOscIO,
		
		/// <summary>
		/// Internal oscillator: CLKOUT function on OSC2/CLKOUT pin, I/O function on OSC1/CLKIN
		/// </summary>
		[AsmName("_INTOSC")]
		IntOsc,
		
		/// <summary>
		/// External RC oscillator: I/O function on OSC2/CLKOUT pin, RC on OSC1/CLKIN
		/// </summary>
		[AsmName("_EXTRCIO")]
		RCIO,

		/// <summary>
		/// External RC oscillator: CLKOUT function on OSC2/CLKOUT pin, RC on OSC1/CLKIN
		/// </summary>
		[AsmName("_EXTRC")]
		RC
	}
	#endif

	#if ConfigBit_WDT
	/// <summary>
	/// Watchdog Timer Status
	/// </summary>
	public enum WatchdogStatus:byte {
		[AsmName("_WDT_ON")]
		Enabled,
		[AsmName("_WDT_OFF")]
		Disabled
	}
	#endif

	#if ConfigBit_PowerUpTimer
	public enum PowerUpTimerStatus : byte {
		[AsmName("_PWRT_EN")]
		Enabled,
		[AsmName("_PWRT_DIS")]
		Disabled
	}
	#endif

	#if ConfigBit_MCLR
	/// <summary>
	/// Master Clear (reset pin) status
	/// </summary>
	public enum MCLRStatus:byte{
		/// <summary>
		/// Master clear enabled. The PIC will reset when the MCLR pin is set to 0V
		/// </summary>
		[AsmName("_MCLR_EN")]
		Enabled,
		/// <summary>
		/// Master clear disabled. MCLR pin is used as a digital pin
		/// </summary>
		[AsmName("_MCLR_DIS")]
		Disabled
	}
	#endif

	#if ConfigBit_ProgCodeProtect
	/// <summary>
	/// Program memory code protection status
	/// </summary>
	public enum ProgCodeProtectStatus:byte {
		/// <summary>
		/// Program memory can't be read
		/// </summary>
		[AsmName("_CP_ON")]
		Enabled,
		/// <summary>
		/// Program memory can be read and written
		/// </summary>
		[AsmName("_CP_OFF")]
		Disabled
	}
	#endif

	#if ConfigBit_BrownOut_2bits_3opt
	/// <summary>
	/// Brown-out Reset status
	/// </summary>
	public enum BORStatus:byte {
		/// <summary>
		/// Brown-out Reset is always enabled
		/// </summary>
		[AsmName("_BOR_ON")]
		Enabled,
		/// <summary>
		/// Brown-out Reset enabled during operation and disabled in Sleep
		/// </summary>
		[AsmName("_BOR_NSLEEP")]
		EnabledButSleepDisabled,
		/// <summary>
		/// Brown-out Reset disabled
		/// </summary>
		[AsmName("_BOR_OFF")]
		Disabled
	}
	#endif

	#if ConfigBit_BrownOutV_19_25
	/// <summary>
	/// Brown-out Voltage
	/// </summary>
	public enum BrownOutVoltage:byte{
		/// <summary>
		/// If Vdd is below 1.9V the PIC will be reset
		/// </summary>
		[AsmName("_BORV_1_9")]
		_1_9,
		/// <summary>
		/// If Vdd is below 2.5V the PIC will be reset
		/// </summary>
		[AsmName("_BORV_2_5")]
		_2_5
	}
	#endif

	#if ConfigBit_IntOscPLL
	/// <summary>
	/// Internal oscillator frequency range. If the internal oscillator is not used this setting is ignored
	/// </summary>
	/// <remarks>
	/// This setting enables or disables the internal oscillator PLL
	/// </remarks>
	public enum IntOscRange:byte {
		/// <summary>
		/// Internal oscillator set to its highest frequencies
		/// </summary>
		[AsmName("_PLL_EN")]
		HighFreqs,

		/// <summary>
		/// Internal oscillator set to its lowest frequencies
		/// </summary>
		[AsmName("_PLL_DIS")]
		LowFreqs
	}
	#endif
	#endregion

	/// <summary>
	/// Configuration Bits. These are settings burnt into the PIC's program memory, so they must be defined at development time, and cannot be changed later in the program
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class ConfigBitsAttribute : Attribute {
		#region 2-local variables
		#if ConfigBits_FOSC_3bits
		public readonly OscType Oscillator;
		#endif

		#if ConfigBit_WDT
		public readonly WatchdogStatus Watchdog;
		#endif

		#if ConfigBit_PowerUpTimer
		public readonly PowerUpTimerStatus PowerUpTimer;
		#endif

		#if ConfigBit_MCLR
		public readonly MCLRStatus MCLR;
		#endif

		#if ConfigBit_ProgCodeProtect
		public readonly ProgCodeProtectStatus ProgCodeProtect;
		#endif

		#if ConfigBit_BrownOut_2bits_3opt
		public readonly BORStatus BOR;
		#endif

		#if ConfigBit_BrownOutV_19_25
		public readonly BrownOutVoltage BORV;
		#endif

		#if ConfigBit_IntOscPLL
		public readonly IntOscRange IntOsc;
		#endif
		#endregion

		public ConfigBitsAttribute(
		#region 3-constructor parameters
			#if ConfigBits_FOSC_3bits
			/// <summary>
			/// Oscillator type
			/// </summary>
			OscType Oscillator,
			#endif

			#if ConfigBit_WDT_bit3
			/// <summary>
			/// Enable Watchdog timer
			/// </summary>
			WatchdogStatus Watchdog,
			#endif

			#if ConfigBit_PowerUpTimer
			/// <summary>
			/// If enabled, the power-up timer dalays the initialization of the microcontroller 64ms after being powered on
			/// </summary>
			PowerUpTimerStatus PowerUpTimer,
			#endif

			#if ConfigBit_MCLR
			/// <summary>
			/// MCLR status. Indicate whether the MCLR pin will be used as Master Clear (reset) or as a digital pin 
			/// </summary>
			MCLRStatus MCLR,
			#endif

			#if ConfigBit_ProgCodeProtect
			/// <summary>
			/// Program Memory Code Protect. If enabled, nobody will be able to read the program
			/// </summary>
			ProgCodeProtectStatus ProgCodeProtect,
			#endif

			#if ConfigBit_BrownOut_2bits_3opt
			/// <summary>
			/// When the Brown-out Reset is enabled, the PIC will be reset if Vdd is lower than a given threshold
			/// </summary>
			BORStatus BrownOutReset,
			#endif

			#if ConfigBit_BrownOutV_19_25
			/// <summary>
			/// Voltage threshold at which the PIC restarts
			/// </summary>
			BrownOutVoltage BrownOutVoltage,
			#endif

			#if ConfigBit_IntOscPLL
			/// <summary>
			/// Enables the internal oscillator PLL. You'll be able to use the higher frequencies of the internal oscillator when the PLL is enabled, and the lower frequencies when it's disabled
			/// </summary>
			IntOscRange IntOsc
			#endif
		#endregion
) {
			
			#region 4-parameter assignations
			#if ConfigBits_FOSC_3bits
			this.Oscillator=Oscillator;
			#endif

			#if ConfigBit_WDT
			this.Watchdog=Watchdog;
			#endif

			#if ConfigBit_PowerUpTimer
			this.PowerUpTimer=PowerUpTimer;
			#endif

			#if ConfigBit_MCLR
			this.MCLR=MCLR;
			#endif

			#if ConfigBit_ProgCodeProtect
			this.ProgCodeProtect=ProgCodeProtect;
			#endif

			#if ConfigBit_BrownOut_2bits_3opt
			this.BOR=BrownOutReset;
			#endif

			#if ConfigBit_BrownOutV_19_25
			this.BORV=BrownOutVoltage;
			#endif

			#if ConfigBit_IntOscPLL
			this.IntOsc=IntOsc;
			#endif
			#endregion
		}
	}


	/// <summary>
	/// Allows reading configuratino bits on run time
	/// </summary>
	public static class ConfigBits {
		#region 5-Getter properties
		#if ConfigBits_FOSC_3bits
		/// <summary>
		/// Oscillator type
		/// </summary>
		public static OscType OscillatorType {
			[InternalImplementation]
			get {
				return OscType.IntOsc;
			}
		}
		#endif

		#if ConfigBit_WDT
		/// <summary>
		/// Watchdog Timer enabled
		/// </summary>
		public static WatchdogStatus Watchdog {
			[InternalImplementation]
			get {
				return WatchdogStatus.Disabled;
			}
		}
		#endif

		#if ConfigBit_PowerUpTimer
		/// <summary>
		/// If enabled, the power-up timer dalays the initialization of the microcontroller 64ms after being powered on
		/// </summary>
		public static PowerUpTimerStatus PowerUpTimer {
			[InternalImplementation]
			get{
				return PowerUpTimerStatus.Disabled;
			}
		}
		#endif

		#if ConfigBit_MCLR
		/// <summary>
		/// MCLR status. Indicate whether the MCLR pin is used as Master Clear (reset) or as a digital pin 
		/// </summary>
		public static MCLRStatus MCLR {
			[InternalImplementation]
			get{
				return MCLRStatus.Disabled;
			}
		}
		#endif

		#if ConfigBit_ProgCodeProtect
		/// <summary>
		/// Program Memory Code Protect. If enabled, the program cannot be read
		/// </summary>
		public static ProgCodeProtectStatus ProgCodeProtect {
			[InternalImplementation]
			get{
				return ProgCodeProtectStatus.Disabled;
			}
		}
		#endif

		#if ConfigBit_BrownOut_2bits_3opt || ConfigBit_BrownOut_2bits_4opt
		/// <summary>
		/// When the Brown-out Reset is enabled, the PIC will be reset if Vdd is lower than a given threshold
		/// </summary>
		public static BORStatus BrownOutReset {
			[InternalImplementation]
			get{
				return BORStatus.Disabled;
			}
		}
		#endif

		#if ConfigBit_BrownOutV_19_25
		/// <summary>
		/// Voltage threshold at which the PIC restarts
		/// </summary>
		public static BrownOutVoltage BrownOutVoltage {
			[InternalImplementation]
			get{
				return BrownOutVoltage._1_9;
			}
		}
		#endif

		#if ConfigBit_IntOscPLL
		/// <summary>
		/// Internal oscillator frequency range. If the internal oscillator is not used this setting is ignored
		/// </summary>
		public static IntOscRange IntOscRange {
			[InternalImplementation]
			get {
				return IntOscRange.HighFreqs;
			}
		}
		#endif
		#endregion
	}
}
