using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// The ceq instruction compares the two values on top of the stack. If they are equal, then 1 (of type int32) is pushed on the stack. Otherwise, 0 (of type int32) is pushed on the stack.
		/// </summary>
		public class ceq:Instruction {
			public ceq(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.ceq;
			}
		}
	}
}