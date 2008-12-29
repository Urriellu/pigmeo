using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load an argument onto the stack, short form
		/// </summary>
		public class ldarg_s:ldarg {
			public ldarg_s(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldarg_s;
				ParamIndex = (byte)OriginalInstruction.Operand;
			}
		}
	}
}