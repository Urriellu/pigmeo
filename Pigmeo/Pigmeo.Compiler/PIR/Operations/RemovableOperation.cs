using System;

namespace Pigmeo.Compiler.PIR {
	public class RemovableOperation:Operation {
		public RemovableOperation(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Remove me!!!!";
		}
	}
}
