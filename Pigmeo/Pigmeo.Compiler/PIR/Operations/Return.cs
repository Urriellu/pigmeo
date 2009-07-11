using System;

namespace Pigmeo.Compiler.PIR {
	public class Return:Operation {
		public Return(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Return";
			if(ParentMethod.ReturnType.Name != "System.Void") {
				Arguments = new Operand[] {
					GlobalOperands.TOSS
				};
			}
		}
	}
}
