using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a constant Int32 value
	/// </summary>
	public class ConstantInt32Operand:Operand {
		public readonly Int32 Value;

		public ConstantInt32Operand(Int32 Value) {
			this.Value = Value;
		}

		public override string ToString() {
			return string.Format("[ConstantInt32]{0}", Value);
		}
	}
}
