using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Copy:Operation {
		protected Copy(Method ParentMethod):base(ParentMethod) {
			Operator = "Copy";
			Arguments = new Operand[1];
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldc_i4 OrigCilInstr):this(ParentMethod) {
			Arguments[0] = new ConstantInt32Operand(OrigCilInstr);
			Result = GlobalOperands.TOSS;
		}

		public override string ToString() {
			return base.ToString1st() + Arguments[0].ToString();
		}
	}
}
