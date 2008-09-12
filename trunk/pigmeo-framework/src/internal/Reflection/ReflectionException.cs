using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Internal.Reflection {
	public class ReflectionException:Exception {
		public ReflectionException(string Message)
			: base(Message) {
		}
	}
}
