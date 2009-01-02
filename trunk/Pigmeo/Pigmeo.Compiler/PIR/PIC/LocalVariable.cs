using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	public class LocalVariable:PIR.LocalVariable {
		public LocalVariable(PIR.Method ParentMethod, PRefl.LocalVariable RefldLocalVar)
			: base(ParentMethod, RefldLocalVar) {
		}

		public LocalVariable(PIR.Method ParentMethod, PIR.Type LocalVarType, string Name)
			: base(ParentMethod, LocalVarType, Name) {
		}
	}
}
