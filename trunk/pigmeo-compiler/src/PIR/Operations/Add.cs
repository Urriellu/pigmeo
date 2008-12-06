using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Add:Operation {
		public Add(Method ParentMethod):base(ParentMethod) {
			Operator = "Add";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public Add(Method ParentMethod, Operand Result, Operand FirstSummand, Operand SecondSummand):this(ParentMethod) {
			this.Result = Result;
			Arguments[0] = FirstSummand;
			Arguments[1] = SecondSummand;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " " + Arguments[0] + " + " + Arguments[1];
		}
	}
}
