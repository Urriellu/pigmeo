using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Convert the value on top of the stack to the type specified in the opcode, and leave that converted value on the top of the stack.
		/// </summary>
		public abstract class conv:Instruction {
			public conv(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
			}
		}
	}
}