// Available constants (the required ones must be defined when compiling each device library):
//#define ConfigBit_FOSC_3bits
//#define ConfigBit_WDT
//#define ConfigBit_PowerUpTimer
//#define ConfigBit_MCLR
//#define ConfigBit_ProgCodeProtect
//#define ConfigBit_BrownOut_2bits_3opt
//#define ConfigBit_BrownOutV_19_25
//#define ConfigBit_IntOscPLL
//#define ConfigBit_VoltRegCap_RA056_Word2

/* Most of configuration bits require 4 groups of code:
 *	1-An enum including all its possible values
 *	2-A local variable in the ConfigBitsAttribute class
 *	3-A parameter in the constructor of ConfigBitsAttribute using the previous enum
 *	4-Inside de constructor: assign the parameter to the local variable
 *	5-A getter property in the ConfigBits so the user can access that setting on run time
*/


using System;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	#region 1-enums
	#if ConfigBit_FOSC_3bits
	/// <summary>
	/// Oscillator type
	/// </summary>
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
		/// <summary>
		/// Watchdog is enabled. The microcontroller will be reset if the watchdog timer overflows
		/// </summary>
		[AsmName("_WDT_ON")]
		Enabled,

		/// <summary>
		/// Watchdog is disabled
		/// </summary>
		[AsmName("_WDT_OFF")]
		Disabled
	}
	#endif

	#if ConfigBit_PowerUpTimer
	/// <summary>
	/// Power-up timer status
	/// </summary>
	public enum PowerUpTimerStatus : byte {
		/// <summary>
		/// Power-up timer is enabled. The microcontroller will wait a few milliseconds before beginning executing its code to avoid unstabilities.
		/// </summary>
		[AsmName("_PWRT_EN")]
		Enabled,

		/// <summary>
		/// Power-up timer is disabled
		/// </summary>
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
	/// Internal oscillator frequency range
	/// </summary>
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

	#if ConfigBit_VoltRegCap_RA056_Word2
	/// <summary>
	/// Voltage regulator external capacitor status
	/// </summary>
	public enum VoltRegCapStatus : byte {
		/// <summary>
		/// External bypass capacitor disabled. This works, but it's not recommended.
		/// </summary>
		[AsmName("_VCAP_DIS"), ConfigWord(2)]
		Disabled,

		/// <summary>
		/// External bypass capacitor used on pin RA0
		/// </summary>
		[AsmName("_VCAP_RA0"), ConfigWord(2)]
		EnabledRA0,

		/// <summary>
		/// External bypass capacitor used on pin RA5
		/// </summary>
		[AsmName("_VCAP_RA5"), ConfigWord(2)]
		EnabledRA5,

		/// <summary>
		/// External bypass capacitor used on pin RA6
		/// </summary>
		[AsmName("_VCAP_RA6"), ConfigWord(2)]
		EnabledRA6
	}
	#endif
	#endregion

	/// <summary>
	/// Configuration Bits: Settings that define the microcontroller's behavious at hardware level so they can't be changed during program execution
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class ConfigBitsAttribute : Attribute {
		#region 2-local variables
		#if ConfigBit_FOSC_3bits
		/// <summary>
		/// Oscillator used with this microcontroller
		/// </summary>
		public readonly OscType Oscillator;
		#endif

		#if ConfigBit_WDT
		/// <summary>
		/// If the watchdog is enabled, the microcontroller will be reset if the watchdog timer overflows. This is used to prevent the program to get locked.
		/// </summary>
		public readonly WatchdogStatus Watchdog;
		#endif

		#if ConfigBit_PowerUpTimer
		/// <summary>
		/// If the power-up timer is enabled the microcontroller will wait a few milliseconds before beginning code execution to avoid unstabilities
		/// </summary>
		public readonly PowerUpTimerStatus PowerUpTimer;
		#endif

		#if ConfigBit_MCLR
		/// <summary>
		/// Master Clear Reset. If enabled, one of the digital input pins will reset the microcontroller when set to low voltage. If disabled, the microcontroller won't be restarted externally, and the MCLR pin can be used for other functions.
		/// </summary>
		public readonly MCLRStatus MCLR;
		#endif

		#if ConfigBit_ProgCodeProtect
		/// <summary>
		/// Program Memory Protection. If enabled, nobody will be able to read/extract the program burnt into the microcontroller.
		/// </summary>
		public readonly ProgCodeProtectStatus ProgCodeProtect;
		#endif

		#if ConfigBit_BrownOut_2bits_3opt
		/// <summary>
		/// Brown-out Reset. If enabled, the microcontroller will be reset if its power voltage goes below a certain threshold.
		/// </summary>
		public readonly BORStatus BOR;
		#endif

		#if ConfigBit_BrownOutV_19_25
		/// <summary>
		/// Threshold voltage at which the microcontroller will be reset.
		/// </summary>
		public readonly BrownOutVoltage BORV;
		#endif

		#if ConfigBit_IntOscPLL
		/// <summary>
		/// Internal oscillator range. If the internal oscillator is not used this setting is ignored.
		/// </summary>
		/// <remarks>
		/// This setting enables or disables the internal oscillator PLL
		/// </remarks>
		public readonly IntOscRange IntOsc;
		#endif

		#if ConfigBit_VoltRegCap_RA056_Word2
		/// <summary>
		/// Enables or disables the voltage regulator external capacitor. When Vdd>3.2V the voltage regulator will drop Vdd to 3.2V (the real voltage this PIC needs). This regulator requires an external 0.1-1uF bypass capacitor for improved stability.
		/// </summary>
		public readonly VoltRegCapStatus VoltRegCap;
		#endif
		#endregion

		/// <summary>
		/// Configuration Bits: Settings that define the microcontroller's behavious at hardware level so they can't be changed during program execution
		/// </summary>
		/// <param name="Oscillator">Oscillator used with this microcontroller</param>
		/// <param name="Watchdog">If the watchdog is enabled, the microcontroller will be reset if the watchdog timer overflows. This is used to prevent the program to get locked.</param>
		/// <param name="PowerUpTimer">If enabled, the power-up timer dalays the initialization of the microcontroller 64ms after being powered on.</param>
		/// <param name="MCLR">MCLR status. Indicate whether the MCLR pin will be used as Master Clear (reset) or as a digital pin.</param>
		/// <param name="ProgCodeProtect">Program Memory Code Protect. If enabled, nobody will be able to read the program</param>
		/// <param name="BrownOutReset">When the Brown-out Reset is enabled, the PIC will be reset if Vdd is lower than a given threshold</param>
		/// <param name="BrownOutVoltage">Voltage threshold at which the PIC restarts</param>
		/// <param name="IntOsc">Enables the internal oscillator PLL. You'll be able to use the higher frequencies of the internal oscillator when the PLL is enabled, and the lower frequencies when it's disabled</param>
		/// <param name="VoltRegCap">Enables or disables the voltage regulator external capacitor. When Vdd>3.2V the voltage regulator will drop Vdd to 3.2V (the real voltage this PIC needs). This regulator requires an external 0.1-1uF bypass capacitor for improved stability.</param>
		public ConfigBitsAttribute(
		#region 3-constructor parameters
			#if ConfigBit_FOSC_3bits
			OscType Oscillator,
			#endif

			#if ConfigBit_WDT
			WatchdogStatus Watchdog,
			#endif

			#if ConfigBit_PowerUpTimer
			PowerUpTimerStatus PowerUpTimer,
			#endif

			#if ConfigBit_MCLR
			MCLRStatus MCLR,
			#endif

			#if ConfigBit_ProgCodeProtect
			ProgCodeProtectStatus ProgCodeProtect,
			#endif

			#if ConfigBit_BrownOut_2bits_3opt
			BORStatus BrownOutReset,
			#endif

			#if ConfigBit_BrownOutV_19_25
			BrownOutVoltage BrownOutVoltage,
			#endif

			#if ConfigBit_IntOscPLL
			IntOscRange IntOsc,
			#endif

			#if ConfigBit_VoltRegCap_RA056_Word2
			VoltRegCapStatus VoltRegCap
			#endif
		#endregion
) {
			
			#region 4-parameter assignations
			#if ConfigBit_FOSC_3bits
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

			#if ConfigBit_VoltRegCap_RA056_Word2
			this.VoltRegCap=VoltRegCap;
			#endif
			#endregion
		}
	}


	/// <summary>
	/// Allows reading configuration bits at run time
	/// </summary>
	public static class ConfigBits {
		#region 5-Getter properties
		#if ConfigBit_FOSC_3bits
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

		#if ConfigBit_VoltRegCap_RA056_Word2
		/// <summary>
		/// Enables or disables the voltage regulator external capacitor. When Vdd>3.2V the voltage regulator will drop Vdd to 3.2V (the real voltage this PIC needs). This regulator requires an external 0.1-1uF bypass capacitor for improved stability.
		/// </summary>
		public static VoltRegCapStatus VoltRegCap {
			[InternalImplementation]
			get {
				return VoltRegCapStatus.Disabled;
			}
		}
		#endif
		#endregion
	}
}
