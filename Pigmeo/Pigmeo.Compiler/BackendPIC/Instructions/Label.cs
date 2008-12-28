namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Just a label, no instruction
	/// </summary>
	public class Label:AsmInstruction {
		/// <summary>
		/// Just a label, no instruction
		/// </summary>
		public Label(string label, string comment) {
			type = InstructionType.Label;

			this.label = label;
			this.comment = comment;
		}
	}
}
