using System;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is an Operation
	/// </summary>
	public class OperationOperand:Operand {
		public Method ParentMethod;
		public int OperationIndex;

		public Operation TheOperation {
			get {
				try {
					return ParentMethod.Operations[OperationIndex];
				} catch(ArgumentOutOfRangeException) {
					throw new ArgumentOutOfRangeException(string.Format("Trying to get operation at index {0} in method {1}. That method has {2} operations", OperationIndex, ParentMethod.FullName, ParentMethod.Operations.Count));
				}
			}
		}

		public OperationOperand(Method ParentMethod, int OperationIndex) {
			this.ParentMethod = ParentMethod;
			this.OperationIndex = OperationIndex;
		}

		public override string ToString() {
			return string.Format("[Operation]Op_{0:x3}", OperationIndex);
		}
	}
}
