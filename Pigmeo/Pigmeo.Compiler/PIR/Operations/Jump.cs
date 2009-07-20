using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Unconditional jump to another instruction
	/// </summary>
	public sealed class Jump:JumpingOperation {
		protected Jump(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Jump";
			Arguments = new Operand[1];
		}

		public Jump(Method ParentMethod, PRefl.Instructions.br_s OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstr.Index);
		}

		public Jump(Method ParentMethod, PRefl.Instructions.br OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstr.Index);
		}

		public Jump(Method ParendMethod, int Index)
			: this(ParendMethod) {
			Arguments[0] = new OperationOperand(ParendMethod, Index);
		}

		public override string ToString() {
			return Label + ": Jump to " + Arguments[0];
		}
	}
}
