using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Computes the bitwise AND of two values and pushes the result on the stack
		/// </summary>
		public class and:Instruction {
			/// <summary>
			/// Instantiates a new object that represents a "and" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public and(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.and;
			}
		}
	}
}