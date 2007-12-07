using Pigmeo;
using System;

namespace Pigmeo.MCU {
	public static class Target {
		public const Architecture TargetArch = Architecture.PIC16;
		public const Branch TargetBranch = Branch.PIC16F716;
	}

	public static class Registers {
		[Location(0x04)]
		public static byte PORTA;
	}
}
