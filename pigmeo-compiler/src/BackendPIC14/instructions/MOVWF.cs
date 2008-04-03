namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Move data from W register to register "f"
	/// </summary>
	public class MOVWF:AsmInstruction {
		/// <summary>
		/// Move data from W register to register "f"
		/// </summary>
		public MOVWF(string label, string f, string comment) {
			OP = OpCode.MOVWF;
			type = InstructionType.ByteOriented_f;

			this.file = f;
			this.label = label;
			this.comment = comment;
		}
	}
}
