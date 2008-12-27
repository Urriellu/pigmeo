using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation (its inputs and result)
	/// </summary>
	public abstract class Operand {
		public override string ToString() {
			return "[UnknownOperand]";
		}

		public static bool operator ==(Operand First, Operand Second) {
			if(First is ConstantInt32Operand && Second is ConstantInt32Operand) return (First as ConstantInt32Operand).Value == (Second as ConstantInt32Operand).Value;
			if(First is FieldOperand && Second is FieldOperand) return (First as FieldOperand).TheField == (Second as FieldOperand).TheField;
			return Object.ReferenceEquals(First, Second);
		}

		public static bool operator !=(Operand First, Operand Second) {
			return !(First == Second);
		}

		public override bool Equals(object obj) {
			if(obj == null) return false;
			if(!(obj is Operand)) return false;
			return this == (obj as Operand);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}
}
