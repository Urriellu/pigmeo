using System;
using PRefl=Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Call:Operation {
		protected Call(Method ParentMethod):base(ParentMethod) {
			Operator = "Call";
		}

		public Call(Method ParentMethod, PRefl.Instructions.call OrigCilInstr):this(ParentMethod) {
			Arguments = new Operand[OrigCilInstr.ReferencedMethod.Parameters.Count + 1];
			Arguments[0] = new MethodOperand(ParentProgram.Types[OrigCilInstr.ReferencedMethod.ParentType.FullName].Methods.GetFromPRefl(OrigCilInstr.ReferencedMethod));
			for(int i = 0 ; i < OrigCilInstr.ReferencedMethod.Parameters.Count ; i++) Arguments[i + 1] = GlobalOperands.TOSS;
			if(OrigCilInstr.ReferencedMethod.ReturnType.FullName != "System.Void") Result = GlobalOperands.TOSS;
		}

		public override string ToString() {
			string ret="";
			if(Result != null) ret += Result + " " + AssignmentSign + " ";
			ret += "Call(";
			for(int i = 0 ; i < Arguments.Length ; i++) {
				ret+=Arguments[i];
				if(i != Arguments.Length - 1) ret += ", ";
			}
			ret += ")";
			return ret;
		}
	}
}
