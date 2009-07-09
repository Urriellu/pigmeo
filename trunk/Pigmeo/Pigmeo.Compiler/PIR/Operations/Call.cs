﻿using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public class Call:Operation {
		protected Call(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Call";
		}

		public Call(Method ParentMethod, PRefl.Instructions.call OrigCilInstr)
			: this(ParentMethod) {
			Arguments = new Operand[OrigCilInstr.ReferencedMethod.Parameters.Count + 1];
			Arguments[0] = new MethodOperand(ParentProgram.Types[OrigCilInstr.ReferencedMethod.ParentType.FullName].Methods.GetFromPRefl(OrigCilInstr.ReferencedMethod));
			for(int i = 0; i < OrigCilInstr.ReferencedMethod.Parameters.Count; i++) Arguments[i + 1] = GlobalOperands.TOSS;
			if(OrigCilInstr.ReferencedMethod.ReturnType.FullName != "System.Void") Result = GlobalOperands.TOSS;
		}

		/// <summary>
		/// The PIR Method called from this Call Operation
		/// </summary>
		public Method CalledMethod {
			get {
				return ((MethodOperand)Arguments[0]).TheMethod;
			}
		}


		public void InLine() {
			ShowInfo.InfoDebug("Inlining Method Call: " + this + "...");

			//correspondence between local variables and parameters of the called method and the new local variables created in the caller method
			Dictionary<LocalVariable, LocalVariable> LVRelation = new Dictionary<LocalVariable, LocalVariable>();
			Dictionary<Parameter, LocalVariable> ParamRelation = new Dictionary<Parameter, LocalVariable>();

			Method Caller = ParentMethod;
			Call CallOperation = this;

			ShowInfo.InfoDebugDecompile("Method with an inline call before inlining it", Caller);
			ShowInfo.InfoDebugDecompile("InLine Method before being inlined", CalledMethod);

			int CallOptnOriginalIndex = CallOperation.Index;
			int ExtraOperations = 0;

			#region creating local variables (in the caller method) for each parameter of the called method
			foreach(Parameter param in CalledMethod.Parameters.Values) {
				string NewLvName = Caller.GetAvailLvName(CalledMethod.Name + "_param_" + param.Name);
				LocalVariable NewLV = LocalVariable.NewByArch(Caller, param.ParamType, NewLvName);
				Caller.LocalVariables.Add(NewLV);
				ParamRelation.Add(param, NewLV);
			}
			#endregion

			#region creating local variables (in the caller method) for each local variable of the called method
			foreach(LocalVariable LV in CalledMethod.LocalVariables) {
				string NewLvName = Caller.GetAvailLvName(CalledMethod.Name + "_LV_" + LV.Name);
				LocalVariable NewLV = LocalVariable.NewByArch(Caller, LV.LocalVarType, NewLvName);
				Caller.LocalVariables.Add(NewLV);
				LVRelation.Add(LV, NewLV);
			}
			#endregion

			ShowInfo.InfoDebug("There are {0} local variables and {1} parameters moved from the callee to the caller method", LVRelation.Count, ParamRelation.Count);

			/*#region in the called method, replacing each reference to parameters and local variables by references to the new local variables in the caller method
			foreach(Parameter P in ParamRelation.Keys) {
				CalledMethod.ReplaceRef(P, ParamRelation[P]);
			}
			foreach(LocalVariable LV in LVRelation.Keys) {
				CalledMethod.ReplaceRef(LV, LVRelation[LV]);
			}
			#endregion*/

			#region operands supposed to be passed as arguments are now copied to the new local variables in the caller method
			for(int i = 1; i < CallOperation.Arguments.Length; i++) {
				Caller.Operations.InsertBefore(CallOperation, new Copy(Caller, CallOperation.Arguments[i], new LocalVariableValueOperand(ParamRelation[CalledMethod.Parameters[(ushort)(i - 1)]])));
				ExtraOperations++;
			}
			#endregion

			#region copying operations from the called method to the caller method
			Operation PreviousOp = CallOperation; //operations must be placed AFTER the CallOperation so when CallOperation is removed, the first operation of the inlined method will get the old index the CallOperation had (so jumps to the CallOperation won't break)
			for(int i = 0; i < CalledMethod.Operations.Count; i++) {
				Operation MovingOp;

				if(CalledMethod.Operations[i] is Return) {
					if(CalledMethod.ReturnType.Name == "System.Void") {
						if(i != CalledMethod.Operations.Count - 1) {
							//returning from a method that returns nothing, so we Jump to the next operation after the inlined method
							MovingOp = new Jump(Caller, CallOperation.Index);
						} else {
							//if this is a "return" from a method that returns nothing and it's the last operation, do nothing
							//MovingOp = null;
							continue;
						}
					} else {
						MovingOp = null;
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Inlining a method that returns a value");
					}
				} else {
					MovingOp = CalledMethod.Operations[i].CloneOperation();
					Console.WriteLine("Same operand?" + object.ReferenceEquals(CalledMethod.Operations[i].Result, MovingOp.Result));
				}

				MovingOp.ParentMethod = Caller;
				Caller.Operations.InsertAfter(PreviousOp, MovingOp);
				PreviousOp = MovingOp;
			}
			#endregion

			#region removing the Call operation, not needed anymore
			Caller.Operations.Remove(CallOperation);
			#endregion

			#region Update references to parameters, local variables and operations
			foreach(Parameter P in ParamRelation.Keys) {
				Caller.ReplaceRef(P, ParamRelation[P]);
			}
			foreach(LocalVariable LV in LVRelation.Keys) {
				Caller.ReplaceRef(LV, LVRelation[LV]);
			}

			//Caller.UpdateIndices(CallOptnOriginalIndex, CalledMethod.Operations.Count, OptnsOffset);

			for(int i = CallOptnOriginalIndex + ExtraOperations; i < CallOptnOriginalIndex + ExtraOperations + CalledMethod.Operations.Count; i++) {
				Operation CurrOptn = Caller.Operations[i];
				if(CurrOptn.Arguments != null) {
					for(int j = 0; j < CurrOptn.Arguments.Length; j++) {
						Console.WriteLine("a");
						Console.WriteLine(CurrOptn);
						Console.WriteLine(CalledMethod.Operations[i - CallOptnOriginalIndex - ExtraOperations]);
						if(CurrOptn.Arguments[j] is OperationOperand) {
							(CurrOptn.Arguments[j] as OperationOperand).OperationIndex = (CalledMethod.Operations[i - CallOptnOriginalIndex - ExtraOperations].Arguments[j] as OperationOperand).OperationIndex + CallOptnOriginalIndex + ExtraOperations;
						}
					}
				}
			}
			#endregion

			ShowInfo.InfoDebugDecompile("Caller method after inlining the called one", ParentMethod);
			ShowInfo.InfoDebugDecompile("InLine Method after being inlined (should be the same as before)", CalledMethod);
			Environment.Exit(1);
		}

		public override string ToString() {
			string ret = Label + ": ";
			if(Result != null) ret += Result + " " + AssignmentSign + " ";
			ret += Operator + "(";
			for(int i = 0; i < Arguments.Length; i++) {
				ret += Arguments[i];
				if(i != Arguments.Length - 1) ret += ", ";
			}
			ret += ")";
			return ret;
		}
	}
}
