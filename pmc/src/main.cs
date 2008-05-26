using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public class main {
		static int Main(string[] args) {
			config.LoadSettings();
			CmdLine.ParseParams(args);
			PrintMsg.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "PMC", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());

			Console.WriteLine(i18n.str("HelloWorld"));

			return 0;
		}
	}
}
