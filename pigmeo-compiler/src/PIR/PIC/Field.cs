using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Field:PIR.Field {
		public Location Location;

		[PigmeoToDo("Find CustomAttribute Location()")]
		public Field(PRefl.Field ReflectedField) {
		}
	}
}
