using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Extensions;

namespace Pigmeo.PMC {
	/// <summary>
	/// 
	/// </summary>
	public class gpasm:Assembler {
		public gpasm(string RealName, string UnixName, string Command) : base(RealName, UnixName, Command) {
			//nothing required
		}

		/// <summary>
		/// Generates the list of parameters which will be passed to the command and then base.Run() executes the application using the given "Command" and "Parameters"
		/// </summary>
		/// <returns>Value returned by the application</returns>
		public override int Run() {
			PrintMsg.InfoDebug("Running gpasm.Run()");

			Parameters.Clear();

			if(config.Verbosity == VerbosityLevel.Quiet) Parameters.Add("-q");
			if(config.Verbosity == VerbosityLevel.Debug) Parameters.Add("-d");
			//Parameters.Add("-o " + OutputBinFile);
			Parameters.Add(config.AsmFilePath);

			return base.Run();
		}
	}
}
