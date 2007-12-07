namespace Pigmeo.Compiler.BackendPIC8bit {
	public class EQU:AsmInstruction {
		/// <summary>
		/// ConstantValue is assigned to ConstantName
		/// </summary>
		public EQU(string ConstantName, string ConstantValue, string comment) {
			directive = Directive.EQU;
			type = InstructionType.Directive_str_dir_str;

			this.FirstValue = ConstantName;
			this.SecondValue = ConstantValue;
			this.comment = comment;
		}
	}
}
