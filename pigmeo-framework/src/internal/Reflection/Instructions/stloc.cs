using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pop a value from stack into a local variable
		/// </summary>
		public class stloc:LocalVariableOperand {
			public stloc(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) Index = (UInt16)OriginalInstruction.Operand; //stloc operand is UInt16
				this.OpCode = OpCodes.stloc;
			}
		}
	}
}