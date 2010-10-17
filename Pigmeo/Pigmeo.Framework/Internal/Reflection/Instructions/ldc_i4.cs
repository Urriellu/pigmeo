using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4:ldc_i {
			/// <summary>
			/// Constant value being loaded onto the stack
			/// </summary>
			public Int32 ConstantValue { get; protected set; }

			/// <summary>
			/// Instantiates a new object that represents a "ldc.i4" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldc_i4(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4;
				if(OriginalInstruction.Operand is Int32) ConstantValue = (Int32)OriginalInstruction.Operand;
			}

			public override string ToString() {
				return base.ToString() + " " + ConstantValue;
			}
		}
	}
}