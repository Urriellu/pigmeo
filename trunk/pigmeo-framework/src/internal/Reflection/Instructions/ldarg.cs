using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument onto the stack
		/// </summary>
		public class ldarg:ParameterOperand {
			public ldarg(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) ParamIndex = (UInt16)OriginalInstruction.Operand;
				this.OpCode = OpCodes.ldarg;
			}
		}
	}
}