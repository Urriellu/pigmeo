namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Program lines between WHILE and ENDW would be executed as long as condition was met. If a condition stopped being valid, program would continue executing instructions following ENDW line. Number of instructions between WHILE and ENDW can be 100 at the most, and number of executions 256
	/// </summary>
	public class WHILE:AsmInstruction {
		/// <summary>
		/// Program lines between WHILE and ENDW would be executed as long as condition was met. If a condition stopped being valid, program would continue executing instructions following ENDW line. Number of instructions between WHILE and ENDW can be 100 at the most, and number of executions 256
		/// </summary>
		public WHILE(string FirstValue, string separator, string SecondValue, string comment) {
			directive = Directive.WHILE;
			type = InstructionType.Directive_str_sep_str;

			this.separator = separator;
			this.FirstValue = FirstValue;
			this.SecondValue = SecondValue;
			this.comment = comment;
		}
	}
}
