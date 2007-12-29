namespace Pigmeo.Compiler.BackendPIC14 {
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
