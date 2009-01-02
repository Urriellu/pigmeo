using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the bit of a Local Variable
	/// </summary>
	public class LocalVariableBitOperand:LocalVariableOperand {
		public byte Bit;

		public LocalVariableBitOperand(LocalVariable ReferencedLV, byte Bit)
			: base(ReferencedLV) {
			this.Bit = Bit;
		}

		public override string ToString() {
			return string.Format("[LocalVariableBit]{0}<bit {1}>", TheLV.ToString(), Bit);
		}
	}
}
