namespace Pigmeo.Compiler.BackendPIC8bit {
	public class ADDWF:AsmInstruction {
		/// <summary>
		/// Add the contents of the W register with register "f"
		/// </summary>
		public ADDWF(string label, string f, Destination d, string comment) {
			OP = OpCode.ADDWF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
