using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Add:ArithmeticOperation {
		public Add(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "+";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public Add(Method ParentMethod, Operand Result, Operand FirstSummand, Operand SecondSummand)
			: this(ParentMethod) {
			this.Result = Result;
			Arguments[0] = FirstSummand;
			Arguments[1] = SecondSummand;
		}
	}
}
