namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Sets the types of messages that are printed in the listing file and error file
	/// </summary>
	public class ERRORLEVEL:AsmInstruction {
		/// <summary>
		/// Sets the types of messages that are printed in the listing file and error file
		/// </summary>
		public ERRORLEVEL(string FirstValue, string comment) {
			directive = Directive.ERRORLEVEL;
			type = InstructionType.Directive_str;

			//this.Prefix = "#";
			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
