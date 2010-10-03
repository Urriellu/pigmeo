using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	/// <summary>
	/// All Special Function Registers available in this microcontroller
	/// </summary>
	public static partial class Registers {
		/// <summary>
		/// Addressing this location uses contents of FSR to address data memory (not a physical register)
		/// </summary>
		[AsmName("INDF"), Location(true)]
		public volatile static byte INDF = 0;
	}
}