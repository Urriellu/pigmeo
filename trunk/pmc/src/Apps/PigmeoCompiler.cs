using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PMC {
	/// <summary>
	/// The Pigmeo Compiler application
	/// </summary>
	public class PigmeoCompiler:App {
		public PigmeoCompiler(string RealName, string UnixName, string Command)
			: base(RealName, UnixName, Command) {
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns></returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running PigmeoCompiler.Run()");

			Parameters.Clear();
			Parameters.Add("--ui console");
			if(config.Verbosity == VerbosityLevel.Verbose) Parameters.Add("--verbose");
			if(config.Verbosity == VerbosityLevel.Debug) Parameters.Add("--debug");
			Parameters.Add(config.CompiledExePath);

			return base.Run();
		}
	}
}
