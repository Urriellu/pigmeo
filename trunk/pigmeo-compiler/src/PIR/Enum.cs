using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Enum:ValueType {
		public Enum(PRefl.Type ReflectedType, bool IncludeMembers):base(ReflectedType, IncludeMembers) {
		}

		public override Type Clone() {
			return CloneEnum();
		}

		public Class CloneEnum() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}
	}
}
