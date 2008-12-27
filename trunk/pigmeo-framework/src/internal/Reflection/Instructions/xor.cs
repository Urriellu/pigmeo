using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Computes the bitwise XOR of the two integer values on top of stack and pushes the result on the stack
		/// </summary>
		public class xor:Instruction {
			public xor(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.xor;
			}
		}
	}
}