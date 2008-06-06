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
			PrintMsg.WriteLine(i18n.str("param_hl_compiler", Apps.HL.List));
			PrintMsg.WriteLine(i18n.str("param_hl_lang"));
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

		/// <summary>
		/// Runs the entire compilation
		/// </summary>
		public static void Compile() {
			PrintMsg.InfoDebug("Running the compilation");

			if(config.SourceFiles.Count == 0) throw new PmcException(i18n.str("NoSrcFiles"));

			#region choosing high level language
			if(config.CompilingLang == null) {
				PrintMsg.InfoDebug("High level language not specified. Trying to detect it");
				if(config.SourceFiles[0].EndsWith(".cs", StringComparison.CurrentCultureIgnoreCase)) {
					config.CompilingLang = CLILanguages.CSharp;
					PrintMsg.InfoDebug("C# source files detected");
				} else if(config.SourceFiles[0].EndsWith(".vb", StringComparison.CurrentCultureIgnoreCase)){
					config.CompilingLang = CLILanguages.VBNET;
					PrintMsg.InfoDebug("Visual Basic .NET source files detected");
				} else throw new PmcException(i18n.str("UnkHlLang"));
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
			PrintMsg.InfoDebug("Compilation will start now using {0}, then {1} and finally {2}", Apps.HL.UsedComp.RealName, Apps.Pigmeo.PigmeoCompiler.RealName, Apps.Assemblers.UsedAss.RealName);

			PrintMsg.InfoDebug("Running the high level language compiler: {0}", Apps.HL.UsedComp.RealName);
			int HlCompRet = Apps.HL.UsedComp.Run();
			if(HlCompRet != 0) throw new PmcException(i18n.str("AppEndError", HlCompRet));

			PrintMsg.InfoDebug("Running Pigmeo Compiler");
			int PigmeoCompilerRet = Apps.Pigmeo.PigmeoCompiler.Run();
			if(PigmeoCompilerRet != 0) throw new PmcException(i18n.str("AppEndError", PigmeoCompilerRet));

			PrintMsg.InfoDebug("Running the assembler: {0}", Apps.Assemblers.UsedAss.RealName);
			int AsmRet = Apps.Assemblers.UsedAss.Run();
			if(AsmRet != 0) throw new PmcException(i18n.str("AppEndError", AsmRet));

			throw new PmcException("Nothing else implemented");
			#endregion
		}
	}
}
