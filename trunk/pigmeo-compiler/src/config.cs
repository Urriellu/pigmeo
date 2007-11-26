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

namespace PigmeoCompiler {
	/// <summary>
	/// Contains all the configuration variables
	/// </summary>
	public class config {

		/// <summary>
		/// Configuration of the compiler itself
		/// </summary>
		public class Internal {
			public static readonly string PrjName = "pigmeo";
			public static readonly string AppName = "Pigmeo CIL compiler";
			public static readonly string AppVersion = "0.1-alpha";
			public static readonly string PrjDomain = "pigmeo.urriellu.net";

			public static bool verbose = false;
			public static bool debug = false;

			public static string FilePckGross = "outGross.exe";
		}



















		/// <summary>
		/// Compilation setting (target MCU, optimizations...)
		/// </summary>
		public class Compilation {

			/// <summary>
			/// List of available architectures
			/// </summary>
			//public enum Arch { PIC8bit }

			/// <summary>
			/// Path to the file which contains all the compilation-related settings
			/// </summary>
			public static string ConfigFile;

			private static string _TargetArch;
			/// <summary>
			/// Gets the target architecture
			/// </summary>
			public static string TargetArch {
				get {
					return _TargetArch;
				}
			}

			private static string _TargetBranch;
			/// <summary>
			/// Gets the target architecture branch (such as PIC16F84A)
			/// </summary>
			public static string TargetBranch {
				get {
					return _TargetBranch;
				}
			}

			/// <summary>
			/// List of resource files specified in the config file.
			/// </summary>
			/// <remarks>
			/// They are the files that will be packaged in a single binary
			/// </remarks>
			public static List<ResourceFile> ResourceFiles;

			/// <summary>
			/// List of available compiler optimizations
			/// </summary>
			/// <remarks>
			/// Here (in their definition) are set to their default values.
			/// Their values can be changed from the configuration file
			/// </remarks>
			public struct Optimizations {
				public static bool AllStaticFunctionsInline = false;
			}

			/// <summary>
			/// Reads the file which contains the compilation settings
			/// </summary>
			public static void ReadConfigFile() {

				/// <summary>
				/// Last supported version of the configuration file. Used for shown a warning if it is parsing an old version
				/// </summary>
				const float SupportedFileVersion = 1.0f;

				ShowInfo.InfoVerbose("Reading " + ConfigFile + " file...");

				XmlDocument doc = new XmlDocument();
				try {
					doc.Load(ConfigFile);
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
						else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "CFG0003", true);
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
			/// <param name="NodeGlobal">The global node which contains everything</param>
			private static void ParseCFv1_0(XmlNode NodeGlobal) {
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
			}

		}

	}

}
