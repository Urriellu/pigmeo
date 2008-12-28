using System;
using System.Collections.Generic;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PCG {
	public static class CmdLine {
		public static void ParseParams(string[] args) {
			Queue<string> q = new Queue<string>(args);
			while(q.Count > 0) {
				string token = q.Dequeue();

				if(token.Length < 1) PrintUsage();

				//--something
				if(token[0] == '-' && token[1] == '-') {
					if(token.Length < 3) PrintUsage();

					token = token.Substring(2);

					switch(token) {
						case "about":
							PrintAbout();
							break;
						case "debug":
							config.Debug = true;
							break;
						case "help":
							PrintUsage();
							break;
						case "not-translated":
							PrintNotTranslated();
							break;
						case "todo":
							goto case "ToDo";
						case "ToDo":
							FindPigmeoToDos fpt = new FindPigmeoToDos(System.Reflection.Assembly.GetEntryAssembly().Location);
							fpt.WriteToDoMethodsToConsole(PigmeoToDoPrintStyle.OneMethodAndReasonPerLine);
							Environment.Exit(0);
							break;
						default:
							UnknownParam(token);
							break;
					}
				} else if(token[0] == '-') { //-x
					token = token.Substring(1);

					switch(token) {
						case "h":
							PrintUsage();
							break;
						case "n":
							config.Interactive = false;
							break;
						default:
							UnknownParam(token);
							break;
					}
				} else {
					UnknownParam(token);
				}
			}
		}

		/// <summary>
		/// Prints a message saying that an unknown parameter was found
		/// </summary>
		private static void UnknownParam(string str) {
			PrintMsg.WriteLine(i18n.str("UnkParam", str));
			PrintMsg.WriteLine("");
			PrintUsage();
			Environment.Exit(1);
		}

		/// <summary>
		/// Prints information about PMC
		/// </summary>
		private static void PrintAbout() {
			PrintMsg.WriteLine(i18n.str("HelpTitle"));
			PrintMsg.WriteLine(i18n.str("AppDescription"));
			PrintMsg.WriteLine(i18n.str("Developers"));
			foreach(string developer in config.Developers) {
				PrintMsg.WriteLine("\t{0}", developer);
			}
			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("MoreInfo"));
			PrintMsg.WriteLine("\t{0}", SharedSettings.PrjWebsite);
			Environment.Exit(0);
		}

		/// <summary>
		/// Prints information about how to use this application
		/// </summary>
		private static void PrintUsage() {
			PrintMsg.WriteLine("Pigmeo Code Generator " + SharedSettings.AppVersion);
			PrintMsg.WriteLine(i18n.str("AppDescription"));
			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("CmdParams"));
			PrintMsg.WriteLine("");
			PrintMsg.WriteLine(i18n.str("PcgParams"));
			PrintMsg.WriteLine(i18n.str("param_about"));
			PrintMsg.WriteLine(i18n.str("param_debug"));
			PrintMsg.WriteLine(i18n.str("param_help"));
			PrintMsg.WriteLine(i18n.str("param_not_interactive"));
			PrintMsg.WriteLine(i18n.str("param_not_translated"));
			PrintMsg.WriteLine(i18n.str("param_todo"));

			Environment.Exit(0);
		}

		/// <summary>
		/// Prints the list of language strings not yet translated to the current language
		/// </summary>
		private static void PrintNotTranslated() {
			foreach(string str in i18n.LangStrNotTranslated) {
				PrintMsg.WriteLine("{0}: {1}", str, i18n.StrBulk(str));
			}
			Environment.Exit(0);
		}
	}
}
