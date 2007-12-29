namespace Pigmeo.Compiler.BackendPIC14 {
	public class COMF:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are complemented
		/// </summary>
		public COMF(string label, string f, Destination d, string comment) {
			OP = OpCode.COMF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
