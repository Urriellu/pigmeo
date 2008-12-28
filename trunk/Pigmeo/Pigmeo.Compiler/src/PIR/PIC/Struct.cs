using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Struct:PIR.Struct {
		public Struct(PIR.Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}
	}
}
