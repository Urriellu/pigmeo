namespace Pigmeo.Compiler.BackendPIC8bit {
	public class RLF:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are rotated one bit to the left through the Carry flag
		/// </summary>
		public RLF(string label, string f, Destination d, string comment) {
			OP = OpCode.RLF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
