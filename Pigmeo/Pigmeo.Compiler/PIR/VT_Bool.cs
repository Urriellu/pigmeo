using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class VT_Bool:VT_BaseType {
		protected VT_Bool(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ParentProgram, ReflectedType, IncludeMembers, Internal.BaseType.Bool) {
		}

		public new static VT_Bool NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			return new VT_Bool(ParentProgram, ReflectedType, IncludeMembers);
		}

		public override uint Size {
			get {
				return ParentProgram.Target.NativeIntSize;
			}
		}
	}
}
