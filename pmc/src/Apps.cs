using Pigmeo.Internal;

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
				} else throw new PmcException(i18n.str("LangNotSup"));
				if(ret == null) PrintMsg.InfoDebug("No suitable high level language compiler found");
				else PrintMsg.InfoDebug("Found {0} installed at {1}", UsedComp.RealName, UsedComp.CmdPath);
				return ret;
			}

			public static App gmcs = new App("Mono C# Compiler", "mcs", "gmcs");
			public static App CustomHLCompiler;

			/// <summary>
			/// The application being used as high level language compiler
			/// </summary>
			public static App UsedComp;
		}

		/// <summary>
		/// Pigmeo-related applications
		/// </summary>
		public static class Pigmeo {
			public static App PMC = new App("PMC", "pmc", "pmc");
			public static App PigmeoCompiler = new App("Pigmeo Compiler", "pigmeo-compiler", "pigmeo");
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
