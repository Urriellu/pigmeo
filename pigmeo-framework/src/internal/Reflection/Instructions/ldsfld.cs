﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pushes the value of a static field on the stack
		/// </summary>
		public class ldsfld:FieldOperand {
			public ldsfld(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldsfld;
			}
		}
	}
}