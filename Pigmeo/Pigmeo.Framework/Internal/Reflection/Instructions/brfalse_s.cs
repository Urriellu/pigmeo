﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Branch on false, null or zero, short form
		/// </summary>
		public class brfalse_s:brfalse {
			/// <summary>
			/// Instantiates a new object that represents a "brfalse.s" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public brfalse_s(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.brfalse_s;
			}
		}
	}
}