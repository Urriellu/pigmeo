using System;
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
			for(int i = 0 ; i < OrigCilInstr.ReferencedMethod.Parameters.Count ; i++) Arguments[i + 1] = GlobalOperands.TOSS;
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
			ShowInfo.InfoDebug("Inlining Method Call: " + this);
			ShowInfo.InfoDebugDecompile("InLine Method before being inlined", CalledMethod);

			//correspondence between local variables and parameters of the called method and the new local variables created in the caller method
			Dictionary<LocalVariable, LocalVariable> LVRelation = new Dictionary<LocalVariable, LocalVariable>();
			Dictionary<Parameter, LocalVariable> ParamRelation = new Dictionary<Parameter, LocalVariable>();

			Method Caller = ParentMethod;
			Call CallOperation = this;

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

			#region in the called method, replacing each reference to parameters and local variables by references to the new local variables in the caller method
			foreach(Parameter P in ParamRelation.Keys) {
				CalledMethod.ReplaceRef(P, ParamRelation[P]);
			}
			foreach(LocalVariable LV in LVRelation.Keys) {
				CalledMethod.ReplaceRef(LV, LVRelation[LV]);
			}
			#endregion

			#region operands supposed to be passed as arguments are now copied to the new local variables in the caller method
			for(int i = 1 ; i < CallOperation.Arguments.Length ; i++) {
				Caller.Operations.InsertBefore(CallOperation, new Copy(Caller, CallOperation.Arguments[i], new LocalVariableValueOperand(ParamRelation[CalledMethod.Parameters[(ushort)(i - 1)]])));
			}
			#endregion

			#region moving operations from the called method to the caller method
			for(int i = 0 ; i < CalledMethod.Operations.Count ; i++) {
				if(CalledMethod.Operations[i] is Return) {
					if(CalledMethod.ReturnType.Name == "System.Void") {
						if(i != CalledMethod.Operations.Count - 1) {
							//returning from a method that returns nothing, so we Jump to the next operation after the inlined method
							Caller.Operations.InsertBefore(CallOperation, new Jump(Caller, CallOperation.Index));
						} //if this is a "return" from a method that returns nothing and it's the last operation, do nothing
					} else {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Inlining a method that returns a value");
					}
				} else Caller.Operations.InsertBefore(CallOperation, CalledMethod.Operations[i]);
			}
			#endregion

			#region removing the Call operation, not needed anymore
			Caller.Operations.Remove(CallOperation);
			#endregion

			ShowInfo.InfoDebugDecompile("Caller method after inlining the called one", ParentMethod);
		}

		public override string ToString() {
			string ret = Label + ": ";
			if(Result != null) ret += Result + " " + AssignmentSign + " ";
			ret += "Call(";
			for(int i = 0 ; i < Arguments.Length ; i++) {
				ret += Arguments[i];
				if(i != Arguments.Length - 1) ret += ", ";
			}
			ret += ")";
			return ret;
		}
	}
}
