using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class ShiftLeft:ArithmeticOperation {
		public ShiftLeft(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "<<";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public ShiftLeft(Method ParentMethod, Operand Result, Operand FirstOperand, Operand SecondOperand)
			: this(ParentMethod) {
			this.Result = Result;
			Arguments[0] = FirstOperand;
			Arguments[1] = SecondOperand;
		}
	}
}
