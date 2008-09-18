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
			public static new conv_u1 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new conv_u1(OriginalMethod, OriginalInstr);
			}

			public conv_u1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.conv_u1;
			}
		}
	}
}