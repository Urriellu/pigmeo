using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Extensions to uint8 only available to the compiler
	/// </summary>
	public static class uint8Extensions {
		/// <summary>
		/// Returns an string representing the value in the configured numeral system for the target architecture
		/// </summary>
		public static string ToAsmString(this byte num, Architecture TargetArch) {
			return ((UInt16)num).ToAsmString(TargetArch);
		}
	}
}
