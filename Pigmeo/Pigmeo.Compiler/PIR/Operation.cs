using System;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// PIR Operation
	/// </summary>
	/// <remarks>
	/// An operation can be thought as a function or low level instruction
	/// </remarks>
	public abstract class Operation {
		public Program ParentProgram {
			get {
				return ParentMethod.ParentProgram;
			}
		}

		public Method ParentMethod;

		public int Index {
			get {
				return ParentMethod.Operations.IndexOf(this);
			}
		}

		public bool IsVolatile = false;

		/// <summary>
		/// Operator (+, -, Copy, Call...)
		/// </summary>
		public string Operator { get; protected set; }

		/// <summary>
		/// Operation arity (number of arguments)
		/// </summary>
		public int Arity {
			get {
				if(Arguments != null) return Arguments.Length;
				else return 0;
			}
		}

		/// <summary>
		/// Operation arguments
		/// </summary>
		public Operand[] Arguments;

		/// <summary>
		/// Operand which indicates the place where the result of this operation will be stored
		/// </summary>
		public Operand Result;

		public override string ToString() {
			if(Arity == 0) {
				if(Result == null) return Label + ": " + Operator;
				else return Label + ": " + Result + " " + AssignmentSign + " " + Operator;
			} else if(Arity == 2) {
				if(Result == null) return Label + ": " + Arguments[0] + " " + Operator + " " + Arguments[1];
				else return Label + ": " + Result + " " + AssignmentSign + " " + Arguments[0] + " " + Operator + " " + Arguments[1];
			} else {
				string ret = Label + ": ";
				if(Result != null) ret += Result + " " + AssignmentSign + " ";
				ret += Operator + "(";
				for(int i = 0 ; i < Arguments.Length ; i++) {
					ret += Arguments[i].ToString();
					if(i != Arguments.Length - 1) ret += ", ";
				}
				ret += ")";
				return ret;
			}
		}

		/// <summary>
		/// Indicates if this operation probably modifies the value of the given Local Variable
		/// </summary>
		public bool PotentiallyModifies(LocalVariable LV) {
			if(Result != null) {
				if(Result is LocalVariableOperand && ((LocalVariableOperand)Result).TheLV == LV) return true;
			}
			if(Arguments != null) {
				foreach(Operand Opnd in Arguments) {
					if(Opnd is LocalVariableAddrOperand && ((LocalVariableAddrOperand)Opnd).TheLV == LV) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Indicates if this operation probably modifies the value of the given Parameter
		/// </summary>
		public bool PotentiallyModifies(Parameter P) {
			if(Result != null) {
				if(Result is ParameterOperand && ((ParameterOperand)Result).TheParameter == P) return true;
			}
			if(Arguments != null) {
				foreach(Operand Opnd in Arguments) {
					if(Opnd is ParameterAddrOperand && ((ParameterAddrOperand)Opnd).TheParameter == P) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Indicates if this operation probably modifies the value of the given Field
		/// </summary>
		public bool PotentiallyModifies(Field F) {
			if(Result != null) {
				if(Result is FieldOperand && ((FieldOperand)Result).TheField == F) return true;
			}
			if(Arguments != null) {
				foreach(Operand Opnd in Arguments) {
					if(Opnd is FieldAddrOperand && ((FieldAddrOperand)Opnd).TheField == F) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Inidicates if this Operation uses the value of a given Local Variable. Note: this method doesn't check if its value is modified, only used
		/// </summary>
		/// <returns>
		/// Amount of times the value of the Local Variable is used by this Operation
		/// </returns>
		public UInt16 Uses(LocalVariable LV) {
			UInt16 Count = 0;
			if(Arguments != null) {
				foreach(Operand Opnd in Arguments) {
					if((Opnd is LocalVariableValueOperand || Opnd is LocalVariableBitOperand) && ((LocalVariableOperand)Opnd).TheLV == LV) Count++;
				}
			}
			return Count;
		}

		public string Label {
			get {
				return string.Format("Op_{0:x3}", Index);
			}
		}

		public string AsmLabel {
			get {
				return string.Format("{0}_Op_{1:x3}", ParentMethod.AsmName, Index);
			}
		}

		protected const string AssignmentSign = ":=";

		protected Operation(Method ParentMethod) {
			this.ParentMethod = ParentMethod;
		}

		#region static methods
		public static Operation GetFromPRefl(PRefl.Instruction InstrBeingParsed, Method ParentMethod) {
			ShowInfo.InfoDebug("Converting the P.I.Reflection Instruction {0} to a PIR Operation in method {1}", InstrBeingParsed.ToString(), ParentMethod.ToStringRetTypeNameArgs());
			Operation RetOp = null;
			if(InstrBeingParsed is PRefl.Instructions.add) RetOp = new Add(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.and) RetOp = new AND(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.beq) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.beq);
			else if(InstrBeingParsed is PRefl.Instructions.br) RetOp = new Jump(ParentMethod, InstrBeingParsed as PRefl.Instructions.br);
			else if(InstrBeingParsed is PRefl.Instructions.br_s) RetOp = new Jump(ParentMethod, InstrBeingParsed as PRefl.Instructions.br_s);
			else if(InstrBeingParsed is PRefl.Instructions.brfalse) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.brfalse);
			else if(InstrBeingParsed is PRefl.Instructions.call) RetOp = new Call(ParentMethod, InstrBeingParsed as PRefl.Instructions.call);
			else if(InstrBeingParsed is PRefl.Instructions.conv) RetOp = null;
			else if(InstrBeingParsed is PRefl.Instructions.ldc_i4) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldc_i4);
			else if(InstrBeingParsed is PRefl.Instructions.ldloc) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldloc);
			else if(InstrBeingParsed is PRefl.Instructions.ldsfld) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldsfld);
			else if(InstrBeingParsed is PRefl.Instructions.ldsflda) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldsflda);
			else if(InstrBeingParsed is PRefl.Instructions.ldarg) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldarg);
			else if(InstrBeingParsed is PRefl.Instructions.or) RetOp = new OR(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.ret) RetOp = new Return(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.shl) RetOp = new ShiftLeft(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.stloc) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.stloc);
			else if(InstrBeingParsed is PRefl.Instructions.stsfld) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.stsfld);
			else if(InstrBeingParsed is PRefl.Instructions.Volatile) RetOp = null;
			else if(InstrBeingParsed is PRefl.Instructions.xor) RetOp = new XOR(ParentMethod);
			else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Convertion of CIL instruction " + InstrBeingParsed.ToString() + " to PIR not implemented yet");

			if(InstrBeingParsed != null && InstrBeingParsed.Previous is PRefl.Instructions.Volatile) {
				RetOp.IsVolatile = true;
				foreach(Operand Opnd in RetOp.Arguments) {
					if(Opnd is FieldOperand) ((FieldOperand)Opnd).TheField.IsVolatile = true;
				}
			}

			if(RetOp != null) ShowInfo.InfoDebug("P.I.Reflection Instruction converted to PIR as {0}", RetOp.ToString());
			else ShowInfo.InfoDebug("This P.I.Reflection Instruction was NOT converted to PIR");

			return RetOp;
		}
		#endregion
	}
}
