using System;

namespace Pigmeo.Compiler.PIR {
	public class Nop:Operation {
		public Nop(Method ParentMethod):base(ParentMethod) {
			Operator = "Nop";
		}
	}
}
