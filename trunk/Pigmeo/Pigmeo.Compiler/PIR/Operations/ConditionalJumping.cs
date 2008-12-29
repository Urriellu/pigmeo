using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Jumps to other operation based on a condition
	/// </summary>
	public abstract class ConditionalJumping:JumpingOperation {
		protected ConditionalJumping(Method ParentMethod)
			: base(ParentMethod) {
		}
	}
}
