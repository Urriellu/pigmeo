﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument 1 onto the stack
		/// </summary>
		public class ldarg_1:ldarg {
			/// <summary>
			/// Instantiates a new object that represents a "ldarg.1" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public ldarg_1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldarg_0;
				ParamIndex = 1;
			}
		}
	}
}