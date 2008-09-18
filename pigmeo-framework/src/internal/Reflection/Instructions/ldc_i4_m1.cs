using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads the constant value of -1 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_m1:ldc_i4 {
			public static new ldc_i4_m1 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new ldc_i4_m1(OriginalMethod, OriginalInstr);
			}

			public ldc_i4_m1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_m1;
				Operand = -1;
			}
		}
	}
}