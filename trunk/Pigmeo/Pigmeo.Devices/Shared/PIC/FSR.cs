using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Indirect Data Memory Address Pointer
		/// </summary>
		[AsmName("FSR"), Location(true)]
		public volatile static byte FSR = 0;
	}
}