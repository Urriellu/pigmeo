using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Jump:Operation {
		protected Jump(Method ParentMethod):base(ParentMethod) {
			Operator = "Jump";
		}

		public Jump(Method ParentMethod, PRefl.Instructions.br_s OrigCilInstr):this(ParentMethod) {
			Arguments = new Operand[1];
			Arguments[0] = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstr.Index);
		}
	}
}
