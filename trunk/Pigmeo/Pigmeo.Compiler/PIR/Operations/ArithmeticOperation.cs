using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public abstract class ArithmeticOperation:Operation {
		protected ArithmeticOperation(Method ParentMethod)
			: base(ParentMethod) {
		}

		public override string ToString() {
			string ret = Label + ": " + Result + " " + AssignmentSign + " ";
			for(int i = 0; i < Arguments.Length; i++) {
				ret += Arguments[i];
				if(i != Arguments.Length - 1) ret += " " + Operator + " ";
			}
			return ret;
		}

		public override Type ResultType {
			get {
				ShowInfo.InfoDebug("Getting result type of operation " + this.ToString());
				Type ResType = null;
				foreach(Operand Opnd in Arguments) {
					BaseType BT = BaseType.NativeInt;
					if(Opnd is LocalVariableOperand && ((Opnd as LocalVariableOperand).TheLV.LocalVarType.IsBaseType)) BT = (((Opnd as LocalVariableOperand).TheLV.LocalVarType)).ReprBaseType;
					else if(Opnd is ParameterOperand && ((Opnd as ParameterOperand).TheParameter.ParamType.IsBaseType)) BT = ((Opnd as ParameterOperand).TheParameter.ParamType).ReprBaseType;
					else if(Opnd is FieldOperand && ((Opnd as FieldOperand).TheField.FieldType.IsBaseType)) BT = ((Opnd as FieldOperand).TheField.FieldType).ReprBaseType;
					if(BT.IsStandardSize()) {
						if(ResType == null || (ResType != null && BT.IsHeavierThan(ResType.ReprBaseType))) ResType = ParentProgram.Types[BT.GetBclName()];
					}
				}
				if(ResType == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unable to find result type");
				return ResType;
			}
			set {
				base.ResultType = value;
			}
		}
	}
}
