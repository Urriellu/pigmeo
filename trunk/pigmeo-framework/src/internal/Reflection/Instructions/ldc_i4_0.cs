﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads the constant value of 0 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_0:ldc_i4 {
			public static new ldc_i4_0 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new ldc_i4_0(OriginalMethod, OriginalInstr);
			}

			public ldc_i4_0(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_0;
				Operand = 0;
			}
		}
	}
}