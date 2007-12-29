namespace Pigmeo.Compiler.BackendPIC8bit {
	public class DECFSZ:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are decremented. If the result is "1", the next instruction is executed. If the result is "0", then a NOP is executed instead, making it a two-cycle instruction
		/// </summary>
		public DECFSZ(string label, string f, Destination d, string comment) {
			OP = OpCode.DECFSZ;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
