﻿using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class VT_Int32:Struct {
		protected VT_Int32(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ParentProgram, ReflectedType, IncludeMembers) {
		}

		public new static VT_Int32 NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			return new VT_Int32(ParentProgram, ReflectedType, IncludeMembers);
		}

		public override UInt32 Size {
			get {
				return 4;
			}
		}
	}
}
