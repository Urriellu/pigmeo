using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents an assembler (its input is an asembly-language source file and its output a binary file)
	/// </summary>
	public class Assembler:App {
		public Assembler(string RealName, string UnixName, string Command)
			: base(RealName, UnixName, Command) {
		}
	}
}
