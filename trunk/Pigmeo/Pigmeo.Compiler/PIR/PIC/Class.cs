using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Class:PIR.Class {
		public Class(PIR.Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}

		public Class(PIR.Program ParentProgram):base(ParentProgram) {
		}
	}
}
