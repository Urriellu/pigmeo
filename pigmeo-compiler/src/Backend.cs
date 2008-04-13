using Mono.Cecil;
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
		public static List<string> RunBackend(AssemblyDefinition AssemblyToCompile) {
			ShowInfo.InfoDebug("Running the backend");
			List<string> AsmCode = new List<string>();
			DeviceTarget target = DeviceTarget.GetDeviceTarget(AssemblyToCompile);
			config.Compilation.TargetDeviceInfo = target.GetDeviceInfo();
			UIs.UpdateProgressBar(45);
			System.Console.WriteLine(i18n.str(113, AssemblyToCompile.Name.Name, target.branch.ToString(), target.arch.ToString()));
			ShowInfo.InfoVerbose(i18n.str(113, AssemblyToCompile.Name.Name, target.branch.ToString(), target.arch.ToString()));
			switch(target.arch) {
				case Architecture.PIC14:
					AsmCode = BackendPIC14.Backend.RunBrackend(AssemblyToCompile);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0001", true, target.arch.ToString());
					break;
			}
			if(config.Internal.GenerateAsmFile) {
				SaveAsmToFile(AsmCode, config.Internal.FileAsm);
			}
			GlobalShares.CompilationProgress = 77;
			return AsmCode;
		}

		/// <summary>
		/// Saves the assembly language source code to a file
		/// </summary>
		/// <param name="AsmCode"></param>
		private static void SaveAsmToFile(List<string> AsmCode, string file) {
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
