using System;

namespace Pigmeo.Compiler.PIR {
	public class Return:Operation {
		public Return(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Return";
		}
	}
}
