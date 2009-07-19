using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Conversion:Operation {
		public BaseType TargetType;

		protected Conversion(Method ParentMethod)
			: base(ParentMethod) {
			Operator = "Convert";
			Arguments = new Operand[1];
		}

		public Conversion(Method ParentMethod, PRefl.Instructions.conv OrigCilInstr)
			: this(ParentMethod) {
			Arguments[0] = GlobalOperands.TOSS;
			Result = GlobalOperands.TOSS;
			TargetType = OrigCilInstr.TargetType;
		}

		public override string ToString() {
			return Label + ": " + Result + " " + AssignmentSign + " Convert " + Arguments[0] + " to " + TargetType.ToString();
		}

		public override Type ResultType {
			get {
				return ParentProgram.Types[TargetType.GetBclName()];
			}
			set {
				base.ResultType = value;
			}
		}
	}
}
