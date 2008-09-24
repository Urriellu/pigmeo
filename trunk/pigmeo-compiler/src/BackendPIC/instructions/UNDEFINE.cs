namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// End the definition set by the DEFINE directive
	/// </summary>
	public class UNDEFINE:AsmInstruction {
		/// <summary>
		/// End the definition set by the DEFINE directive
		/// </summary>
		public UNDEFINE(string FirstValue, string comment) {
			directive = Directive.UNDEFINE;
			type = InstructionType.Directive_str;

			this.Prefix = "#";
			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
