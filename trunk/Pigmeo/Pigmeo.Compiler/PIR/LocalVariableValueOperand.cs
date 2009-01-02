using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the value of a Local Variable
	/// </summary>
	/// <remarks>
	/// Operations that have this operand are working with the value contained in this Local Variable. If you need to get a LV's address or the value of one of its bits, use LocalVariableBitOperand or LocalVariableAddrOperand instead
	/// </remarks>
	public class LocalVariableValueOperand:LocalVariableOperand {
		public LocalVariableValueOperand(LocalVariable ReferencedLV)
			: base(ReferencedLV) {
		}

		public override string ToString() {
			return string.Format("[LocalVariableValue]{0}", TheLV.ToString());
		}
	}
}
