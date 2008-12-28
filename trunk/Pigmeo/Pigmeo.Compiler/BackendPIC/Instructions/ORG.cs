namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Specifies the location in the memory program where the next instruction will be stored
	/// </summary>
	public class ORG:AsmInstruction {
		/// <summary>
		/// Specifies the location in the memory program where the next instruction will be stored
		/// </summary>
		public ORG(string location, string comment) {
			directive = Directive.ORG;
			type = InstructionType.Directive_lbl_dir_str;

			this.FirstValue = location;
			this.comment = comment;
		}
	}
}
