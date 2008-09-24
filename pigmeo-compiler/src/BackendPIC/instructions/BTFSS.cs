namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// If bit "b" in register "f" is "0", the next instruction is executed. If bit "b" is "1", then the next instruction is discarded and a NOP is executed instead, making this a two-cycle instruction
	/// </summary>
	public class BTFSS:AsmInstruction {
		/// <summary>
		/// If bit "b" in register "f" is "0", the next instruction is executed. If bit "b" is "1", then the next instruction is discarded and a NOP is executed instead, making this a two-cycle instruction
		/// </summary>
		public BTFSS(string label, string f, UInt3 b, string comment) {
			OP = OpCode.BTFSS;
			type = InstructionType.BitOriented_fb;

			this.file = f;
			this.b_DestinationBit = b;
			this.label = label;
			this.comment = comment;
		}
	}
}
