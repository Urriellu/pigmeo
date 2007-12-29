namespace Pigmeo.Compiler.BackendPIC8bit {
	public class SUBLW:AsmInstruction {
		/// <summary>
		/// The W register is subtracted (2’s complement method) from the eight-bit literal "k". The result is placed in the W register
		/// </summary>
		public SUBLW(string label, byte k, string comment) {
			OP = OpCode.SUBLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
