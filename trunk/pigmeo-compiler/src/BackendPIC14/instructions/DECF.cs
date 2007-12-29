namespace Pigmeo.Compiler.BackendPIC14 {
	public class DECF:AsmInstruction {
		/// <summary>
		/// Decrement register "f"
		/// </summary>
		public DECF(string label, string f, Destination d, string comment) {
			OP = OpCode.DECF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
