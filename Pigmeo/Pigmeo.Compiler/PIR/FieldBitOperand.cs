using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the bit of a Field
	/// </summary>
	public class FieldBitOperand:FieldOperand {
		public byte Bit;

		public FieldBitOperand(Field ReferencedField, byte Bit)
			: base(ReferencedField) {
			this.Bit = Bit;
		}

		public override string ToString() {
			return string.Format("[FieldBit]{0}<bit {1}>", TheField.ToStringTypeAndFullName(), Bit);
		}
	}
}
