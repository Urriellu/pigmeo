namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Bit "b" in register "f" is set
	/// </summary>
	public class BSF:AsmInstruction {
		/// <summary>
		/// Bit "b" in register "f" is set
		/// </summary>
		public BSF(string label, string f, UInt3 b, string comment) {
			OP = OpCode.BSF;
			type = InstructionType.BitOriented_fb;

			this.file = f;
			this.b_DestinationBit = b;
			this.label = label;
			this.comment = comment;
		}
	}
}
