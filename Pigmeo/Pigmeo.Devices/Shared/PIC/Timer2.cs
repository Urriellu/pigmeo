using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Timer2 Module's Register
		/// </summary>
		[AsmName("TMR2"), Location(true)]
		public volatile static byte TMR2 = 0;

		/// <summary>
		/// Timer2 Period Register
		/// </summary>
		[AsmName("PR2"), Location(true)]
		public volatile static byte PR2 = 0xFF;
	}
}