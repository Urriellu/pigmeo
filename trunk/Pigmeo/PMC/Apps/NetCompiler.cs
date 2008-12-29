using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// A .NET compiler which outputs CIL bytecodes (.NET executable files)
	/// </summary>
	public class NetCompiler:App {
		/// <summary>
		/// List of paths where libraries will be looked for
		/// </summary>
		public List<string> LibPaths = new List<string>();

		/// <summary>
		/// List of referenced libraries/assemblies
		/// </summary>
		public List<string> RefLibs = new List<string>();

		/// <summary>
		/// If true, makes all the math operations checked (overflow checks)
		/// </summary>
		public bool Checked = false;

		public NetCompiler(string RealName, string UnixName, string Command) : base(RealName, UnixName, Command) {
			//automatically referenced libraries
			RefLibs.Add("Pigmeo.dll");
			RefLibs.Add("Pigmeo.MCU");
		}
	}
}
