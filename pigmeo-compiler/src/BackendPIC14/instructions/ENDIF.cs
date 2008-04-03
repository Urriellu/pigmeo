﻿namespace Pigmeo.Compiler.BackendPIC14 {
	public class ENDIF:AsmInstruction {
		/// <summary>
		/// Ends the conditional block of code
		/// </summary>
		public ENDIF(string comment) {
			directive = Directive.ENDIF;
			type = InstructionType.Directive_none;

			this.comment = comment;
		}
	}
}