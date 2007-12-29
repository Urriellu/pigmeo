namespace Pigmeo.Compiler.BackendPIC14 {
	public class VARIABLE:AsmInstruction {
		/// <summary>
		/// Each time that VariableName appears in program, it will be replaced with VariableValue. It can be changed
		/// </summary>
		public VARIABLE(string VariableName, string VariableValue, string comment) {
			directive = Directive.VARIABLE;
			type = InstructionType.Directive_str_sep_str;

			this.separator = "=";
			this.FirstValue = VariableName;
			this.SecondValue = VariableValue;
			this.comment = comment;
		}
	}
}
