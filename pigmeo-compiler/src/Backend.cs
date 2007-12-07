using Mono.Cecil;
using Pigmeo;
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
			List<string> AsmCode = new List<string>();
			DeviceTarget target = GetDeviceTarget(AssemblyToCompile);
			ShowInfo.InfoVerbose("Compiling " + AssemblyToCompile.Name.Name + " for " + target.branch.ToString() + " (" + target.arch.ToString() + ")");
			switch(target.arch) {
				case Architecture.PIC16:
					AsmCode = BackendPIC8bit.Backend.RunBrackend(AssemblyToCompile);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0001", true, target.arch.ToString());
					break;
			}
			SaveAsmToFile(AsmCode, config.Internal.FileAsm);
			return AsmCode;
		}

		/// <summary>
		/// Returns a new DeviceTarget instance from a given AssemblyDefinition
		/// </summary>
		/// <param name="AssemblyToRead">Assembly which is being parsed to create the DeviceTarget object</param>
		/// <returns>DeviceTarget instance containing basic information about the given assembly</returns>
		private static DeviceTarget GetDeviceTarget(AssemblyDefinition AssemblyToRead) {
			Architecture arch = Architecture.Unknown;
			Branch branch = Branch.Unknown;
			string path = "";
			foreach(CustomAttribute attr in AssemblyToRead.CustomAttributes) {
				attr.Resolve();
				if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceTarget") {
					/*
                    old version using enums (not supported by cecil)
                    arch = (Architecture)attr.ConstructorParameters[0];
					branch = (Branch)attr.ConstructorParameters[1];
					path = (string)attr.ConstructorParameters[2];
                    */
                    arch = (Architecture)System.Enum.Parse(typeof(Architecture), (string)attr.ConstructorParameters[0]);
                    branch = (Branch)System.Enum.Parse(typeof(Branch), (string)attr.ConstructorParameters[1]);
                    path = (string)attr.ConstructorParameters[2];
				}
			}
			return new DeviceTarget(arch, branch, path);
		}

		/// <summary>
		/// Saves the assembly language source code to a file
		/// </summary>
		/// <param name="AsmCode"></param>
		private static void SaveAsmToFile(List<string> AsmCode, string file) {
			TextWriter tw = new StreamWriter(file);
			tw.NewLine = config.Internal.EndOfLine;
			foreach(string str in AsmCode) {
				tw.WriteLine(str);
			}
			tw.Close();
		}





		/// <summary>
		/// Get the path to the device library (the one that contains all the info about a device) from a bundled assembly ready to be compiled (which contains the required path as a Custom Attribute)
		/// </summary>
		/// <param name="AssemblyToRead"></param>
		/// <returns>The path to the device library</returns>
		/*private static string GetDevLibPathFromAss(AssemblyDefinition AssemblyToRead) {
			string path = "";
			foreach(CustomAttribute attr in AssemblyToRead.CustomAttributes) {
				if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibraryPath") {
					path = attr.ConstructorParameters[0] as string;
				}
			}
			if(path=="") ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0004", true);
			ShowInfo.InfoDebug("The assembly contains the following path to a device library: "+path);
			return path;
		}*/
	}
}
