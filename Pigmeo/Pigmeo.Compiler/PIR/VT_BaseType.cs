using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class VT_BaseType:Struct {
		protected VT_BaseType(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers, Internal.BaseType ReprBaseType)
			: base(ParentProgram, ReflectedType, IncludeMembers) {
			IsBaseType = true;
			this.ReprBaseType = ReprBaseType;
		}
	}
}
