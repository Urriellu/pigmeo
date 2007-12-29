namespace Pigmeo.Compiler.BackendPIC14 {
	public class DB:AsmInstruction {
		/// <summary>
		/// Reserves a byte in program memory. When there are more terms which need to be assigned a byte each, they will be assigned one after another
		/// </summary>
		public DB(string term, string comment) {
			directive = Directive.DB;
			type = InstructionType.Directive_lbl_dir_str;

			this.FirstValue = term;
			this.comment = comment;
		}
	}
}
