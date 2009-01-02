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
				string NewLVname = CalledMethod.Name + "_param_" + param.Name;
				if(Caller.LocalVariables.Contains(NewLVname)) {
					UInt16 i = 0;
					while(Caller.LocalVariables.Contains(NewLVname + i.ToString())) i++;
					NewLVname += i.ToString();
				}
				LocalVariable NewLV = LocalVariable.NewByArch(Caller, param.ParamType, NewLVname);
				Caller.LocalVariables.Add(NewLV);
				ParamRelation.Add(param, NewLV);
			}
			#endregion

			#region creating local variables (in the caller method) for each local variable of the called method
			foreach(LocalVariable LV in CalledMethod.LocalVariables) {
				string NewLVname = CalledMethod.Name + "_LV_" + LV.Name;
				if(Caller.LocalVariables.Contains(NewLVname)) {
					UInt16 i = 0;
					while(Caller.LocalVariables.Contains(NewLVname + i.ToString())) i++;
					NewLVname += i.ToString();
				}
				LocalVariable NewLV = LocalVariable.NewByArch(Caller, LV.LocalVarType, NewLVname);
				Caller.LocalVariables.Add(NewLV);
				LVRelation.Add(LV, NewLV);
			}
			#endregion

			#region in the called method, replacing each reference to parameters and loval variables by references to the new local variables in the caller method
			foreach(Operation Optn in CalledMethod.Operations) {
				if(Optn.Result != null) {
					if(Optn.Result is ParameterOperand) Optn.Result = LocalVariableOperand.GetSameRef((Optn.Result as ParameterOperand), ParamRelation);
					if(Optn.Result is LocalVariableOperand) Optn.Result = LocalVariableOperand.GetSameRef((Optn.Result as LocalVariableOperand), LVRelation);
				}
				if(Optn.Arguments != null) {
					for(int i = 0 ; i < Optn.Arguments.Length ; i++) {
						if(Optn.Arguments[i] is ParameterOperand) Optn.Arguments[i] = LocalVariableOperand.GetSameRef((Optn.Arguments[i] as ParameterOperand), ParamRelation);
						else if(Optn.Arguments[i] is LocalVariableOperand) Optn.Arguments[i] = LocalVariableOperand.GetSameRef((Optn.Arguments[i] as LocalVariableOperand), LVRelation);
					}
				}
			}
			#endregion

			#region operands supposed to be passed as arguments are now copied to the new local variables in the caller method
			for(int i = 1 ; i < CallOperation.Arguments.Length ; i++) {
				Caller.Operations.InsertBefore(CallOperation, new Copy(Caller, CallOperation.Arguments[i], new LocalVariableValueOperand(ParamRelation[CalledMethod.Parameters[(ushort)(i-1)]])));
			}
			#endregion

			#region moving operations from the called method to the caller method
			for(int i = 0 ; i < CalledMethod.Operations.Count ; i++) {
				Caller.Operations.InsertBefore(CallOperation, CalledMethod.Operations[i]);
			}
			#endregion

			#region removing the Call operation, not needed anymore
			Caller.Operations.Remove(CallOperation);
			#endregion

			ShowInfo.InfoDebugDecompile("Caller method after inlining the called one", ParentMethod);
		}

		public override string ToString() {
			string ret = "";
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
