namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// If bit "b" in register "f" is "1", the next instruction is executed. If bit "b", in register "f", is "0", the next instruction is discarded, and a NOP is executed instead, making this a two-cycle instruction
	/// </summary>
	public class BTFSC:AsmInstruction {
		/// <summary>
		/// If bit "b" in register "f" is "1", the next instruction is executed. If bit "b", in register "f", is "0", the next instruction is discarded, and a NOP is executed instead, making this a two-cycle instruction
		/// </summary>
		public BTFSC(string label, string f, UInt3 b, string comment) {
			OP = OpCode.BTFSC;
			type = InstructionType.BitOriented_fb;

			this.file = f;
			this.b_DestinationBit = b;
			this.label = label;
			this.comment = comment;
		}
	}
}
