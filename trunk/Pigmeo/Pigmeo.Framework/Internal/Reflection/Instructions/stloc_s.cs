using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pop a value from stack into a local variable, short form
		/// </summary>
		public class stloc_s:stloc {
			/// <summary>
			/// Instantiates a new object that represents a "stloc.s" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public stloc_s(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.stloc_s;
				VariableIndex = (byte)OriginalInstruction.Operand;
			}
		}
	}
}