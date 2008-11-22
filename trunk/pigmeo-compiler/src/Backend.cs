using System;
using Mono.Cecil;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;
using System.Collections.Generic;
using System.IO;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Everything needed to parse a bundled assembly and compile it to assembly language
	/// </summary>
	public static class Backend {
		/// <summary>
		/// Parses a bundled assembly generated from Frontend() and converts it to assembly code
		/// </summary>
		/// <remarks>
		/// Before calling this method take care of the required variables placed in the config class (AssemblyToCompile...)
		/// </remarks>
		[Obsolete("Use the new compilation process by calling Backend.Run()")]
		public static List<string> RunBackend(AssemblyDefinition AssemblyToCompile) {
			ShowInfo.InfoDebug("Running the backend");
			List<string> AsmCode = new List<string>();
			DeviceTarget target = DeviceTarget.GetDeviceTarget(AssemblyToCompile);
			config.Compilation.TargetDeviceInfo = target.GetDeviceInfo();
			UIs.UpdateProgressBar(45);
			ShowInfo.InfoVerbose(i18n.str(113, AssemblyToCompile.Name.Name, target.branch.ToString(), target.arch.ToString()));
			switch(target.arch) {
				case Architecture.PIC:
					AsmCode = BackendPIC.Backend.RunBrackend(AssemblyToCompile);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0001", true, target.arch.ToString());
					break;
			}
			if(config.Internal.GenerateAsmFile) {
				SaveAsmToFile(AsmCode.ToArray(), config.Internal.FileAsm);
			}
			GlobalShares.CompilationProgress = 77;
			return AsmCode;
		}

		/// <summary>
		/// Parses a PIR Program generated in the Frontend and converts it to assembly code
		/// </summary>
		/// <remarks>
		/// Before calling this method take care of the required variables placed in the config class
		/// </remarks>
		/// <returns>
		/// A string array containing all the assembly language source code. One line of code per index.
		/// </returns>
		public static string[] Run(Program UserProgram) {
			ShowInfo.InfoDebug("Running the backend");
			ShowInfo.InfoVerbose(i18n.str("CompilingApp", UserProgram.Name, UserProgram.TargetArch, UserProgram.TargetFamily, UserProgram.TargetBranch));
			string[] AsmCode = null;
			switch(UserProgram.TargetArch) {
				case Architecture.PIC:
					AsmCode = BackendPIC.Backend.Run(UserProgram as PIR.PIC.Program);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0001", true, UserProgram.TargetArch.ToString());
					break;
			}
			if(config.Internal.GenerateAsmFile) SaveAsmToFile(AsmCode, config.Internal.FileAsm);
			return AsmCode;
		}

		/// <summary>
		/// Saves the assembly language source code to a file
		/// </summary>
		private static void SaveAsmToFile(string[] AsmCode, string file) {
			ShowInfo.InfoDebug("Saving file {0}", file);

			TextWriter tw = new StreamWriter(file, false, System.Text.Encoding.ASCII);
			tw.NewLine = config.Internal.EndOfLine;
			foreach(string str in AsmCode) {
				tw.WriteLine(str);
			}
			tw.Close();
		}
	}
}
