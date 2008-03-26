﻿namespace Pigmeo.Compiler.BackendPIC14 {
	public class MOVLW:AsmInstruction {
		/// <summary>
		/// The eight-bit literal "k" is loaded into W register
		/// </summary>
		public MOVLW(string label, byte k, string comment) {
			OP = OpCode.MOVLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}