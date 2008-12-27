using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which references a field
	/// </summary>
	/// <remarks>
	/// FieldValueOperand, FieldBitOperand, FieldAddrOperand... they all derive from FieldOperand because they all get "something" from a Field
	/// </remarks>
	public abstract class FieldOperand:Operand {
		public Field TheField;

		public FieldOperand(Field ReferencedField) {
			this.TheField = ReferencedField;
		}
	}
}
