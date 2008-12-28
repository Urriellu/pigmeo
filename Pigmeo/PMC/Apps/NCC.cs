using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Nemerle Compiler
	/// </summary>
	public class NCC:NetCompiler {
		public NCC(string RealName, string UnixName, string Command) : base(RealName, UnixName, Command) {
			//nothing required
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns>Value returned by the application</returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running NCC.Run()");

			Parameters.Clear();
			Parameters.Add("-t:exe");
			if(Checked) Parameters.Add("-checked");
			//Parameters.Add("-no-stdmacros");
			Parameters.Add("-nologo");
			Parameters.Add("-no-color");
			Parameters.Add("-progress-bar-");
			Parameters.Add("-debug-");
			foreach(string LibPath in LibPaths) Parameters.Add("-library-path:" + LibPath);
			foreach(string RefLib in RefLibs) Parameters.Add("-reference:"+RefLib);
			Parameters.Add("-out:" + config.CompiledExePath);
			foreach(string SrcFile in config.SourceFiles) Parameters.Add(SrcFile);

			return base.Run();
		}
	}
}
