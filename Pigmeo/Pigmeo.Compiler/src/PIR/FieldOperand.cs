using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a class Field
	/// </summary>
	public class FieldOperand:Operand {
		public readonly Field TheField;

		public FieldOperand(Field ReferencedField) {
			this.TheField = ReferencedField;
		}

		public override string ToString() {
			return string.Format("[Field]{0}", TheField.ToStringTypeAndName());
		}
	}
}
