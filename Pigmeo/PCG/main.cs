using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PCG {
	public class main {
		[PigmeoToDo("it doesn't work yet")]
		static int Main(string[] args) {
			#region initialization
			config.LoadSettings();
			CmdLine.ParseParams(args);
			PrintMsg.WriteInfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "PCG", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());
			#endregion

			throw new NotImplementedException("Now we should generate code");

			return 0;
		}
	}
}
