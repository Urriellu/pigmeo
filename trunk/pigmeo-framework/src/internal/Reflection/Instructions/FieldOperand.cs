using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		public abstract class FieldOperand:Instruction {
			protected readonly string FieldFullName;

			public FieldOperand(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				FieldReference field = (FieldReference)OriginalInstruction.Operand;
				FieldFullName = OriginalMethod.ParentType.FullName + "." + OriginalMethod.Name + "." + field.Name;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a field: {0} {1}", OriginalInstruction.OpCode.ToString(), FieldFullName);
			}

			public override string ToString() {
				return OpCodeName + " " + FieldFullName;
			}
		}
	}
}