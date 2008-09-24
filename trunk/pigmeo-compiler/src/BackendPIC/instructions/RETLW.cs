namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// The W register is loaded with the eight bit literal "k". The program counter is loaded from the top of the stack (the return address). This is a two-cycle instruction
	/// </summary>
	public class RETLW:AsmInstruction {
		/// <summary>
		/// The W register is loaded with the eight bit literal "k". The program counter is loaded from the top of the stack (the return address). This is a two-cycle instruction
		/// </summary>
		public RETLW(string label, byte k, string comment) {
			OP = OpCode.RETLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
