using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// CIL Instructions
	/// </summary>
	public static partial class Instructions {
		/// <summary>
		/// Executes the addition arithmetic operation on the two topmost variables on the stack, and pushes the result on top of the stack
		/// </summary>
		public class add:Instruction {
			/// <summary>
			/// Instantiates a new object that represents a "add" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public add(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.add;
			}
		}
	}
}