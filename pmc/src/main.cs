using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public class main {
		[PigmeoToDo("it doesn't compile yet")]
		static int Main(string[] args) {
			#region initialization
			config.LoadSettings();
			CmdLine.ParseParams(args);
			PrintMsg.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "PMC", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());
			#endregion

			#region choosing high level language
			if(config.CompilingLang == null) {
				PrintMsg.InfoDebug("High level language not specified. Trying to detect it");
				if(config.SourceFiles[0].EndsWith(".cs", StringComparison.CurrentCultureIgnoreCase)) config.CompilingLang=CLILanguages.CSharp;
				else throw new PmcException(i18n.str("UnkHlLang"));
			}
			#endregion

			#region choosing applications
			if(Apps.HL.UsedComp == null) {
				PrintMsg.InfoDebug("High-level language compiler not set. Looking for an installed one");
				Apps.HL.UsedComp = Apps.HL.FindAny(config.CompilingLang);
			}
			if(Apps.HL.UsedComp == null) throw new PmcException(i18n.str("NoHlCompiler", config.CompilingLang.ToString()));

			if(Apps.Assemblers.UsedAss == null) {
				PrintMsg.InfoDebug("Assembler not set. Looking for an installed one");
				Apps.Assemblers.UsedAss = Apps.Assemblers.FindAnyAss();
			}
			if(Apps.Assemblers.UsedAss == null) throw new PmcException(i18n.str("NoAss"));
			#endregion

			#region compiling
			PrintMsg.InfoDebug("Compilation will start now using {0}", Apps.HL.UsedComp.RealName);
			throw new PmcException("Unimplemented");
			#endregion

			return 0;
		}
	}
}
