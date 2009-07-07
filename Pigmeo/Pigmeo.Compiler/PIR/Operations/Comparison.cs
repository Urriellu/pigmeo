using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Compares two values. Returns 1 if true, 0 if false
	/// </summary>
	public class Comparison:ComparisonOperation {
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

		protected Comparison(Method ParentMethod)
			: base(ParentMethod) {
			Arguments = new Operand[2];
			FirstOperand = SecondOperand = Result= GlobalOperands.TOSS;
		}

		public Comparison(Method ParentMethod, PRefl.Instructions.ceq OrigCilInstr)
			: this(ParentMethod) {
			Condition = Condition.Equal;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " is " + FirstOperand + " " + Condition.ToSymbolString() + " " + SecondOperand + " ?";
		}
	}
}
