/*
This file is part of Pigmeo.

Pigmeo is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 3 of the License, or
(at your option) any later version.

Pigmeo is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>. 
*/

using System;
using System.Xml;
using System.Collections.Generic;
using Mono.Cecil;
using Pigmeo.Internal;

namespace Pigmeo.Compiler {
	/// <summary>
	/// How local variables must be implemented
	/// </summary>
	public enum ImplLocalVariablesOfStaticMethods { 
		/// <summary>
		/// Treat them as static variables
		/// </summary>
		AsStatic,
		/// <summary>
		/// Store them in the stack
		/// </summary>
		InStack
	}




	/// <summary>
	/// Contains all the configuration variables
	/// </summary>
	public class config {

		/// <summary>
		/// Configuration of the compiler itself
		/// </summary>
		public class Internal {
			/// <summary>
			/// Name of this project
			/// </summary>
			public static readonly string PrjName = "pigmeo";

			/// <summary>
			/// Name of this application
			/// </summary>
			public static readonly string AppName = "Pigmeo CIL compiler";

			/// <summary>
			/// Version of this application
			/// </summary>
			public static readonly string AppVersion = "0.1-alpha";

			/// <summary>
			/// Domain of this project
			/// </summary>
			public static readonly string PrjDomain = "pigmeo.org";

			/// <summary>
			/// Website of this project
			/// </summary>
			public static string PrjWebsite {
				get {
					return "http://" + PrjDomain + "/";
				}
			}

			public static bool verbose = false;
			public static bool debug = false;


			/// <summary>
			/// Path to the file which contains all the compilation-related settings
			/// </summary>
			public static string ConfigFile;

			#region bundle strings
			/// <summary>
			/// Internal name given to the generated bundle assembly
			/// </summary>
			public static readonly string AssemblyName = "PigmeoBundle";

			/// <summary>
			/// Internal name given to the main module of the generated bundle assembly
			/// </summary>
			public static readonly string MainModuleName = "BundleMainModule";

			/// <summary>
			/// Name of the namespace within the bundle which will contain everything
			/// </summary>
			public static readonly string GlobalNamespace = "GlobalNamespace";

			/// <summary>
			/// Name of the class where everything static (methos, variables...) will be stored
			/// </summary>
			public static readonly string GlobalStaticThings = "GlobalThings";
			public static readonly string GlobalStaticThingsFullName = GlobalNamespace+"."+GlobalStaticThings;
			#endregion

			/// <summary>
			/// Path to the .exe file, the application written by the user which is being compiled
			/// </summary>
			public static string UserApp = "";

			//public static string FilePckGross = "outGross.exe";

			/// <summary>
			/// Name of the file where the bundled assembly will be saved
			/// </summary>
			/// <remarks>
			/// The bundled assembly is the executable file which contains all the code chunks required for running the app, so it doesn't contain any dependencies/references
			/// </remarks>
			public static string FileBundle = "bundle.exe";

			/// <summary>
			/// Name of the file where the optimized bundled assembly will be saved
			/// </summary>
			public static string FileBundleOptimized = "bundleOpt.exe";

			/// <summary>
			/// Name of the file where the compiled application to assembly language will be saved
			/// </summary>
			public static string FileAsm = "userapp.asm";

			/// <summary>
			/// Assembly which is going to be compiled. It is usually created from Frontend()
			/// </summary>
			/// <remarks>
			/// We need to store the assembly here so we can compile it (in the backend) after running the frontend without saving it to disk
			/// </remarks>
			public static AssemblyDefinition AssemblyToCompile;

			/// <summary>
			/// Char or string which is going to be used as line ending in text files (such as assembly language apps)
			/// </summary>
			public static string EndOfLine = Environment.NewLine;
		}



















		/// <summary>
		/// Compilation settings (target MCU, optimizations...)
		/// </summary>
		public class Compilation {

			/*private static Arch _TargetArch;
			/// <summary>
			/// Gets the target architecture
			/// </summary>
			public static Arch TargetArch {
				get {
					return _TargetArch;
				}
			}

			private static Branch _TargetBranch;
			/// <summary>
			/// Gets the target architecture branch (such as PIC16F84A)
			/// </summary>
			public static Branch TargetBranch {
				get {
					return _TargetBranch;
				}
			}*/

			public static InfoDevice TargetDeviceInfo;

			/// <summary>
			/// List of resource files specified in the config file.
			/// </summary>
			/// <remarks>
			/// They are the files that will be packaged in a single binary
			/// </remarks>
			//public static List<ResourceFile> ResourceFiles;
			//public static List<string> ResourceFiles = new List<string>();
			public static List<string> UserAppResourceFiles = new List<string>();

			/// <summary>
			/// List of available compiler optimizations
			/// </summary>
			/// <remarks>
			/// Here (in their definition) are set to their default values.
			/// Their values can be changed from the configuration file
			/// </remarks>
			/*public struct Optimizations {
				public static bool AllStaticFunctionsInline = false;
			}*/

			public static ImplLocalVariablesOfStaticMethods LocalVariablesOfStaticMethods = ImplLocalVariablesOfStaticMethods.AsStatic;

