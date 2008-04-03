namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// The contents of the W register are XOR’ed with the eight-bit literal "k"
	/// </summary>
	public class XORLW:AsmInstruction {
		/// <summary>
		/// The contents of the W register are XOR’ed with the eight-bit literal "k"
		/// </summary>
		public XORLW(string label, byte k, string comment) {
			OP = OpCode.XORLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
