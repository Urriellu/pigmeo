namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// The contents of register "f" are incremented. If the result is "1", the next instruction is executed. If the result is "0", a NOP is executed instead, making it a two-cycle instruction
	/// </summary>
	public class INCFSZ:AsmInstruction {
		/// <summary>
		/// The contents of register "f" are incremented. If the result is "1", the next instruction is executed. If the result is "0", a NOP is executed instead, making it a two-cycle instruction
		/// </summary>
		public INCFSZ(string label, string f, Destination d, string comment) {
			OP = OpCode.INCFSZ;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
