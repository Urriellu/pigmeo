using System;
using Pigmeo.Compiler;
using System.Collections.Generic;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// Prints info to the console when needed
	/// </summary>
	public static class ShowInfo {
		public static List<OutputBlock> OutputMessages = new List<OutputBlock>(5000);

		/// <summary>
		/// Prints a message if --verbose or --debug was specified
		/// </summary>
		/// <param name="message">The text being printed</param>
		public static void InfoVerbose(string message) {
			if(config.Internal.Verbosity == VerbosityLevel.Verbose || config.Internal.Verbosity == VerbosityLevel.Debug) {
				UIs.PrintMessage(message);
			}
			UnknownError.ShownMsgs.Add(message);
		}

		/// <summary>
		/// Prints a message if --verbose or --debug was specified
		/// </summary>
		/// <param name="message">The text being printed</param>
		/// <param name="args">List of strings to format, merge all together</param>
		public static void InfoVerbose(string message, params object[] args) {
			InfoVerbose(string.Format(message, args));
		}

		/// <summary>
		/// Prinst a message if --debug was specified
		/// </summary>
		/// <remarks>
		/// The message should be written in english. Avoid translations
		/// </remarks>
		/// <param name="message">The text being printed</param>
		public static void InfoDebug(string message) {
			message = "DEBUG: " + message;
			if(config.Internal.Verbosity == VerbosityLevel.Debug) UIs.PrintMessage(message);
			UnknownError.ShownMsgs.Add(message);
		}

		/// <summary>
		/// Prints a message if --debug was specified
		/// </summary>
		/// <remarks>
		/// The message should be written in english. Avoid translations
		/// </remarks>
		/// <param name="message">The text being printed</param>
		/// <param name="args">List of strings to format, merge all together</param>
		public static void InfoDebug(string message, params object[] args) {
			InfoDebug(string.Format(message, args));
		}

		/// <summary>
		/// Prints the decompilation of an Assembly, Program or any member as debug information
		/// </summary>
		/// <param name="Title">Title attached to the debug information</param>
		/// <param name="obj">Object to decompile</param>
		public static void InfoDebugDecompile(string Title, object obj) {
			string Delimiter = "===========================================================================";
			List<string> Output = new List<string>();
			Output.Add("===== Decompilation of " + Title + " =====");
			string[] DecompStr = obj.ToString().Replace("\t", "    ").TrimEnd(' ', '\n', '\t').Split('\n');
			foreach(string str in DecompStr) Output.Add(str);
			Output.Add(Delimiter);
			foreach(string line in Output) InfoDebug(line);

			AddOutMsg("Decompilation of " + Title, DecompStr);
		}

		public static void NewOutMsgBlock(string Name) {
			NewOutMsgBlock();
			SetCurrOutMsgName(Name);
		}

		public static void NewOutMsgBlock() {
			if(config.Internal.DebugExampleVS) UIs.DebugVS.UpdateLstOutputs();
			if(OutputMessages.Count==0 || OutputMessages[OutputMessages.Count - 1].Messages.Count >= 0) {
				OutputMessages.Add(new OutputBlock());
			}
		}

		public static void EndOutMsgBlock() {
			NewOutMsgBlock();
		}

		public static void AddOutMsg(string Title, string Message) {
			OutputMessages[OutputMessages.Count - 1].Messages.Add(Title, Message);
		}

		public static void AddOutMsg(string Title, string[] Message) {
			string msg = "";
			foreach(string s in Message) msg += s + Environment.NewLine;
			msg = msg.TrimEnd('\n', '\r');
			AddOutMsg(Title, msg);
		}

		public static void SetCurrOutMsgName(string Name) {
			OutputMessages[OutputMessages.Count - 1].Name = Name;
		}

		static ShowInfo() {
			NewOutMsgBlock();	
		}
	}
}
