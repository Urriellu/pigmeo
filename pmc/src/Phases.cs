using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public static class Phases {
		/// <summary>
		/// Prints information about PMC
		/// </summary>
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

		/// <summary>
		/// Prints information about how to use this application
		/// </summary>
		public static void PrintUsage() {
			PrintMsg.WriteLine("Pigmeo Multi Compiler " + SharedSettings.AppVersion);
			PrintMsg.WriteLine(i18n.str("AppDescription"));
			PrintMsg.WriteLine(i18n.str("CmdParams"));
			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("PmcParams"));
			PrintMsg.WriteLine(i18n.str("param_about"));
			PrintMsg.WriteLine(i18n.str("param_help"));
			PrintMsg.WriteLine(i18n.str("param__not_translated"));
			PrintMsg.WriteLine(i18n.str("param_todo"));

			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("GlobalParams"));
			PrintMsg.WriteLine(i18n.str("param_debug"));

			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("CmdExample"));

			Environment.Exit(0);
		}

		/// <summary>
		/// Prints the list of language strings not yet translated to the current language
		/// </summary>
		public static void PrintNotTranslated() {
			foreach(string str in i18n.LangStrNotTranslated) {
				PrintMsg.WriteLine("{0}: {1}", str, i18n.StrBulk(str));
			}
			Environment.Exit(0);
		}
	}
}
