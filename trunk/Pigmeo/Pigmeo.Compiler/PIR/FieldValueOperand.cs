using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the value of a Field
	/// </summary>
	/// <remarks>
	/// Operations that have this operand are working with the value contained in this Field. If you need to get a Field's address or the value of one of its bits, use FieldBitOperand or FieldAddrOperand instead
	/// </remarks>
	public class FieldValueOperand:FieldOperand {
		public FieldValueOperand(Field ReferencedField)
			: base(ReferencedField) {
		}

		public override string ToString() {
			return string.Format("[FieldValue]{0}", TheField.ToStringTypeAndName());
		}
	}
}
