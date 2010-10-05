using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Throws the exception object which is on top of stack
		/// </summary>
		public class Throw:Instruction {
			/// <summary>
			/// Instantiates a new object that represents a "throw" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public Throw(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.Throw;
			}
		}
	}
}