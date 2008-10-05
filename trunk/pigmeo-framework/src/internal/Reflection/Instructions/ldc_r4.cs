using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant and puts it on top of stack as float
		/// </summary>
		public class ldc_r4:ldc_r {
			public ldc_r4(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_r4;
				ConstantValue = (float)OriginalInstruction.Operand;
			}
		}
	}
}