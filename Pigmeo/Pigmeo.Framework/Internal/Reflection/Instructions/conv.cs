using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Convert the value on top of the stack to the type specified in the opcode, and leave that converted value on the top of the stack.
		/// </summary>
		public abstract class conv:Instruction {
			/// <summary>
			/// Type to be converted to
			/// </summary>
			public readonly BaseType TargetType;

			/// <summary>
			/// Instantiates a new object that represents a "conv" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public conv(Method OriginalMethod, MCCil.Instruction OriginalInstruction, BaseType TargetType)
				: base(OriginalMethod, OriginalInstruction) {
				this.TargetType = TargetType;
			}
		}
	}
}