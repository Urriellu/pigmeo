using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Executes the multiplication arithmetic operation on the two topmost variables on the stack, and pushes the result on top of the stack
		/// </summary>
		public class mul:Instruction {
			public mul(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.mul;
			}
		}
	}
}