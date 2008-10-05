using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument 0 onto the stack
		/// </summary>
		public class ldarg_0:ldarg {
			public ldarg_0(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldarg_0;
				Index = 0;
			}
		}
	}
}