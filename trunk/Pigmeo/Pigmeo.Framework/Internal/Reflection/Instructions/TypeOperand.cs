using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is a (reference to a) Type
		/// </summary>
		public abstract class TypeOperand:Instruction {
			/// <summary>
			/// Type this instruction references
			/// </summary>
			public readonly Type ReferencedType;

			/// <summary>
			/// Instantiates a new object that represents a CIL instruction whose operand is a Type
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public TypeOperand(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				TypeReference type = (TypeReference)OriginalInstruction.Operand;
				ReferencedType = ParentMethod.ParentAssembly.GetAType(type.FullName);
				ReferencesAType = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a Type: {0} {1}", OriginalInstruction.OpCode.ToString(), ReferencedType.FullName);
			}

			public override string ToString() {
				return base.ToString() + " " + ReferencedType.FullNameWithAssembly;
			}
		}
	}
}