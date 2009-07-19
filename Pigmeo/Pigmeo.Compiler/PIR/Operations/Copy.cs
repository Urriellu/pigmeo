using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Copy:Operation {
		protected Copy(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Copy";
			Arguments = new Operand[1];
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldc_i4 OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new ConstantInt32Operand(OrigCilInstr.ConstantValue);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.stsfld OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = new FieldValueOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
		}

		public Copy(Method ParentMethod, PRefl.Instructions.stfld OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = new FieldValueOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldsfld OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new FieldValueOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldsflda OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new FieldAddrOperand(ParentMethod.ParentProgram.Types[OrigCilInstr.ReferencedField.ParentType.FullName].Fields[OrigCilInstr.ReferencedField.Name]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldarg OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new ParameterValueOperand(ParentMethod.Parameters[OrigCilInstr.Argument.Name]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldstr OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new ConstantStringOperand(OrigCilInstr.TheString);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.stloc OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = new LocalVariableValueOperand(ParentMethod.LocalVariables[OrigCilInstr.VariableIndex]);
		}

		public Copy(Method ParentMethod, PRefl.Instructions.ldloc OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new LocalVariableValueOperand(ParentMethod.LocalVariables[OrigCilInstr.VariableIndex]);
			Result = GlobalOperands.TOSS;
		}

		public Copy(Method ParentMethod, PRefl.Instructions.pop OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = GlobalOperands.Nowhere;
		}

		public Copy(Method ParentMethod, Operand Origin, Operand Result)
			: this(ParentMethod) {
			Arguments[0] = Origin;
			this.Result = Result;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " " + Arguments[0];
		}

		public override Type ResultType {
			get {
				if(_ResultType != null) return _ResultType;
				if(Arguments[0] is LocalVariableOperand) return (Arguments[0] as LocalVariableOperand).TheLV.LocalVarType;
				if(Arguments[0] is ParameterOperand) return (Arguments[0] as ParameterOperand).TheParameter.ParamType;
				if(Arguments[0] is FieldOperand) return (Arguments[0] as FieldOperand).TheField.FieldType;
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
				return null;
			}
			set {
				base.ResultType = value;
			}
		}
	}
}
