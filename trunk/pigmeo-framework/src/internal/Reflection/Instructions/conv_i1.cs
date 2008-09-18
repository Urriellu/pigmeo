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
			public static new conv_i1 GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
				return new conv_i1(OriginalMethod, OriginalInstr);
			}

			public conv_i1(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.conv_i1;
			}
		}
	}
}