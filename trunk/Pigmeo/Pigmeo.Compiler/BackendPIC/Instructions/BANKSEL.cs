namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Generates bank selecting code to set the bank to the bank containing the designated label
	/// </summary>
	public class BANKSEL:AsmInstruction {
		/// <summary>
		/// Generates bank selecting code to set the bank to the bank containing the designated label
		/// </summary>
		public BANKSEL(string label, string f, string comment) {
			OP = OpCode.BANKSEL;
			type = InstructionType.ByteOriented_f;

			this.file = f;
			this.label = label;
			this.comment = comment;
		}
	}
}
