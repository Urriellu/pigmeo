using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pop a value from stack into local variable 0
		/// </summary>
		public class stloc_0:stloc {
			public stloc_0(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.stloc_0;
				Index = 0;
			}
		}
	}
}