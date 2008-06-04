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
						case "hl-compiler":
							string HlCompiler = q.Dequeue();
							foreach(App compiler in Apps.HL.AvailComp) {
								if(compiler.Command == HlCompiler) {
									PrintMsg.InfoDebug("Using {0} (chosen from the command-line)", compiler);
									if(!compiler.IsInstalled) throw new PmcException(i18n.str("NotInstalled", compiler.Command));
									Apps.HL.UsedComp = compiler;
								}
							}
							if(Apps.HL.UsedComp == null) throw new PmcException(i18n.str("HlCompilerNotValid", HlCompiler));
							break;
						case "hl-lang":
							string lang = q.Dequeue();
							switch(lang.ToLower()) {
								//USE LOWERCASE (because case insensitive)
								case "c#":
									config.CompilingLang = CLILanguages.CSharp;
									break;
								case "vb.net":
									config.CompilingLang = CLILanguages.VBNET;
									break;
								case "nemerle":
									config.CompilingLang = CLILanguages.Nemerle;
									break;
								default:
									throw new PmcException(i18n.str("HlLangNotValid", lang));
							}
							break;
						case "not-translated":
							Phases.PrintNotTranslated();
							break;
						case "todo":
							goto case "ToDo";
						case "ToDo":
							FindPigmeoToDos fpt = new FindPigmeoToDos(config.ExePath);
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
							Phases.PrintUsage();
							break;
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
