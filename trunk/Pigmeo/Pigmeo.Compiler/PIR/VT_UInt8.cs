using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class VT_UInt8:VT_BaseType {
		protected VT_UInt8(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ParentProgram, ReflectedType, IncludeMembers, Internal.BaseType.UInt8) {
		}

		public new static VT_UInt8 NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			return new VT_UInt8(ParentProgram, ReflectedType, IncludeMembers);
		}

		public override uint Size {
			get {
				return 1;
			}
		}
	}
}
