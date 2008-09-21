using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is a field
		/// </summary>
		public abstract class FieldOperand:Instruction {
			/// <summary>
			/// Field this instruction references
			/// </summary>
			public readonly Field ReferencedField;

			public FieldOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				FieldReference field = (FieldReference)OriginalInstruction.Operand;
				ReferencedField = ParentMethod.ParentAssembly.GetAType(field.DeclaringType.FullName).Fields[field.Name];
				ReferencesAField = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a field: {0} {1}", OriginalInstruction.OpCode.ToString(), ReferencedField.FullName);
			}

			public override string ToString() {
				return OpCodeName + " " + ReferencedField.FullNameWithAssembly;
			}
		}
	}
}