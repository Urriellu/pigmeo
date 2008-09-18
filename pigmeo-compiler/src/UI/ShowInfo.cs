using System;
using Pigmeo.Compiler;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// Prints info to the console when needed
	/// </summary>
	public class ShowInfo {
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
			string Delimiter = "==================================================================";
			InfoDebug(Delimiter);
			InfoDebug("        >>>>>" + Title + "<<<<<");
			InfoDebug("");
			foreach(string str in obj.ToString().Replace("\t", "    ").Split('\n')) InfoDebug(str);
			InfoDebug(Delimiter);
		}
	}
}
