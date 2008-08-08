using Pigmeo.Internal;
using Pigmeo.Extensions;
using System.Collections.Generic;

namespace Pigmeo.PMC {
	/// <summary>
	/// List of available applications which can be called from within PMC
	/// </summary>
	public static class Apps {
		/// <summary>
		/// High level language compilers
		/// </summary>
		public static class HL {
			/// <summary>
			/// Looks for a high level language compiler installed in the system
			/// </summary>
			/// <returns>
			/// The best installed high level language compiler. Null if none found
			/// </returns>
			public static App FindAny(CLILanguages language) {
				PrintMsg.InfoDebug("Looking for a suitable compiler. Language: {0}", language.ToString());
				App ret = null;
				if(language == CLILanguages.CSharp) {
					if(gmcs.IsInstalled) ret = gmcs;
				} else if(language == CLILanguages.Nemerle) {
					if(Nemerle.IsInstalled) ret = Nemerle;
				} else if(language == CLILanguages.Boo) {
					if(Booc.IsInstalled) ret = Booc;
				} else throw new PmcException(i18n.str("LangNotSup"));
				if(ret == null) PrintMsg.InfoDebug("No suitable high level language compiler found");
				else PrintMsg.InfoDebug("Found {0} installed at {1}", ret.RealName, ret.CmdFullPath);
				return ret;
			}

			/// <summary>
			/// List of available high level language compilers
			/// </summary>
			public static List<App> AvailComp;

			/// <summary>
			/// Gets a comma-separated list of available high level compiler commands
			/// </summary>
			public static string List {
				get {
					List<string> compilers = new List<string>();
					foreach(App compiler in AvailComp) {
						compilers.Add(compiler.Command);
					}
					return compilers.ToArray().CommaSeparatedList();
				}
			}

			public static booc Booc = new booc("Boo Compiler", "boo", "booc");
			public static MCS gmcs = new MCS("Mono C# Compiler", "mcs", "gmcs");
			public static NCC Nemerle = new NCC("Nemerle Compiler", "nemerle", "ncc");
			public static App CustomHLCompiler;

			/// <summary>
			/// The application being used as high level language compiler
			/// </summary>
			public static App UsedComp;

			static HL() {
				#region generate the list of available compilers
				AvailComp = new List<App>();
				AvailComp.Add(Booc);
				AvailComp.Add(gmcs);
				AvailComp.Add(Nemerle);
				#endregion
			}
		}

		/// <summary>
		/// Pigmeo-related applications
		/// </summary>
		public static class Pigmeo {
			public static App PMC = new App("PMC", "pmc", "pmc");
			public static PigmeoCompiler PigmeoCompiler = new PigmeoCompiler("Pigmeo Compiler", "pigmeo-compiler", "pigmeo");
		}

		/// <summary>
		/// Assembler applications
		/// </summary>
		public static class Assemblers {
			/// <summary>
			/// Looks for an assembler installed in the system
			/// </summary>
			/// <returns>
			/// The best installed assembler software. Null if none found
			/// </returns>
			public static App FindAnyAss() {
				App ret = null;

				if(gpasm.IsInstalled) ret = gpasm;

				if(ret == null) PrintMsg.InfoDebug("No suitable assembler software found");
				else PrintMsg.InfoDebug("Found {0} installed at {1}", ret.RealName, ret.CmdFullPath);

				return ret;
			}

			public static App gpasm = new App("GNU PIC Assembler", "gpasm", "gpasm");
			public static App CustomAssembler;

			/// <summary>
			/// The application being used as assembler
			/// </summary>
			public static App UsedAss;
		}
	}
}
