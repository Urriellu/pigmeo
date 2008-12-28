﻿using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Copy:Operation {
		protected Copy(Method ParentMethod):base(ParentMethod) {
			Operator = "Copy";
			Arguments = new Operand[1];
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldc_i4 OrigCilInstr):this(ParentMethod) {
			Arguments[0] = new ConstantInt32Operand(OrigCilInstr.ConstantValue);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.stsfld OrigCilInstr):this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = new FieldValueOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldsfld OrigCilInstr):this(ParentMethod) {
			Arguments[0] = new FieldValueOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldarg OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new ParameterValueOperand(ParentMethod.Parameters[OrigCilInstr.Argument.Name]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, Operand Origin, Operand Result):this(ParentMethod) {
			Arguments[0] = Origin;
			this.Result = Result;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " " + Arguments[0];
		}
	}
}