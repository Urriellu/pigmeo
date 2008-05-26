using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PMC {
	public static class CmdLine {
		public static void ParseParams(string[] args) {
			Queue<string> q = new Queue<string>(args);
			while(q.Count > 0) {
				string token = q.Dequeue();

				if(token.Length < 1) Phases.PrintUsage();

				//--something
				if(token[0] == '-' && token[1] == '-') {
					if(token.Length < 3) Phases.PrintUsage();

					token = token.Substring(2);

					switch(token) {
						case "about":
							Phases.PrintAbout();
							break;
						case "debug":
							config.Verbosity = VerbosityLevel.Debug;
							break;
						case "help":
							Phases.PrintUsage();
							break;
						case "info":
							Phases.PrintInfo();
							break;
						default:
							UnknownParam(token);
							break;
					}
				} else if(token[0] == '-') { //-x
					token = token.Substring(1);

					switch(token) {
						default:
							UnknownParam(token);
							break;
					}
				} else {
					config.SourceFiles.Add(token);

					PrintMsg.InfoDebug("New source file: {0}", token);
				}
			}
		}

		/// <summary>
		/// Prints a message saying that an unknown parameter was found
		/// </summary>
		static void UnknownParam(string str) {
			PrintMsg.WriteLine(i18n.str("UnkParam", str));
			PrintMsg.WriteLine("");
			Phases.PrintUsage();
			Environment.Exit(1);
		}
	}
}
