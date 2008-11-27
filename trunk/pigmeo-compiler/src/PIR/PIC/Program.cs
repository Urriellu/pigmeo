using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents a Program for Microchip PIC Microcontrollers
	/// </summary>
	public class Program:PIR.Program {
		/// <summary>
		/// Assign the Location() attribute to static fields that don't have it yet
		/// </summary>
		public void AssignLocations() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false);
		}
	}
}
