﻿using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class XOR:ArithmeticOperation {
		public XOR(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "XOR";
			Arguments = new Operand[2];
			Result = Arguments[0] = Arguments[1] = GlobalOperands.TOSS;
		}

		public XOR(Method ParentMethod, Operand Result, Operand FirstOperand, Operand SecondOperand)
			: this(ParentMethod) {
			this.Result = Result;
			Arguments[0] = FirstOperand;
			Arguments[1] = SecondOperand;
		}
	}
}
