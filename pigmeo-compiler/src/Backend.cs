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
			DeviceTarget target = GetDeviceTarget(AssemblyToCompile);
			UIs.UpdateProgressBar(45);
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
		/// Returns a new DeviceTarget instance from a given AssemblyDefinition
		/// </summary>
		/// <param name="AssemblyToRead">Assembly which is being parsed to create the DeviceTarget object</param>
		/// <returns>DeviceTarget instance containing basic information about the given assembly</returns>
		private static DeviceTarget GetDeviceTarget(AssemblyDefinition AssemblyToRead) {
			ShowInfo.InfoDebug("Detecting target architecture for {0}", AssemblyToRead.Name.FullName);

			Architecture arch = Architecture.Unknown;
			Branch branch = Branch.Unknown;
			string path = "";
			foreach(CustomAttribute attr in AssemblyToRead.CustomAttributes) {
				attr.Resolve();
				if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceTarget") {
                    arch = (Architecture)System.Enum.Parse(typeof(Architecture), (string)attr.ConstructorParameters[0]);
                    branch = (Branch)System.Enum.Parse(typeof(Branch), (string)attr.ConstructorParameters[1]);
                    path = (string)attr.ConstructorParameters[2];
					ShowInfo.InfoDebug("Found the target information. Architecture: {0}, Branch: {1}", arch.ToString(), branch.ToString());
					ShowInfo.InfoDebug("Path to target device library: {0}", path);
				}
			}
			return new DeviceTarget(arch, branch, path);
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
