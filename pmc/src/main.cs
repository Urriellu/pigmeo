using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public class main {
		[PigmeoToDo("it doesn't compile yet")]
		static int Main(string[] args) {
			try {
				#region initialization
				config.LoadSettings();
				CmdLine.ParseParams(args);
				PrintMsg.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "PMC", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());
				#endregion

				Phases.Compile();
			} catch(PmcException e) {
				PrintMsg.WriteErrorLine(Apps.Pigmeo.PMC, "Error: " + e.msg);
			}

			return 0;
		}
	}
}
