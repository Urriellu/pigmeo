using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pop a value from stack into a local variable
		/// </summary>
		public class stloc:LocalVariableOperand {
			/// <summary>
			/// Instantiates a new object that represents a "stloc" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public stloc(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) VariableIndex = (UInt16)OriginalInstruction.Operand; //stloc operand is UInt16
				this.OpCode = OpCodes.stloc;
			}
		}
	}
}