using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Extensions to UInt16 only available to the compiler
	/// </summary>
	public static class UInt16Extensions {
		/// <summary>
		/// Returns an string representing the value in the configured numeral system for the target architecture
		/// </summary>
		public static string ToAsmString(this UInt16 num, Architecture TargetArch) {
			string str = "";
			switch(TargetArch) {
				case Architecture.PIC:
					switch(config.Internal.NumeralSystem) {
						case NumeralSystems.Binary:
							str="B'" + Convert.ToString(num, 2) + "'";
							break;
						case NumeralSystems.Decimal:
							str="D'" + Convert.ToString(num, 10) + "'";
							break;
						case NumeralSystems.Hexadecimal:
							str = "0x" + num.ToString((num<256)?"X2":"X4");
							break;
						case NumeralSystems.Octal:
							str = "O'" + Convert.ToString(num, 8) + "'";
							break;
						default:
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0002", false, config.Internal.NumeralSystem.ToString());
							break;
					}
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0001", false, TargetArch.ToString());
					break;
			}
			ShowInfo.InfoDebug("A variable has been converted to a string. Number: {0}, Architecture: {1}, Numeral System: {2}, Result: {3}", num, TargetArch.ToString(), config.Internal.NumeralSystem, str);
			return str;
		}
	}
}
