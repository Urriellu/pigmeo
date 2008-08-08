using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Mono C# Compiler
	/// </summary>
	public class MCS:NetCompiler {
		public List<string> Modules = new List<string>();

		public MCS(string RealName, string UnixName, string Command) : base(RealName, UnixName, Command) {
			//nothing required
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns>Value returned by the application</returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running MCS.Run()");

			Parameters.Clear();
			Parameters.Add("-t:exe");
			if(Checked) Parameters.Add("-checked");
			if(LibPaths.Count > 0) Parameters.Add("-lib:" + LibPaths.ToArray().CommaSeparatedList(false));
			if(RefLibs.Count > 0) Parameters.Add("-r:" + RefLibs.ToArray().CommaSeparatedList(false));
			Parameters.Add("-out:" + config.CompiledExeFullName);
			foreach(string SrcFile in config.SourceFiles) {
				Parameters.Add(SrcFile);
			}

			return base.Run();
		}
	}
}
