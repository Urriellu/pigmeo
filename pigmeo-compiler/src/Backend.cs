using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.Compiler {
	public static class Backend {
		/// <summary>
		/// Parses a bundled assembly generated from Frontend() and converts it to assembly code
		/// </summary>
		/// <remarks>
		/// Before calling this method take care of the required variables placed in the config class (TargetDeviceInfo...)
		/// </remarks>
		public static void RunBackend() {
			//config.Compilation.TargetDeviceInfo = new InfoDevice("PIC16F716");

			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Backend not finished");
		}
	}
}
