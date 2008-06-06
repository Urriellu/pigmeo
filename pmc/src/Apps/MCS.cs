using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Mono C# Compiler
	/// </summary>
	public class MCS:App {
		/// <summary>
		/// List of source files being compiled
		/// </summary>
		public List<string> SourceFiles = new List<string>();

		/// <summary>
		/// List of paths where libraries will be looked for
		/// </summary>
		public List<string> LibPaths = new List<string>();

		/// <summary>
		/// List of referenced libraries/assemblies
		/// </summary>
		public List<string> RefLibs = new List<string>();

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
			Parameters.Add("-t:exe");
			if(Checked) Parameters.Add("-checked");
			if(LibPaths.Count > 0) Parameters.Add("-lib:" + LibPaths.ToArray().CommaSeparatedList(false));
			if(RefLibs.Count > 0) Parameters.Add("-r:" + RefLibs.ToArray().CommaSeparatedList(false));
			Parameters.Add("-out:" + config.CompiledExeFullName);
			foreach(string SrcFile in SourceFiles) {
				Parameters.Add(SrcFile);
			}

			return base.Run();
		}
	}
}
