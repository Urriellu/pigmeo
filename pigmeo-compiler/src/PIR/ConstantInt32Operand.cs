using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a constant Int32 value
	/// </summary>
	public class ConstantInt32Operand:Operand {
		public readonly Int32 Value;

		public ConstantInt32Operand(PRefl.Instructions.ldc_i4 OriginalCilInstr) {
			Value = OriginalCilInstr.ConstantValue;
		}

		public override string ToString() {
			return string.Format("[ConstantInt32]{0}", Value);
		}
	}
}
