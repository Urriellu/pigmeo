using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Program Counter's (PC) Least Significant Byte
		/// </summary>
		[AsmName("PCL"), Location(true)]
		public volatile static byte PCL = 0;
	}
}