namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// The upper and lower nibbles of register "f" are exchanged
	/// </summary>
	public class SWAPF:AsmInstruction {
		/// <summary>
		/// The upper and lower nibbles of register "f" are exchanged
		/// </summary>
		public SWAPF(string label, string f, Destination d, string comment) {
			OP = OpCode.SWAPF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
