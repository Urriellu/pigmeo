namespace Pigmeo.Compiler.BackendPIC14 {
	public class RRF:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are rotated one bit to the right through the Carry flag
		/// </summary>
		public RRF(string label, string f, Destination d, string comment) {
			OP = OpCode.RRF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
