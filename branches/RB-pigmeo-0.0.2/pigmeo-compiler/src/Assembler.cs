using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.Compiler {
	public static class Assembler {
		public static void RunAssembler() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Assembler");
		}
	}
}
