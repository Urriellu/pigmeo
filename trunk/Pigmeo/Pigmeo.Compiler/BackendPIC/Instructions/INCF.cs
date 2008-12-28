namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// The contents of register "f" are incremented by 1
	/// </summary>
	public class INCF:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are incremented by 1
		/// </summary>
		public INCF(string label, string f, Destination d, string comment) {
			OP = OpCode.INCF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
