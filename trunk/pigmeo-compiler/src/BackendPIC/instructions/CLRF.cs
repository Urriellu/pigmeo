namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// The contents of register "f" are cleared and the Z bit is set.
	/// </summary>
	public class CLRF:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are cleared and the Z bit is set.
		/// </summary>
		public CLRF(string label, string f, string comment) {
			OP = OpCode.CLRF;
			type = InstructionType.ByteOriented_f;

			this.file = f;
			this.label = label;
			this.comment = comment;
		}
	}
}
