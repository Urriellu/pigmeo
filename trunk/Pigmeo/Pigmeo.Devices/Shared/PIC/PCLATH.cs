using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Write Buffer for the upper 5 bits of the Program Counter
		/// </summary>
		/// <remarks>
		/// The upper byte of the program counter is not directly accessible. PCLATH is a holding register for PC[12:8] whose contents are transferred to the upper byte of the program counter
		/// </remarks>
		[AsmName("PCLATH"), Location(true)]
		public volatile static byte PCLATH = 0;
	}
}