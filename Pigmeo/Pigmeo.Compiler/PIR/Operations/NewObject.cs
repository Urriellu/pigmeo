using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Allocates a new instance of the class associated with ctor and initializes all the fields in the new instance to 0 (of the proper type) or null as appropriate. It then calls the constructor with the given arguments along with the newly created instance. After the constructor has been called, the now initialized object reference is pushed on the stack
	/// </summary>
	public class NewObject:Call {
		protected NewObject(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "NewObject";
		}

		public NewObject(Method ParentMethod, PRefl.Instructions.newobj OrigCilInstr)
			: this(ParentMethod) {
			Arguments = new Operand[OrigCilInstr.ReferencedMethod.Parameters.Count + 1];
			Arguments[0] = new MethodOperand(ParentProgram.Types[OrigCilInstr.ReferencedMethod.ParentType.FullName].Methods.GetFromPRefl(OrigCilInstr.ReferencedMethod));
			for(int i = 0 ; i < OrigCilInstr.ReferencedMethod.Parameters.Count ; i++) Arguments[i + 1] = GlobalOperands.TOSS;
			Result = GlobalOperands.TOSS;
		}

		/// <summary>
		/// The constructor called
		/// </summary>
		public Method CalledMethod {
			get {
				return ((MethodOperand)Arguments[0]).TheMethod;
			}
		}
	}
}
