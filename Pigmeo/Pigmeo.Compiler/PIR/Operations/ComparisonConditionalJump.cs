using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Compares two values and jumps to another operation if the condition is true
	/// </summary>
	public class ComparisonConditionalJump:ConditionalJumping {
		public Operand FirstOperand {
			get {
				return Arguments[0];
			}
			set {
				Arguments[0] = value;
			}
		}

		public Operand SecondOperand {
			get {
				return Arguments[1];
			}
			set {
				Arguments[1] = value;
			}
		}

		public Condition Condition {
			get {
				if(!_Condition.HasValue) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", true);
				return _Condition.Value;
			}
			set {
				Operator = value.ToSymbolString();
				_Condition = value;
			}
		}
		protected Condition? _Condition;

		protected ComparisonConditionalJump(Method ParentMethod)
			: base(ParentMethod) {
			Arguments = new Operand[3];
			FirstOperand = SecondOperand = GlobalOperands.TOSS;
		}

		public ComparisonConditionalJump(Method ParentMethod, PRefl.Instructions.brfalse OrigCilInstr)
			: this(ParentMethod) {
			Condition = Condition.Equal;
			SecondOperand = new ConstantInt32Operand(0);
			JumpsTo = new OperationOperand(ParentMethod, OrigCilInstr.RefdInstr.Index); //this is Arguments[2]
		}

		public override string ToString() {
			return Label + ": if(" + FirstOperand + " " + Condition.ToSymbolString() + " " + SecondOperand + ") Jump to \"" + JumpsTo + "\"";
		}
	}
}
