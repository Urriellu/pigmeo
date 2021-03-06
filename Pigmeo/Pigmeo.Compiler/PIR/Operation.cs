﻿using System;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// PIR Operation
	/// </summary>
	/// <remarks>
	/// An operation can be thought as a function or low level instruction
	/// </remarks>
	public abstract class Operation:ICloneable {
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
		public Operand[] Arguments = new Operand[0];

		/// <summary>
		/// Operand which indicates the place where the result of this operation will be stored
		/// </summary>
		public Operand Result;

		/// <summary>
		/// Type of the value returned by this operation
		/// </summary>
		//Operations with dynamic result values should override this. Operations with well-known result types should indicate it in _ResultType
		public virtual Type ResultType {
			get {
				if(_ResultType == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, string.Format("Unknown result type. PIR Operation: {0}  -  {1}", this.GetType().ToString(), this.ToString()));
				return _ResultType;
			}
			set {
				_ResultType = value;
			}
		}
		protected Type _ResultType = null;

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
				for(int i = 0; i < Arguments.Length; i++) {
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

		/// <summary>
		/// Indicates if this operation consumes a pointer to an object placed on top of the stack
		/// </summary>
		public bool UsesOBjPntrFromTOSS {
			get {
				if(this is Copy && (this as Copy).Arguments[0] is FieldOperand && !((this as Copy).Arguments[0] as FieldOperand).TheField.IsStatic) return true;
				if(this is Copy && Result is FieldOperand && !(Result as FieldOperand).TheField.IsStatic) return true;
				return false;
			}
		}

		protected const string AssignmentSign = ":=";

		protected Operation(Method ParentMethod) {
			this.ParentMethod = ParentMethod;
		}

		/// <summary>
		/// If this operation has constant argument it will probably will contantized, which means it will be executed on compilation-time, instead of run-time
		/// </summary>
		/// <returns>True if this operation was contantized</returns>
		//This method should be overriden by derived classes whenever they are able to be optimized
		public virtual bool Constantize() {
			return false;
		}

		#region static methods
		public static Operation GetFromPRefl(PRefl.Instruction InstrBeingParsed, Method ParentMethod) {
			// NOTE: we cannot return null because it breaks the indices of CIL instructions->PIR operations. Return a RemovableOperation so it will be removed without breaking indices
			ShowInfo.InfoDebug("Converting the P.I.Reflection Instruction {0} to a PIR Operation in method {1}", InstrBeingParsed.ToString(), ParentMethod.ToStringRetTypeNameArgs());
			Operation RetOp = null;
			if(InstrBeingParsed is PRefl.Instructions.add) RetOp = new Add(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.and) RetOp = new AND(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.beq) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.beq);
			else if(InstrBeingParsed is PRefl.Instructions.bge) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.bge);
			else if(InstrBeingParsed is PRefl.Instructions.bne_un) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.bne_un);
			else if(InstrBeingParsed is PRefl.Instructions.br) RetOp = new Jump(ParentMethod, InstrBeingParsed as PRefl.Instructions.br);
			else if(InstrBeingParsed is PRefl.Instructions.br_s) RetOp = new Jump(ParentMethod, InstrBeingParsed as PRefl.Instructions.br_s);
			else if(InstrBeingParsed is PRefl.Instructions.brfalse) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.brfalse);
			else if(InstrBeingParsed is PRefl.Instructions.brtrue) RetOp = new ComparisonConditionalJump(ParentMethod, InstrBeingParsed as PRefl.Instructions.brtrue);
			else if(InstrBeingParsed is PRefl.Instructions.call) RetOp = new Call(ParentMethod, InstrBeingParsed as PRefl.Instructions.call);
			else if(InstrBeingParsed is PRefl.Instructions.callvirt) RetOp = new CallVirtual(ParentMethod, InstrBeingParsed as PRefl.Instructions.callvirt);
			else if(InstrBeingParsed is PRefl.Instructions.ceq) RetOp = new Comparison(ParentMethod, InstrBeingParsed as PRefl.Instructions.ceq);
			else if(InstrBeingParsed is PRefl.Instructions.conv) RetOp = new Conversion(ParentMethod, InstrBeingParsed as PRefl.Instructions.conv);
			else if(InstrBeingParsed is PRefl.Instructions.ldc_i4) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldc_i4);
			else if(InstrBeingParsed is PRefl.Instructions.ldloc) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldloc);
			else if(InstrBeingParsed is PRefl.Instructions.ldsfld) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldsfld);
			else if(InstrBeingParsed is PRefl.Instructions.ldsflda) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldsflda);
			else if(InstrBeingParsed is PRefl.Instructions.ldstr) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldstr);
			else if(InstrBeingParsed is PRefl.Instructions.ldarg) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.ldarg);
			else if(InstrBeingParsed is PRefl.Instructions.newobj) RetOp = new NewObject(ParentMethod, InstrBeingParsed as PRefl.Instructions.newobj);
			else if(InstrBeingParsed is PRefl.Instructions.or) RetOp = new OR(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.pop) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.pop);
			else if(InstrBeingParsed is PRefl.Instructions.ret) RetOp = new Return(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.shl) RetOp = new ShiftLeft(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.shr) RetOp = new ShiftRight(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.stfld) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.stfld);
			else if(InstrBeingParsed is PRefl.Instructions.stloc) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.stloc);
			else if(InstrBeingParsed is PRefl.Instructions.stsfld) RetOp = new Copy(ParentMethod, InstrBeingParsed as PRefl.Instructions.stsfld);
			else if(InstrBeingParsed is PRefl.Instructions.sub) RetOp = new Subtract(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.Switch) RetOp = new Switch(ParentMethod, InstrBeingParsed as PRefl.Instructions.Switch);
			else if(InstrBeingParsed is PRefl.Instructions.Throw) RetOp = new Throw(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.Volatile) RetOp = new RemovableOperation(ParentMethod);
			else if(InstrBeingParsed is PRefl.Instructions.xor) RetOp = new XOR(ParentMethod);
			else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Convertion of CIL instruction " + InstrBeingParsed.ToString() + " to PIR not implemented yet. Found in method " + ParentMethod.FullName);

			if(InstrBeingParsed != null && InstrBeingParsed.Previous != null && InstrBeingParsed.Previous is PRefl.Instructions.Volatile) {
				RetOp.IsVolatile = true;
				foreach(Operand Opnd in RetOp.Arguments) {
					if(Opnd is FieldOperand) ((FieldOperand)Opnd).TheField.IsVolatile = true;
				}
			}

			if(RetOp != null) ShowInfo.InfoDebug("P.I.Reflection Instruction converted to PIR as {0}", RetOp.ToString());
			else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", false, "Trying to return a null operation");

			return RetOp;
		}
		#endregion

		public object Clone() {
			ShowInfo.InfoDebug("Cloning operation " + this.ToString());
			Operation NewOptn = (Operation)this.MemberwiseClone();
			if(Arguments != null) {
				NewOptn.Arguments = new Operand[Arguments.Length];
				for(int i = 0; i < this.Arguments.Length; i++) {
					NewOptn.Arguments[i] = this.Arguments[i].CloneOperand();
					if(object.ReferenceEquals(this.Arguments[i], NewOptn.Arguments[i])) throw new Exception("Operand (argument " + i + ") not cloned");
				}
			}
			if(Result != null) {
				NewOptn.Result = this.Result.CloneOperand();
				if(object.ReferenceEquals(this.Result, NewOptn.Result)) throw new Exception("Operand (result) not cloned");
			}
			if(object.ReferenceEquals(this, NewOptn)) throw new Exception("Operation not cloned");
			return NewOptn;
		}

		public Operation CloneOperation() {
			return (Operation)Clone();
		}
	}
}
