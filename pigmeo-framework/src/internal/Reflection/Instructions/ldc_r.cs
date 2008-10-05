using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Loads a constant and puts it on top of stack as float
		/// </summary>
		public abstract class ldc_r:ldc {
			/// <summary>
			/// Constant value being loaded onto the stack
			/// </summary>
			public float ConstantValue { get; protected set; }

			public ldc_r(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
			}

			public override string ToString() {
				return OpCodeName + " " + ConstantValue;
			}
		}
	}
}