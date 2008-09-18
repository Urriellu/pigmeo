using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Executes the addition arithmetic operation on the two topmost variables on the stack, and pushes the result on top of the stack
		/// </summary>
		public class add:Instruction {
			public static new add GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new add(OriginalMethod, OriginalInstr);
			}

			public add(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.add;
			}
		}
	}
}