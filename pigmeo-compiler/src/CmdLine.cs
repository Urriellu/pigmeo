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
						case "quiet":
							config.Internal.Verbosity = VerbosityLevel.Quiet;
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
				}

				if(token[0] == '-' || token[0] == '/') {
					token = token.Substring(1);

					switch(token) {
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
					config.Internal.UserApp = config.Internal.WorkingDirectory + "/" + token;
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
			Console.WriteLine(i18n.str(102));

			Console.WriteLine(i18n.str(103, config.Internal.AppName));
			Console.WriteLine(i18n.str(104));
			Console.WriteLine(i18n.str(105));
			Console.WriteLine(i18n.str(106));
			Console.WriteLine(i18n.str(107));
			Console.WriteLine(i18n.str(108));
			Console.WriteLine(i18n.str(109, config.Internal.AppName));
			Console.WriteLine();
			Console.WriteLine(i18n.str(110));

			Environment.Exit(1);
		}

		/// <summary>
		/// Prints the version of the application
		/// </summary>
		static void Version () {
			Console.WriteLine ("{0} {1}", config.Internal.AppName, config.Internal.AppVersion);
			Environment.Exit (1);
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
			Environment.Exit (1);
		}
	}

}
 
