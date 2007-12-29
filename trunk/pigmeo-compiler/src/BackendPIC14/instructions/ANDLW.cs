namespace Pigmeo.Compiler.BackendPIC14 {
	public class ANDLW:AsmInstruction {
		/// <summary>
		/// The contents of W register are AND’ed with the eight-bit literal "k". The result is placed in the W register
		/// </summary>
		public ANDLW(string label, byte k, string comment) {
			OP = OpCode.ANDLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
