using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Add:Operation {
		public Add(Method ParentMethod):base(ParentMethod) {
			Operator = "Add";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " " + Arguments[0] + " + " + Arguments[1];
		}
	}
}
