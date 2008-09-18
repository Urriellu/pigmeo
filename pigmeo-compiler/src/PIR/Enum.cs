using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class Enum:Type {
		public override Type Clone() {
			return CloneEnum();
		}

		public Class CloneEnum() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}
	}
}
