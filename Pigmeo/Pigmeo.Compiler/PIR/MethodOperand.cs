using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a class Method
	/// </summary>
	public class MethodOperand:Operand {
		public readonly Method TheMethod;

		public MethodOperand(Method ReferencedMethod) {
			this.TheMethod = ReferencedMethod;
		}

		public override string ToString() {
			return string.Format("[Method]{0}", TheMethod.ToStringRetTypeFullNameArgs());
		}
	}
}
