using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load local variable onto stack, short form
		/// </summary>
		public class ldloc_s:ldloc {
			public ldloc_s(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldloc_s;
				Index = (byte)OriginalInstruction.Operand;
			}
		}
	}
}