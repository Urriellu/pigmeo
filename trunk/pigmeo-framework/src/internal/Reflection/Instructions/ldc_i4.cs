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
			public static new ldc_i4 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new ldc_i4(OriginalMethod, OriginalInstr);
			}

			public ldc_i4(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4;
				if(OriginalInstruction.Operand != null) Operand = (Int32)OriginalInstruction.Operand;
			}
		}
	}
}