using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the address of a Field
	/// </summary>
	public class FieldAddrOperand:FieldOperand {
		public FieldAddrOperand(Field ReferencedField)
			: base(ReferencedField) {
		}

		public override string ToString() {
			return string.Format("[FieldAddress]{0}", TheField.ToStringTypeAndFullName());
		}
	}
}
