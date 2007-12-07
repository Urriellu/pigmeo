namespace Pigmeo.Compiler.BackendPIC8bit {
	public class XORWF:AsmInstruction {
		/// <summary>
		/// Exclusive OR the contents of the W register with register "f"
		/// </summary>
		public XORWF(string label, string f, Destination d, string comment) {
			OP = OpCode.XORWF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
