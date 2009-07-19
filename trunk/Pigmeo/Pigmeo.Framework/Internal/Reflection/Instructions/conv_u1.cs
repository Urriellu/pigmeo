using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Convert to unsigned int8, pushing int32 on stack
		/// </summary>
		public class conv_u1:conv {
			public conv_u1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction, BaseType.UInt8) {
				this.OpCode = OpCodes.conv_u1;
			}
		}
	}
}