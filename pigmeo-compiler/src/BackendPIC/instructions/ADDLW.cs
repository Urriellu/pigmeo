namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Add literal to W
	/// </summary>
	public class ADDLW:AsmInstruction {
		/// <summary>
		/// Add literal to W
		/// </summary>
		public ADDLW(string label, byte k, string comment) {
			OP = OpCode.ADDLW;
			type = InstructionType.Literal_number;

			this.LiteralNumber = k;
			this.label = label;
			this.comment = comment;
		}
	}
}