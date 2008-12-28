using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class VT_Bool:Struct {
		protected VT_Bool(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ParentProgram, ReflectedType, IncludeMembers) {
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
