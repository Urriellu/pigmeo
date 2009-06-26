// Available constants (the required ones must be defined when compiling each device library):
//#define ConfigBits_FOSC_3bits
//#define ConfigBit_WDT
//#define ConfigBit_IntOscPLL

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
		public static WatchdogStatus WatchdogStatus {
			[InternalImplementation]
			get {
				return WatchdogStatus.Disabled;
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
