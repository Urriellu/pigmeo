using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Substract:ArithmeticOperation {
		public Substract(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "-";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public Substract(Method ParentMethod, Operand Result, Operand Minuend, Operand Subtrahend)
			: this(ParentMethod) {
			this.Result = Result;
			Arguments[0] = Minuend;
			Arguments[1] = Subtrahend;
		}
	}
}
