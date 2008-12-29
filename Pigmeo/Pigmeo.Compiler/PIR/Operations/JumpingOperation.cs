using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Conditional or unconditional jumps to another operation
	/// </summary>
	/// <remarks>
	/// The operation it jumps to is defined in an OperationOperand placed at the end of the Arguments array
	/// </remarks>
	public abstract class JumpingOperation:Operation {
		protected JumpingOperation(Method ParentMethod)
			: base(ParentMethod) {
		}

		public OperationOperand JumpsTo {
			get {
				return (OperationOperand)Arguments[Arguments.Length - 1];
			}
			set {
				Arguments[Arguments.Length - 1] = value;
			}
		}
	}
}
