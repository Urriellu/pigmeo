namespace Pigmeo.Compiler.BackendPIC14 {
	public class IORWF:AsmInstruction {
		/// <summary>
		/// Inclusive OR the W register with register "f"
		/// </summary>
		public IORWF(string label, string f, Destination d, string comment) {
			OP = OpCode.IORWF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
