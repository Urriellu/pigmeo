using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// 
	/// </summary>
	public class Switch:Operation {
		public Operand ComparedOperand {
			get {
				return Arguments[0];
			}
			set {
				Arguments[0] = value;
			}
		}

		public OperationOperand[] OperationJumps;

		protected Switch(Method ParentMethod)
			: base(ParentMethod) {
			Arguments = new Operand[1];
			ComparedOperand = GlobalOperands.TOSS;
		}

		public Switch(Method ParentMethod, PRefl.Instructions.Switch OrigCilInstr)
			: this(ParentMethod) {
			OperationJumps = new OperationOperand[OrigCilInstr.RefdInstrs.Length];
			for(int i = 0; i < OperationJumps.Length; i++) {
				OperationJumps[i] = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstrs[i].Index);
			}
		}

		public override string ToString() {
			string ret = Label + ": switch(" + ComparedOperand + ") {\n";
			for(int i = 0; i < OperationJumps.Length; i++) {
				ret += "\tcase " + i + ":";
				ret += "\t\tJump to " + OperationJumps[i];
			}
			return ret;
		}
	}
}
