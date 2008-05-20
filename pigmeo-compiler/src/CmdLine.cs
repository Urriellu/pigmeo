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
using System.Collections;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {

	/// <summary>
	/// Parses the parameters sent through the command line
	/// </summary>
	public class CmdLine {


		public static void ParseParams(string[] args) {
			Queue q = new Queue(args);
			while(q.Count > 0) {
				string token = (string)q.Dequeue();

				if(token.Length < 1) Usage();

				//--something
				if(token[0] == '-' && token[1] == '-') {
					if(token.Length < 3) Usage();

					token = token.Substring(2);

					switch(token) {
						case "about":
							About();
							break;
						case "debug":
							config.Internal.Verbosity = VerbosityLevel.Debug;
							break;
						case "help":
							Usage();
							break;
						case "info":
							config.Internal.OnlyPrintInfo = true;
							break;
						case "not-translated":
							foreach(string str in i18n.LangStrNotTranslated) {
								Console.WriteLine("{0}: {1}", str, i18n.StrBulk(str));
							}
							Environment.Exit(0);
							break;
						case "path-asm":
							string PathAsm = (string)q.Dequeue();
							config.Internal.FileAsm = PathAsm;
							break;
						case "path-bundle":
							string PathBundle = (string)q.Dequeue();
							config.Internal.FileBundle = PathBundle;
							break;
						case "path-error":
							string PathError = (string)q.Dequeue();
							config.Internal.FileError = PathError;
							break;
						case "path-summary":
							string PathSummary = (string)q.Dequeue();
							config.Internal.FileSummary = PathSummary;
							break;
						case "path-symbol-table":
							string PathSymTab = (string)q.Dequeue();
							config.Internal.FileSymbolTable = PathSymTab;
							break;
						case "quiet":
							config.Internal.Verbosity = VerbosityLevel.Quiet;
							break;
						case "todo":
							goto case "ToDo";
						case "ToDo":
							FindPigmeoToDos fpt = new FindPigmeoToDos(config.Internal.ExePath);
							fpt.WriteToDoMethodsToConsole(PigmeoToDoPrintStyle.OneMethodAndReasonPerLine);
							Environment.Exit(0);
							break;
						case "ui":
							goto case "UI";
						case "UI":
							string ChoosenUI = (string)q.Dequeue();
							try {
								config.Internal.UI = (UserInterface)Enum.Parse(typeof(UserInterface), ChoosenUI, true);
							} catch {
								UnknownParam("--UI " + ChoosenUI);
							}
							break;
						case "verbose":
							config.Internal.Verbosity = VerbosityLevel.Verbose;
							break;
						case "version":
							Version();
							break;
						default:
							UnknownParam(token);
							break;
					}
				} else if(token[0] == '-') { //-x
					token = token.Substring(1);

					switch(token) {
						case "i":
							config.Internal.OnlyPrintInfo = true;
							break;
						case "v":
							config.Internal.Verbosity = VerbosityLevel.Verbose;
							break;
						case "h":
							Usage();
							break;
						default:
							UnknownParam(token);
							break;
					}
				} else {
					if(System.IO.Path.IsPathRooted(token)) {
						config.Internal.UserApp = token;
					} else {
						config.Internal.UserApp = config.Internal.WorkingDirectory + "/" + token;
					}
					config.Internal.FileBundle = config.Internal.UserAppPath + "/" + config.Internal.UserAppFilename + "-bundle.exe";
					config.Internal.FileAsm = config.Internal.UserAppPath + "/" + config.Internal.UserAppFilename + ".asm";

					ShowInfo.InfoDebug("User application: {0}", config.Internal.UserApp);
					ShowInfo.InfoDebug("The bundle will be saved to {0}", config.Internal.FileBundle);
					ShowInfo.InfoDebug("The generated assembly language code will be saved to {0}", config.Internal.FileAsm);
				}
			}
		}

		/// <summary>
		/// Prints a message saying that an unknown parameter was found
		/// </summary>
		static void UnknownParam(string str){
			Console.WriteLine (i18n.str(101, str));
			Console.WriteLine();
			Usage();
			Environment.Exit(1);
		}

		/// <summary>
		/// Explains how the executable must be called
		/// </summary>
		public static void Usage() {
			Console.WriteLine(config.Internal.AppName + " " + config.Internal.AppVersion);
			Console.WriteLine(i18n.str("PigOptsUserApp"));

			Console.WriteLine(i18n.str("param_about", config.Internal.AppName));
			Console.WriteLine(i18n.str("param_debug"));
			Console.WriteLine(i18n.str("param_help"));
			Console.WriteLine(i18n.str("param_info"));
			Console.WriteLine(i18n.str("param__not_translated"));
			Console.WriteLine(i18n.str("param_path_asm"));
			Console.WriteLine(i18n.str("param_path_bundle"));
			Console.WriteLine(i18n.str("param_path_error"));
			Console.WriteLine(i18n.str("param_path_summary"));
			Console.WriteLine(i18n.str("param_path_symbol_table"));
			Console.WriteLine(i18n.str("param_quiet"));
			Console.WriteLine(i18n.str("param_todo"));
			Console.WriteLine(i18n.str("param_ui"));
			Console.WriteLine(i18n.str("param_verbose"));
			Console.WriteLine(i18n.str("param_version", config.Internal.AppName));
			Console.WriteLine();
			Console.WriteLine(i18n.str("CmdExample"));

			Environment.Exit(0);
		}

		/// <summary>
		/// Prints the version of the application
		/// </summary>
		static void Version () {
			Console.WriteLine ("{0} {1}", config.Internal.AppName, config.Internal.AppVersion);
			Environment.Exit (0);
		}

		/// <summary>
		/// Prints the some information about the application
		/// </summary>
		static void About () {
			Console.WriteLine(i18n.str(111, config.Internal.AppName, config.Internal.PrjName)); //title
			Console.WriteLine(i18n.str(7)); //description
			Console.WriteLine(i18n.str(8)); //developers
			foreach(string developer in config.Internal.Developers.Split('\n')) {
				Console.WriteLine("\t{0}", developer);
			}
			Console.WriteLine(i18n.str(9)); //more info
			Console.WriteLine ("\t{0}", config.Internal.PrjWebsite);
			Environment.Exit (0);
		}
	}

}
 
