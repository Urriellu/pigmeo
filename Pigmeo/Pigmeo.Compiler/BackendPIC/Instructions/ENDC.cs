﻿namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Ends a CBLOCK
	/// </summary>
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
