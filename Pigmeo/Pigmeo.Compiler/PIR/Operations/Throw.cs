using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public class Throw:Operation {
		public Throw(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Throw";
			Arguments = new Operand[] { GlobalOperands.TOSS };
		}
	}
}
