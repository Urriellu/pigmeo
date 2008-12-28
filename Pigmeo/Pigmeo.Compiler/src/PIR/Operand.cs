using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation (its inputs and result)
	/// </summary>
	public abstract class Operand {
		public override string ToString() {
			return "[UnknownOperand]";
		}
	}
}
