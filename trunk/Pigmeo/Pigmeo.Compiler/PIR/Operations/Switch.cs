using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Jumps to some operation from a list of available operations, based on the given value
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

		public OperationOperand[] JumpTo {
			get {
				OperationOperand[] OpOpnd = new OperationOperand[Arguments.Length - 1];
				Array.Copy(Arguments, 1, OpOpnd, 0, Arguments.Length - 1);
				return OpOpnd;
			}
		}

		protected Switch(Method ParentMethod)
			: base(ParentMethod) {
		}

		public Switch(Method ParentMethod, PRefl.Instructions.Switch OrigCilInstr)
			: this(ParentMethod) {
			Arguments = new Operand[OrigCilInstr.RefdInstrs.Length + 1];
			Arguments[0] = GlobalOperands.TOSS;
			for(int i = 0; i < OrigCilInstr.RefdInstrs.Length; i++) {
				Arguments[i + 1] = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstrs[i].Index);
			}
		}

		public override string ToString() {
			string ret = Label + ": switch(" + ComparedOperand + ") {\n";
			for(int i = 0; i < Arguments.Length - 1; i++) {
				ret += "\t\tcase " + i + ":\n";
				ret += "\t\t\tJump to " + Arguments[i + 1] + "\n";
			}
			return ret;
		}
	}
}
