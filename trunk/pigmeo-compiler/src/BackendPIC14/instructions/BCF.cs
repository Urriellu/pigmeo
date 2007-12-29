namespace Pigmeo.Compiler.BackendPIC14 {
	public class BCF:AsmInstruction {
		/// <summary>
		/// Bit "b" in register "f" is cleared.
		/// </summary>
		public BCF(string label, string f, UInt3 b, string comment) {
			OP = OpCode.BCF;
			type = InstructionType.BitOriented_fb;

			this.file = f;
			this.b_DestinationBit = b;
			this.label = label;
			this.comment = comment;
		}
	}
}
