namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Specifies the end of the assembly language file. No instructions after END will be executed
	/// </summary>
	public class END:AsmInstruction {
		/// <summary>
		/// Specifies the end of the assembly language file. No instructions after END will be executed
		/// </summary>
		public END(string comment) {
			directive = Directive.END;
			type = InstructionType.Directive_none;

			this.comment = comment;
		}
	}
}
