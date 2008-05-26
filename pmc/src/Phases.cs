using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public static class Phases {
		[PigmeoToDo("unimplemented")]
		public static void PrintAbout() {
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, i18n.str("HelpTitle"));
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, i18n.str("AppDescription"));
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, i18n.str("Developers"));
			foreach(string developer in config.Developers) {
				PrintMsg.WriteLine(Apps.Pigmeo.PMC, "\t{0}", developer);
			}
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, "");
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, i18n.str("MoreInfo"));
			PrintMsg.WriteLine(Apps.Pigmeo.PMC, "\t{0}", SharedSettings.PrjWebsite);
			Environment.Exit(0);
		}

		[PigmeoToDo("unimplemented")]
		public static void PrintUsage() {
		}

		[PigmeoToDo("unimplemented")]
		public static void PrintInfo() {
		}
	}
}
