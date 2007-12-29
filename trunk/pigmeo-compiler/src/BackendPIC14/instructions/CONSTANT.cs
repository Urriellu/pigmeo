namespace Pigmeo.Compiler.BackendPIC14 {
	public class CONSTANT:AsmInstruction {
		/// <summary>
		/// Each time that ConstantName appears in program, it will be replaced with ConstantValue
		/// </summary>
		public CONSTANT(string ConstantName, string ConstantValue, string comment) {
			directive = Directive.CONSTANT;
			type = InstructionType.Directive_str_sep_str;

			this.separator = "=";
			this.FirstValue = ConstantName;
			this.SecondValue = ConstantValue;
			this.comment = comment;
		}
	}
}
