using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pushes a reference to a string object (stored in the metadata) onto the stack
		/// </summary>
		public class ldstr:Instruction {
			public readonly string TheString;

			public ldstr(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				TheString = (string)OriginalInstruction.Operand;
				OpCode = OpCodes.ldstr;
			}

			public override string ToString() {
				return OpCodeName + " " + TheString;
			}
		}
	}
}