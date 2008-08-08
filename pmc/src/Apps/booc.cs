using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Boo Compiler
	/// </summary>
	public class booc:NetCompiler {
		public booc(string RealName, string UnixName, string Command) : base(RealName, UnixName, Command) {
			//nothing required
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns>Value returned by the application</returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running booc.Run()");

			Parameters.Clear();
			Parameters.Add("-target:exe");
			if(!Checked) Parameters.Add("-checked-");
			Parameters.Add("-nologo");
			switch(config.Verbosity) {
				case VerbosityLevel.Verbose:
					Parameters.Add("-v");
					break;
				case VerbosityLevel.Debug:
					Parameters.Add("-vvv");
					break;
			}
			Parameters.Add("-debug-");
			if(LibPaths.Count > 0) Parameters.Add("-lib:" + LibPaths.ToArray().CommaSeparatedList(false));
			foreach(string RefLib in RefLibs) Parameters.Add("-reference:" + RefLib);
			Parameters.Add("-o:" + config.CompiledExeFullName);
			foreach(string SrcFile in config.SourceFiles) Parameters.Add(SrcFile);

			return base.Run();
		}
	}
}
