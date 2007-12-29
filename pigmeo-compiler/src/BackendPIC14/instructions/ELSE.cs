namespace Pigmeo.Compiler.BackendPIC14 {
	public class ELSE:AsmInstruction {
		/// <summary>
		/// Used with IF directive as an alternative serie of instructions
		/// </summary>
		public ELSE(string comment) {
			directive = Directive.ELSE;
			type = InstructionType.Directive_none;

			this.comment = comment;
		}
	}
}
