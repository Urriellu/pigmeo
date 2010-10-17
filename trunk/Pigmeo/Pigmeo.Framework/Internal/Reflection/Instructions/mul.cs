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
			/// <summary>
			/// Instantiates a new object that represents a "mul" CIL instruction
			/// </summary>
			/// <param name="ParendMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public mul(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				this.OpCode = OpCodes.mul;
			}
		}
	}
}