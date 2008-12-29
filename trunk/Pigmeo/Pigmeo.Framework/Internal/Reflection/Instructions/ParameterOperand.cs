using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is a Method Parameter
		/// </summary>
		public abstract class ParameterOperand:Instruction {
			/// <summary>
			/// Argument index
			/// </summary>
			public UInt16 ParamIndex {
				get;
				protected set;
			}

			/// <summary>
			/// Referenced Parameter
			/// </summary>
			public Parameter Argument {
				get {
					return ParentMethod.Parameters[ParamIndex];
				}
			}

			public ParameterOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				ReferencesAParameter = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a Parameter: {0}", OriginalInstruction.OpCode.ToString());
			}

			public override string ToString() {
				return base.ToString() + " " + Argument.Name;
			}
		}
	}
}