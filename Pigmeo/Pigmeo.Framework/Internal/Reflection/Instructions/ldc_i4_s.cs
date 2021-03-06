﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant as int8 and puts it on top of stack as int32
		/// </summary>
		public class ldc_i4_s:ldc_i4 {
			/// <summary>
			/// Instantiates a new object that represents a "ldc.i4.s" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldc_i4_s(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldc_i4_s;
				if(OriginalInstruction.Operand != null) ConstantValue = (sbyte)OriginalInstruction.Operand;
			}
		}
	}
}