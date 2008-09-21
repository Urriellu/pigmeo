using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Pop a value from stack into a local variable
		/// </summary>
		public class stloc:Instruction {
			/// <summary>
			/// Local variable index
			/// </summary>
			public UInt16 Index {
				get;
				protected set;
			}

			/// <summary>
			/// Local variable where the Top Of Stack is being moved to
			/// </summary>
			public LocalVariable Variable {
				get {
					return ParentMethod.LocalVariables[Index];
				}
			}

			public stloc(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) Index = (UInt16)OriginalInstruction.Operand; //stloc operand is UInt16
				this.OpCode = OpCodes.stloc;
			}

			public override string ToString() {
				return OpCodeName + " " + Variable.Name;
			}
		}
	}
}