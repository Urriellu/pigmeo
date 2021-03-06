﻿namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Ends the conditional loop started by the WHILE directive
	/// </summary>
	public class ENDW:AsmInstruction {
		/// <summary>
		/// Ends the conditional loop started by the WHILE directive
		/// </summary>
		public ENDW(string comment) {
			directive = Directive.ENDW;
			type = InstructionType.Directive_none;

			this.comment = comment;
		}
	}
}
