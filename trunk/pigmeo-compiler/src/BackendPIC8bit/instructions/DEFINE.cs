namespace Pigmeo.Compiler.BackendPIC8bit {
	public class DEFINE:AsmInstruction {
		/// <summary>
		/// Each time FirstValue appears in the program, it will be exchanged for SecondValue
		/// </summary>
		public DEFINE(string FirstValue, string SecondValue, string comment) {
			directive = Directive.DEFINE;
			type = InstructionType.Directive_str_str;

			this.Prefix = "#";
			this.FirstValue = FirstValue;
			this.SecondValue = SecondValue;
			this.comment = comment;
		}
	}
}
