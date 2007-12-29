namespace Pigmeo.Compiler.BackendPIC14 {
	public class DT:AsmInstruction {
		/// <summary>
		/// Generates RETLW series of instructions, one instruction per each term
		/// </summary>
		public DT(string term, string comment) {
			directive = Directive.DT;
			type = InstructionType.Directive_lbl_dir_str;

			this.FirstValue = term;
			this.comment = comment;
		}
	}
}
