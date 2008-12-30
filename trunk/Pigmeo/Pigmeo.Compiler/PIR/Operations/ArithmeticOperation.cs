using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class ArithmeticOperation:Operation {
		protected ArithmeticOperation(Method ParentMethod)
			: base(ParentMethod) {
		}

		public override string ToString() {
			string ret = Label + ": " + Result + " " + AssignmentSign + " ";
			for(int i = 0 ; i < Arguments.Length ; i++) {
				ret += Arguments[0];
				if(i != Arguments.Length - 1) ret += " " + Operator + " ";
			}
			return ret;
		}
	}
}
