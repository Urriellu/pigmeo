namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// The contents of register f is moved to a destination dependent upon the status of d. d = F is useful to test a file register since status flag Z is affected
	/// </summary>
	public class MOVF:AsmInstruction {
		/// <summary>
		/// The contents of register f is moved to a destination dependent upon the status of d. d = F is useful to test a file register since status flag Z is affected
		/// </summary>
		public MOVF(string label, string f, Destination d, string comment) {
			OP = OpCode.MOVF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
