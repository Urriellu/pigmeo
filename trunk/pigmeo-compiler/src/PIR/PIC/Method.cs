using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Method:PIR.Method {
		/// <summary>
		/// Make operations use the PIC Working Register (W)
		/// </summary>
		public bool MakeOperationsUseW() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return false;
		}
	}
}
