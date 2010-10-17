using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Convert to int8, pushing int32 on stack
		/// </summary>
		public class conv_i1:conv {
			/// <summary>
			/// Instantiates a new object that represents a "conv.i1" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public conv_i1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction, BaseType.Int8) {
				this.OpCode = OpCodes.conv_i1;
			}
		}
	}
}