using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// The Power Control (PCON) register contains a flag bit to allow differentiation between a Power-on Reset (POR) to an external MCLR Reset or WDT Reset. These devices contain an additional bit to differentiate a Brown-out Reset condition from a Power-on Reset condition
		/// </summary>
		public static class PCON {
			/// <summary>
			/// Power-on Reset Status bit. INVERTED. true = No Power-on Reset occurred. false = A Power-on Reset occurred (must be set in software after a Power-on Reset occurs)
			/// </summary>
			[AsmName("NOT_POR"), Location(true)]
			public volatile static bool _POR = false;

			/// <summary>
			/// Brown-out Reset Status bit. INVERTED. true = No Brown-out Reset occurred. false = A Brown-out Reset occurred (must be set in software after a Brown-out Reset occurs)
			/// </summary>
			[AsmName("NOT_BOR"), Location(true)]
			public volatile static bool _BOR = false;
		}
	}
}