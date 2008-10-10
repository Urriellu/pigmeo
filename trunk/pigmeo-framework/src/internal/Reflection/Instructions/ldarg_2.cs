using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument 2 onto the stack
		/// </summary>
		public class ldarg_2:ldarg {
			public ldarg_2(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldarg_2;
				ParamIndex = 2;
			}
		}
	}
}