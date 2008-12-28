namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Begins a conditional block of code comparing two values
	/// </summary>
	public class IF:AsmInstruction {
		/// <summary>
		/// Begins a conditional block of code comparing two values
		/// </summary>
		public IF(string FirstValue, string separator, string SecondValue, string comment) {
			directive = Directive.IF;
			type = InstructionType.Directive_str_sep_str;

			this.separator = separator;
			this.FirstValue = FirstValue;
			this.SecondValue = SecondValue;
			this.comment = comment;
		}
	}
}
