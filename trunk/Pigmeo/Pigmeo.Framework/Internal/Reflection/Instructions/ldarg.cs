using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument onto the stack
		/// </summary>
		public class ldarg:ParameterOperand {
			/// <summary>
			/// Instantiates a new object that represents a "ldarg" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldarg(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) ParamIndex = (UInt16)OriginalInstruction.Operand;
				this.OpCode = OpCodes.ldarg;
			}
		}
	}
}