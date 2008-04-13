namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// To the variable VariableName is added expression VariableValue. SET directive is similar to EQU, but with SET directive name of the variable can be redefined following a definition
	/// </summary>
	public class SET:AsmInstruction {
		/// <summary>
		/// To the variable VariableName is added expression VariableValue. SET directive is similar to EQU, but with SET directive name of the variable can be redefined following a definition
		/// </summary>
		public SET(string VariableName, string VariableValue, string comment) {
			directive = Directive.SET;
			type = InstructionType.Directive_str_dir_str;

			this.FirstValue = VariableName;
			this.SecondValue = VariableValue;
			this.comment = comment;
		}
	}
}
