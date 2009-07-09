using System;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation (its inputs and result)
	/// </summary>
	public abstract class Operand:ICloneable {
		public override string ToString() {
			return "[UnknownOperand]";
		}

		public static bool operator ==(Operand First, Operand Second) {
			if(First is ConstantInt32Operand && Second is ConstantInt32Operand) return (First as ConstantInt32Operand).Value == (Second as ConstantInt32Operand).Value;
			if(First is FieldValueOperand && Second is FieldValueOperand) return (First as FieldValueOperand).TheField == (Second as FieldValueOperand).TheField;
			if(First is FieldBitOperand && Second is FieldBitOperand) return ((First as FieldBitOperand).TheField == (Second as FieldBitOperand).TheField && (First as FieldBitOperand).Bit == (Second as FieldBitOperand).Bit);
			if(First is FieldAddrOperand && Second is FieldAddrOperand) return (First as FieldAddrOperand).TheField == (Second as FieldAddrOperand).TheField;
			if(First is ParameterValueOperand && Second is ParameterValueOperand) return (First as ParameterValueOperand).TheParameter == (Second as ParameterValueOperand).TheParameter;
			if(First is ParameterBitOperand && Second is ParameterBitOperand) return ((First as ParameterBitOperand).TheParameter == (Second as ParameterBitOperand).TheParameter && (First as ParameterBitOperand).Bit == (Second as ParameterBitOperand).Bit);
			if(First is ParameterAddrOperand && Second is ParameterAddrOperand) return (First as ParameterAddrOperand).TheParameter == (Second as ParameterAddrOperand).TheParameter;
			if(First is LocalVariableValueOperand && Second is LocalVariableValueOperand) return (First as LocalVariableValueOperand).TheLV == (Second as LocalVariableValueOperand).TheLV;
			if(First is LocalVariableBitOperand && Second is LocalVariableBitOperand) return ((First as LocalVariableBitOperand).TheLV == (Second as LocalVariableBitOperand).TheLV && (First as LocalVariableBitOperand).Bit == (Second as LocalVariableBitOperand).Bit);
			if(First is LocalVariableAddrOperand && Second is LocalVariableAddrOperand) return (First as LocalVariableAddrOperand).TheLV == (Second as LocalVariableAddrOperand).TheLV;
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

		public object Clone() {
			ShowInfo.InfoDebug("Cloning operand " + this.ToString());
			object NewOpnd = this.MemberwiseClone();
			if(object.ReferenceEquals(NewOpnd, this)) throw new Exception("Operand not cloned!");
			return NewOpnd;
		}

		public Operand CloneOperand() {
			return (Operand)Clone();
		}
	}
}
