using System;
using Pigmeo.Internal;

/* Available constants (the required ones must be defined when compiling each device library):
 * ConfigBits_FOSC_bits20
 * ConfigBit_WDT_bit3
 * ConfigBit_PLLEN_bit12
*/

namespace Pigmeo.MCU {
	#if ConfigBits_FOSC_bits20
	public enum OscType:byte {
		/// <summary>
		/// Low-power crystal on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		LP,

		/// <summary>
		/// Crystal/resonator on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		XT,
		
		/// <summary>
		/// High-speed crystal/resonator on OSC2/CLKOUT and OSC1/CLKIN
		/// </summary>
		HS,

		/// <summary>
		/// Externally generated clock. I/O function on OSC2/CLKOUT pin, CLKIN on OSC1/CLKIN
		/// </summary>
		EC,

		/// <summary>
		/// Internal oscillator: I/O function on OSC2/CLKOUT pin, I/O function on OSC1/CLKIN
		/// </summary>
		INTOSCIO,
		
		/// <summary>
		/// Internal oscillator: CLKOUT function on OSC2/CLKOUT pin, I/O function on OSC1/CLKIN
		/// </summary>
		INTOSC,
		
		/// <summary>
		/// RC oscillator: I/O function on OSC2/CLKOUT pin, RC on OSC1/CLKIN
		/// </summary>
		RCIO,

		/// <summary>
		/// RC oscillator: CLKOUT function on OSC2/CLKOUT pin, RC on OSC1/CLKIN
		/// </summary>
		RC
	}
	#endif

	/// <summary>
	/// Configuration Bits. These are settings burnt into the PIC's program memory, so they must be defined at development time, and cannot be changed later in the program
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class ConfigBitsAttribute : Attribute {
		#if ConfigBits_FOSC_bits20
		public readonly OscType Oscillator;
		#endif

		#if ConfigBit_WDT_bit3
		public readonly bool Watchdog;
		#endif

		#if ConfigBit_PLLEN_bit12
		public readonly bool PLLEnable;
		#endif

		public ConfigBitsAttribute (
			#if ConfigBits_FOSC_bits20
			/// <summary>
			/// Oscillator type
			/// </summary>
			OscType Oscillator,
			#endif

			#if ConfigBit_WDT_bit3
			/// <summary>
			/// Enable Watchdog timer
			/// </summary>
			bool Watchdog,
			#endif

			#if ConfigBit_PLLEN_bit12
			/// <summary>
			/// Enables the internal oscillator PLL. You'll be able to use the higher frequencies of the internal oscillator when the PLL is enabled, and the lower frequencies when it's disabled
			/// </summary>
			bool PLLEnable
			#endif
			) {
			
			#if ConfigBits_FOSC_bits20
			this.Oscillator=Oscillator;
			#endif

			#if ConfigBit_WDT_bit3
			this.Watchdog=Watchdog;
			#endif

			#if ConfigBit_PLLEN_bit12
			this.PLLEnable=PLLEnable;
			#endif
		}
	}


	/// <summary>
	/// Allows reading configuratino bits on run time
	/// </summary>
	public static class ConfigBits {
		#if ConfigBits_FOSC_bits20
		/// <summary>
		/// Oscillator type
		/// </summary>
		public static OscType Oscillator {
			[InternalImplementation]
			get {
				return OscType.INTOSC;
			}
		}
		#endif

		#if ConfigBit_WDT_bit3
		/// <summary>
		/// Watchdog Timer enabled
		/// </summary>
		public static bool Watchdog {
			[InternalImplementation]
			get {
				return false;
			}
		}
		#endif

		#if ConfigBit_PLLEN_bit12
		/// <summary>
		/// Enables the internal oscillator PLL. You'll be able to use the higher frequencies of the internal oscillator when the PLL is enabled, and the lower frequencies when it's disabled
		/// </summary>
		public static bool PLLEnable {
			[InternalImplementation]
			get {
				return false;
			}
		}
		#endif
	}
}
