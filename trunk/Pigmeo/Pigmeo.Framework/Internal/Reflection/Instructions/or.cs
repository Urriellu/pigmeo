using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Computes the bitwise complement (OR) of the two integer values on top of stack and pushes the result on the stack
		/// </summary>
		public class or:Instruction {
			/// <summary>
			/// Instantiates a new object that represents a "or" CIL instruction
			/// </summary>
			/// <param name="ParendMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public or(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				this.OpCode = OpCodes.or;
			}
		}
	}
}