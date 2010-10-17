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
			/// <summary>
			/// The string pushed into the stack
			/// </summary>
			public readonly string TheString;

			/// <summary>
			/// Instantiates a new object that represents a "ldstr" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldstr(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				TheString = (string)OriginalInstruction.Operand;
				OpCode = OpCodes.ldstr;
			}

			public override string ToString() {
				return base.ToString() + " " + TheString;
			}
		}
	}
}