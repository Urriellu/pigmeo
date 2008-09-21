using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads the constant value of 3 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_3:ldc_i4 {
			public ldc_i4_3(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_3;
				ConstantValue = 3;
			}
		}
	}
}