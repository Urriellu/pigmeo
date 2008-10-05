using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument onto the stack
		/// </summary>
		public class ldarg:Instruction {
			/// <summary>
			/// Argument index
			/// </summary>
			public UInt16 Index {
				get;
				protected set;
			}

			/// <summary>
			/// Local variable being copied to the stack
			/// </summary>
			public Parameter Argument {
				get {
					return ParentMethod.Parameters[Index];
				}
			}

			public ldarg(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) Index = (UInt16)OriginalInstruction.Operand;
				this.OpCode = OpCodes.ldarg;
			}

			public override string ToString() {
				return OpCodeName + " " + Argument.Name;
			}
		}
	}
}