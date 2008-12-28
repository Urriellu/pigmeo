using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Contains the arithmetic status of the ALU, the Reset status and the bank select bits for data memory
		/// </summary>
		public static class STATUS {
			/// <summary>Register Bank Select bit (used for direct addressing). RP0=false for bank 0, RP0=true for bank 1</summary>
			[AsmName("RP0"), Location(true)]
			public volatile static bool RP0 = false;

			/// <summary>Time-out bit. INVERTED. true = After power-up, CLRWDT instruction or SLEEP instruction. false = A WDT time-out occurred</summary>
			[AsmName("NOT_TO"), Location(true)]
			public static readonly bool _TO = true;

			/// <summary>Power-down bit. INVERTED. true = After power-up or by the CLRWDT instruction. false = By execution of the SLEEP instruction</summary>
			[AsmName("NOT_PD"), Location(true)]
			public static readonly bool _PD = true;

			/// <summary>Zero bit. true = The result of an arithmetic or logic operation is zero. false = The result of an arithmetic or logic operation is not zero</summary>
			[AsmName("Z"), Location(true)]
			public volatile static bool Z;

			/// <summary>Digit Carry/_Borrow bit (ADDWF, ADDLW,SUBLW,SUBWF instructions). For Borrow, the polarity is reversed. true = A carry-out from the 4th low-order bit of the result occurred. false = No carry-out from the 4th low-order bit of the result</summary>
			[AsmName("DC"), Location(true)]
			public volatile static bool DC;

			/// <summary>Carry/_Borrow bit (ADDWF, ADDLW, SUBLW, SUBWF instructions). true = A carry-out from the Most Significant bit of the result occurred. false = No carry-out from the Most Significant bit of the result occurred</summary>
			/// <remarks>For Borrow, the polarity is reversed. A subtraction is executed by adding the two's complement of the second operand. For rotate (RRF, RLF) instructions, this bit is loaded with either the high-order or low-order bit of the source register.</remarks>
			[AsmName("C"), Location(true)]
			public volatile static bool C;
		}
	}
}