			/// <summary>
			/// Reads the file which contains the compilation settings
			/// </summary>
			public static void ReadCompilationConfigFile() {

				/// <summary>
				/// Last supported version of the configuration file. Used for shown a warning if it is parsing an old version
				/// </summary>
				const float SupportedFileVersion = 2.0f;

				ShowInfo.InfoVerbose("Reading " + Internal.ConfigFile + " file...");

				XmlDocument doc = new XmlDocument();
				try {
					doc.Load(Internal.ConfigFile);
					XmlNode NodeGlobal = doc.SelectSingleNode("PigmeoCompilerConfig");
					if(NodeGlobal != null) {
						string FileVersionStr = NodeGlobal.Attributes["fileversion"].Value;
						float FileVersion = 0;
						try {
							//mono's mcs doesn't support tryparse. What about gmcs? Should try it
							FileVersion = float.Parse(FileVersionStr);
						} catch {
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0001", true);
						}
						if(FileVersion < SupportedFileVersion) {
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Warning, "W0001", false);
						}
						if(FileVersion == 1.0f) ParseCFv1_0(NodeGlobal);
						else if(FileVersion==2.0f) ParseCFv2_0(NodeGlobal);
						else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0003", true);
						/*switch(FileVersion) {
							case 1.0f:
								ParseCFv1_0(NodeGlobal);
								break;
							case 2.0f:
								ParseCFv2_0(NodeGlobal);
								break;
							default:
								ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0003", true);
						}*/
					} else {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0002", true);
					}
				} catch(XmlException xe) {
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0005", true, "(" + xe.LineNumber + "," + xe.LinePosition + ") \"" + xe.Message + "\"");
				}
			}

			/// <summary>
			/// Parses the config file version 1.0
			/// </summary>
			/// <remarks>
			/// This version is no longer used because the list of resources, target architecture and target branch are read from the .exe, and file version 2.0 supports more optimizations and settings
			/// </remarks>
			/// <param name="NodeGlobal">The global node which contains everything</param>
			private static void ParseCFv1_0(XmlNode NodeGlobal) {
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0003", true);
			}
			/*private static void ParseCFv1_0(XmlNode NodeGlobal) {
				XmlNode NodeTarget = NodeGlobal.SelectSingleNode("Target");
				if(NodeTarget != null) {
					//parsin the target
					XmlNode NodeTargetArch = NodeTarget.SelectSingleNode("Arch");
					if(NodeTargetArch != null) _TargetArch = NodeTargetArch.InnerText;
					else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0004", true, "Target->Arch");

					XmlNode NodeTargetBranch = NodeTarget.SelectSingleNode("Branch");
					if(NodeTargetBranch != null) _TargetBranch = NodeTargetBranch.InnerText;
					else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0004", true, "Target->Branch");

				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0004", true, "Target");

				XmlNode NodeResourceFiles = NodeGlobal.SelectSingleNode("ResourceFiles");
				if(NodeResourceFiles != null) {
					//parsing the resource files
					ResourceFiles = new List<ResourceFile>(NodeResourceFiles.ChildNodes.Count);
					foreach(XmlNode NodeResFile in NodeResourceFiles.ChildNodes) {
						if(NodeResFile.Name == "Resource") {
							//parsing ONE resource
							XmlAttribute ResType = NodeResFile.Attributes["type"];
							if(ResType == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0006", true, "Attribute \"type\" not found in resource file");
						
							XmlAttribute ResFile = NodeResFile.Attributes["file"];
							if(ResFile == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0006", true, "Attribute \"file\" not found in resource file");
							
							XmlAttribute ResSource = NodeResFile.Attributes["source"];
							if(ResSource == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0006", true, "Attribute \"source\" not found in resource file");

							ResourceFiles.Add(new ResourceFile(ResType.Value, ResFile.Value, ResSource.Value));
						} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0006", true, "Resource tag: " + NodeResFile.Name);
					}
					ShowInfo.InfoVerbose("There are " + ResourceFiles.Count + " resource files");
				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0004", true, "ResourceFiles");

				XmlNode NodeOptimizations = NodeGlobal.SelectSingleNode("Optimizations");
				if(NodeOptimizations!=null){
					//reading the optimizations
					foreach(XmlNode NodeSomeOpt in NodeOptimizations.ChildNodes) {
						//parsing each optimization
						if(NodeSomeOpt.NodeType == XmlNodeType.Element) { //ignoring comments
							switch(NodeSomeOpt.Name) {
								case "AllStaticFunctionsInline":
									bool value;
									if(bool.TryParse(NodeSomeOpt.InnerText, out value)) {
										ShowInfo.InfoVerbose("Setting " + NodeSomeOpt.Name + " optimization to " + NodeSomeOpt.InnerText);
										Optimizations.AllStaticFunctionsInline = value;
									}
									break;
								default:
									ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Warning, "W0002", false, NodeSomeOpt.Name);
									break;
							}
						}
					}
				} //it is optional, so we can ignore if it doesn't exist
			}*/

			/// <summary>
			/// Parses the config file version 2.0
			/// </summary>
			/// <param name="NodeGlobal">The global node which contains everything</param>
			private static void ParseCFv2_0(XmlNode NodeGlobal) {
			}

		}

	}

}
