using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant and puts it on top of stack as float
		/// </summary>
		/// <remarks>
		/// The operand is a float64 (Double) but it's stored on the stack as float32 (Single)
		/// </remarks>
		public class ldc_r8:ldc_r {
			public ldc_r8(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_r8;
				ConstantValue = Convert.ToSingle((double)OriginalInstruction.Operand);
			}
		}
	}
}