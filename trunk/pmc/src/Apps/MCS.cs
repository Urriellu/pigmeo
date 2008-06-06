using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Mono C# Compiler
	/// </summary>
	public class MCS:App {
		public List<string> SourceFiles = new List<string>();
		public List<string> Modules = new List<string>();

		/// <summary>
		/// If true, makes all the math operations checked (overflow checks)
		/// </summary>
		public bool Checked = false;

		public MCS(string RealName, string UnixName, string Command)
			: base(RealName, UnixName, Command) {
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns></returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running MCS.Run()");

			Parameters.Clear();
			if(Checked) Parameters.Add("-checked");
			foreach(string SrcFile in SourceFiles) {
				Parameters.Add(SrcFile);
			}
			return base.Run();
		}
	}
}
