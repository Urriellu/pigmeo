using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a constant string
	/// </summary>
	public class ConstantStringOperand:ConstantOperand {
		public readonly string Value;

		public ConstantStringOperand(string Value) {
			this.Value = Value;
		}

		public override string ToString() {
			return string.Format("[ConstantString]{0}", Value);
		}
	}
}
