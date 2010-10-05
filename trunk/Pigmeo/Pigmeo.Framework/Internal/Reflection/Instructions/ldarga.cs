using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument address onto the stack
		/// </summary>
		public class ldarga:ParameterOperand {
			/// <summary>
			/// Instantiates a new object that represents a "ldarga" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldarga(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is Mono.Cecil.ParameterDefinition) ParamIndex = (UInt16)((((Mono.Cecil.ParameterDefinition)OriginalInstruction.Operand).Sequence) - 1);
				this.OpCode = OpCodes.ldarga;
			}
		}
	}
}