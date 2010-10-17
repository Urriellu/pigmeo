using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant and puts it on top of stack as float
		/// </summary>
		public abstract class ldc_r:ldc {
			/// <summary>
			/// Constant value being loaded onto the stack
			/// </summary>
			public float ConstantValue { get; protected set; }

			/// <summary>
			/// Instantiates a new object that represents a "ldc.r" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldc_r(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
			}

			public override string ToString() {
				return base.ToString() + " " + ConstantValue;
			}
		}
	}
}