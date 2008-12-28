namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// AND the W register with register "f"
	/// </summary>
	public class ANDWF:AsmInstruction {
		/// <summary>
		/// AND the W register with register "f"
		/// </summary>
		public ANDWF(string label, string f, Destination d, string comment) {
			OP = OpCode.ANDWF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
