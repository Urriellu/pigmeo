using System;

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
			if(config.Internal.Verbosity == VerbosityLevel.Verbose) {
				UIs.PrintMessage("INFO: {0}", message);
			}
		}

		/// <summary>
		/// Prints a message if --verbose or --debug was specified
		/// </summary>
		/// <param name="message">The text being printed</param>
		/// <param name="args">List of strings to format, merge all together</param>
		public static void InfoVerbose(string message, params string[] args) {
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
			if(config.Internal.Verbosity == VerbosityLevel.Debug) {
				UIs.PrintMessage("DEBUG: {0}", message);
			}
		}

		/// <summary>
		/// Prinst a message if --debug was specified
		/// </summary>
		/// <remarks>
		/// The message should be written in english. Avoid translations
		/// </remarks>
		/// <param name="message">The text being printed</param>
		/// <param name="args">List of strings to format, merge all together</param>
		public static void InfoDebug(string message, params string[] args) {
			InfoDebug(string.Format(message, args));
		}
	}
}
