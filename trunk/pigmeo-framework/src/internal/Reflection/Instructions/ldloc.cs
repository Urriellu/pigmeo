using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load local variable into stack
		/// </summary>
		public class ldloc:Instruction {
			/// <summary>
			/// Local variable index
			/// </summary>
			public UInt16 Index {
				get;
				protected set;
			}

			/// <summary>
			/// Local variable being copied to the stack
			/// </summary>
			public LocalVariable Variable {
				get {
					return ParentMethod.LocalVariables[Index];
				}
			}

			public ldloc(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) Index = (UInt16)OriginalInstruction.Operand;
				this.OpCode = OpCodes.ldloc;
			}

			public override string ToString() {
				return OpCodeName + " " + Variable.Name;
			}
		}
	}
}