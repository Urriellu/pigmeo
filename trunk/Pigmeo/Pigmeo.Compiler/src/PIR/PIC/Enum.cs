using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Enum:PIR.Enum {
		public Enum(PIR.Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}
	}
}
