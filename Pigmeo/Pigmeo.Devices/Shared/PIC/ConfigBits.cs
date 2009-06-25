using System;
using Pigmeo.Internal;

namespace Pigmeo.MCU {
	/// <summary>
	/// Configuration Bits. These are settings burnt into the PIC's program memory, so they must be defined at development time, and cannot be changed later in the program
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class ConfigBitsAttribute : Attribute {
		#if ConfigBit_PLLEN_bit12
		public readonly bool PLLEnable;
		#endif

		public ConfigBitsAttribute (
			#if ConfigBit_PLLEN_bit12
			/// <summary>
			/// Enables the internal oscillator PLL. You'll be able to use the higher frequencies of the internal oscillator when the PLL is enabled, and the lower frequencies when it's disabled
			/// </summary>
			bool PLLEnable
			#endif
			) {
			
			#if ConfigBit_PLLEN_bit12
			this.PLLEnable=PLLEnable;
			#endif
		}
	}


	/// <summary>
	/// Allows reading configuratino bits on run time
	/// </summary>
	public static class ConfigBits {
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
