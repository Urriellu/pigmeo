using System;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents an exception thrown by Pigmeo.Internal.Reflection
	/// </summary>
	public class ReflectionException:Exception {
		public ReflectionException(string Message)
			: base(Message) {
		}
	}
}
