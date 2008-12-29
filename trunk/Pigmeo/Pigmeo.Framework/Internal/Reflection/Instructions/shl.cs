using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Shifts an integer valueto the left (in zeroes) by a specified number of bits and puts the result on the stack
		/// </summary>
		public class shl:Instruction {
			public shl(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.shl;
			}
		}
	}
}