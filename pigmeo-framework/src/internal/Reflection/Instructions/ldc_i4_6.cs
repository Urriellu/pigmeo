using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads the constant value of 6 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_6:ldc_i4 {
			public static new ldc_i4_6 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new ldc_i4_6(OriginalMethod, OriginalInstr);
			}

			public ldc_i4_6(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_6;
				Operand = 6;
			}
		}
	}
}