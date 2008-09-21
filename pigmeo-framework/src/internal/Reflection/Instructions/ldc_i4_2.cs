﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads the constant value of 2 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_2:ldc_i4 {
			public ldc_i4_2(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_2;
				ConstantValue = 2;
			}
		}
	}
}