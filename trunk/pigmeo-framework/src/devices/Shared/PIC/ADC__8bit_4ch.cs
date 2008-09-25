using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// A/D Control Register 1
		/// </summary>
		public static class ADCON1 {
			/// <summary>
			/// A/D Port Configuration Control bit 2
			/// </summary>
			[AsmName("PCFG2"), Location(true)]
			public volatile static bool PCFG2 = false;

			/// <summary>
			/// A/D Port Configuration Control bit 1
			/// </summary>
			[AsmName("PCFG1"), Location(true)]
			public volatile static bool PCFG1 = false;

			/// <summary>
			/// A/D Port Configuration Control bit 0
			/// </summary>
			[AsmName("PCFG0"), Location(true)]
			public volatile static bool PCFG0 = false;
		}
	}
}