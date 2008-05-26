using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents a software application that can be called from within PMC
	/// </summary>
	public class App {
		public readonly string RealName;
		public readonly string UnixName;
		public readonly string Command;

		public App(string RealName, string UnixName, string Command) {
			this.RealName = RealName;
			this.UnixName = UnixName;
			this.Command = Command;
		}
	}
}
