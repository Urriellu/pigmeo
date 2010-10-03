using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Calls a method based on the run-time type of an object
	/// </summary>
	public class CallVirtual:Call {
		protected CallVirtual(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "CallVirtual";
		}

		public CallVirtual(Method ParentMethod, PRefl.Instructions.callvirt OrigCilInstr)
			: this(ParentMethod) {
			Arguments = new Operand[OrigCilInstr.ReferencedMethod.Parameters.Count + 1];
			Arguments[0] = new MethodOperand(ParentProgram.Types[OrigCilInstr.ReferencedMethod.ParentType.FullName].Methods.GetFromPRefl(OrigCilInstr.ReferencedMethod));
			for(int i = 0 ; i < OrigCilInstr.ReferencedMethod.Parameters.Count ; i++) Arguments[i + 1] = GlobalOperands.TOSS;
			if(OrigCilInstr.ReferencedMethod.ReturnType.FullName != "System.Void") Result = GlobalOperands.TOSS;
		}

		/*/// <summary>
		/// The constructor called
		/// </summary>
		public Method CalledMethod {
			get {
				return ((MethodOperand)Arguments[0]).TheMethod;
			}
		}*/
	}
}
