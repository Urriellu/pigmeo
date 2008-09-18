using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Replaces the value of a static field with a value from the stack
		/// </summary>
		public class stsfld:FieldOperand {
			public static new stsfld GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new stsfld(OriginalMethod, OriginalInstr);
			}

			public stsfld(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.stsfld;
			}
		}
	}
}