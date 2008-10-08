using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Creates a new object or a new instance of a value type, pushing an object reference onto the stack
		/// </summary>
		public class newobj:MethodOperand {
			public newobj(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.newobj;
			}
		}
	}
}