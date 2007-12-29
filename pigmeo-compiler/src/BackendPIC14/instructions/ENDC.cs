namespace Pigmeo.Compiler.BackendPIC8bit {
	public class ENDC:AsmInstruction {
		/// <summary>
		/// Ends a CBLOCK
		/// </summary>
		public ENDC(string comment) {
			directive = Directive.ENDC;
			type = InstructionType.Directive_none;

			this.comment = comment;
		}
	}
}
