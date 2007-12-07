namespace Pigmeo.Compiler.BackendPIC8bit {
	public class IORLW:AsmInstruction {
		/// <summary>
		/// The contents of the W register are OR’ed with the eight-bit literal "k". The result is placed in the W register
		/// </summary>
		public IORLW(string label, string f, byte k, string comment) {
			OP = OpCode.IORLW;
			type = InstructionType.Literal_number;

			this.file = f;
			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
