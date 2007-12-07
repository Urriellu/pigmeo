﻿namespace Pigmeo.Compiler.BackendPIC8bit {
	public class PROCESSOR:AsmInstruction {
		/// <summary>
		/// Specifies the branch of the target microcontroller
		/// </summary>
		public PROCESSOR(string FirstValue, string comment) {
			directive = Directive.PROCESSOR;
			type = InstructionType.Directive_str;

			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
