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
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

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
	/// Available user interfaces
	/// </summary>
	public enum UserInterface { Console, WinForms/*, GTKSharp*/ }




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
			public const string PrjName = "pigmeo";

			/// <summary>
			/// Name of this application
			/// </summary>
			public const string AppName = "Pigmeo Compiler";

			/// <summary>
			/// Version of this application
			/// </summary>
			public const string AppVersion = "0.0.9999-svn";

			/// <summary>
			/// Domain of this project
			/// </summary>
			public const string PrjDomain = "pigmeo.org";

			/// <summary>
			/// Website of this project
			/// </summary>
			public static string PrjWebsite {
				get {
					return "http://" + PrjDomain + "/";
				}
			}

			/// <summary>
			/// The list of developers
			/// </summary>
			/// <remarks>
			/// When using this variable, make sure you replace "\n" by the correct line ending, which by default is configured at config.Internal.EndOfLine but it really depends on where it is going to be shown
			/// </remarks>
			public const string Developers =
				"Adrián Bulnes [Urriellu] <urriellu@pigmeo.org>\n";

			public const string CompilerLicense = "GPL 3.0";
			public const string FrameworkLicense = "LGPL 3.0";

			/// <summary>
			/// If verbose==true some more information will be shown to the user
			/// </summary>
			public static bool verbose = false;

			/// <summary>
			/// If debug==true LOTS of stuff will be shown to the user
			/// </summary>
			public static bool debug = false;

			/// <summary>
			/// Path to the directory where all the setting related to pigmeo are stored
			/// </summary>
			public static string PigmeoConfigPath;

			/// <summary>
			/// Path to the file which contains all the compiler-related settings
			/// </summary>
			public static string CompilerConfigFile {
				get {
					return PigmeoConfigPath + "pigmeo-compiler.conf";
				}
			}

			/// <summary>
			/// Full path to the directory that contains the Pigmeo Compiler executable file. The last character is NOT a slash ('/')
			/// </summary>
			public static string ExeLocation {
				get {
					if(_ExeLocation==null) _ExeLocation=System.IO.Path.GetDirectoryName(ExePath);
					return _ExeLocation;
				}
			}
			private static string _ExeLocation;

			/// <summary>
			/// Full path to the Pigmeo Compiler executable file
			/// </summary>
			public static string ExePath {
				get {
					if(_ExePath==null) _ExePath=System.Reflection.Assembly.GetEntryAssembly().Location;
					return _ExePath;
				}
			}
			private static string _ExePath;

			/// <summary>
			/// Full path to the directory that contains all the required images for the graphical interfaces. The last character is NOT a slash ('/')
			/// </summary>
			public static string ImagesDirectory {
				get {
					return ExeLocation + "/images";
				}
			}


			public static string WorkingDirectory {
				get {
					if(_WorkingDirectory == null) _WorkingDirectory = Environment.CurrentDirectory;
					return _WorkingDirectory;
				}
				set {
					_WorkingDirectory = value;
				}
			}
			private static string _WorkingDirectory;

			/// <summary>
			/// Path to the file which contains all the compilation-related settings
			/// </summary>
			public static string CompilationConfigFile;

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
			/// Char or string which is going to be used as line ending in text files (such as assembly language apps)
			/// </summary>
			public static string EndOfLine = Environment.NewLine;

			/// <summary>
			/// Language used for showing messages
			/// </summary>
			public static string lang {
				get {
					return _lang;
				}
				set {
					_lang = value;
					i18n.lang = value;
					ErrorsAndWarnings.LoadErrAndWarnStrings();
					UIs.UpdateLanguageStrings();
				}
			}
			private static string _lang;

			/// <summary>
			/// User Interface configured for this instance of the compiler
			/// </summary>
			public static UserInterface UI;

			/// <summary>
			/// Loads the configuration of the compiler itself, not the compilation-related settings
			/// </summary>
			public static void ReadCompilerConfigFile() {
				//UNINPLEMENTED
				
				ShowInfo.InfoDebug("Loaded language: " + lang);
			}

			/// <summary>
			/// Static constructor. It loads the default parameters
			/// </summary>
			static Internal() {
				//choose the config path
				if(PigmeoConfigPath == null) {
					if(Environment.OSVersion.Platform == PlatformID.Unix)
						PigmeoConfigPath = Environment.GetEnvironmentVariable("HOME") + "/.pigmeo/";
					else
						PigmeoConfigPath = "C:" + Environment.GetEnvironmentVariable("HOMEPATH") + "\\pigmeo\\";
				}
				ShowInfo.InfoVerbose("Reading compiler config file: " + CompilerConfigFile);


				//choose the default language (it may be overriden later by the config file)
				lang = System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName;
				ShowInfo.InfoDebug("System language: " + lang);

				//choose the default user interface
				/*if(Environment.OSVersion.Platform == PlatformID.Unix) config.Internal.UI = UserInterface.GTKSharp;
				else*/ config.Internal.UI = UserInterface.WinForms;
			}
		}



















		/// <summary>
		/// Compilation settings (target MCU, optimizations...)
		/// </summary>
		public class Compilation {
			public static InfoDevice TargetDeviceInfo;

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
				const float SupportedFileVersion = 2.0f; // Last supported version of the configuration file. Used for shown a warning if it is parsing an old version

				ShowInfo.InfoVerbose("Reading " + Internal.CompilationConfigFile + " file...");

				XmlDocument doc = new XmlDocument();
				try {
					doc.Load(Internal.CompilationConfigFile);
					XmlNode NodeGlobal = doc.SelectSingleNode("PigmeoCompilerConfig");
					if(NodeGlobal != null) {
						string FileVersionStr = NodeGlobal.Attributes["fileversion"].Value;
						float FileVersion = 0;
						/*try {
							//mono's mcs doesn't support tryparse. What about gmcs? Should try it
							FileVersion = float.Parse(FileVersionStr);
						} catch {
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0001", true);
						}*/
						if(!float.TryParse(FileVersionStr, out FileVersion)) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0001", true);
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
