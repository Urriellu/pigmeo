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
			/// <summary>
			/// Instantiates a new object that represents a "newobj" CIL instruction
			/// </summary>
			/// <param name="ParendMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public newobj(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				this.OpCode = OpCodes.newobj;
			}
		}
	}
}