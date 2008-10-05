using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Converts a boxable value to its boxed form
		/// </summary>
		public class box:TypeOperand {
			public box(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.box;
			}
		}
	}
}