using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class Enum:ValueType {
		protected Enum(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}

		public static Enum NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			switch(ParentProgram.TargetArch) {
				case Architecture.PIC:
					return new PIC.Enum(ParentProgram, ReflectedType, IncludeMembers);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					return null;
			}
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
