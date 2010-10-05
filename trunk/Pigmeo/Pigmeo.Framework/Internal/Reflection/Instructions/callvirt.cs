﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Call a method associated with an object
		/// </summary>
		public class callvirt:MethodOperand {
			/// <summary>
			/// Instantiates a new object that represents a "callvirt" CIL instruction
			/// </summary>
			/// <param name="OriginalMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public callvirt(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.callvirt;
			}
		}
	}
}