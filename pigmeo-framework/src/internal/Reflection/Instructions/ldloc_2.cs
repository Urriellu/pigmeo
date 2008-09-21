using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load local variable 2 onto stack
		/// </summary>
		public class ldloc_2:stloc {
			public ldloc_2(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ldloc_2;
				Index = 2;
			}
		}
	}
}