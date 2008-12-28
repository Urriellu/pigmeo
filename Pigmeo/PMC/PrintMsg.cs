using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PMC {
	public static class PrintMsg {
		/// <summary>
		/// Prints any kind of message to the standard output
		/// </summary>
		/// <remarks>
		/// When PMC is going to print messages from more than one source application you should NOT use this method, use WriteLine(App, string) instead, so the source app name is displayed
		/// </remarks>
		/// <param name="message">Message being printed to the standard output</param>
		public static void WriteLine(string message, params object[] p) {
			Console.WriteLine(message, p);
		}

		/// <summary>
		/// Prints any kind of message to the standard output
		/// </summary>
		/// <param name="source">Message source (gmcs, Pigmeo Compiler...)</param>
		/// <param name="message">Message being printed to the standard output</param>
		public static void WriteLine(App source, string message) {
			Console.WriteLine("[{0}] {1}", source.RealName, message);
		}

		/// <summary>
		/// Prints any kind of message to the standard output
		/// </summary>
		/// <param name="source">Message source (gmcs, Pigmeo Compiler...)</param>
		/// <param name="message">Message being printed to the standard output</param>
		public static void WriteLine(App source, string message, params object[] p) {
			WriteLine(source, string.Format(message, p));
		}

		/// <summary>
		/// Prints any kind of message to the error output
		/// </summary>
		/// <param name="source">Message source (gmcs, Pigmeo Compiler...)</param>
		/// <param name="message">Message being printed to the error output</param>
		public static void WriteErrorLine(App source, string message) {
			Console.Error.WriteLine("[{0}] {1}", source.RealName, message);
		}

		/// <summary>
		/// Prints a message with information about PMC when VerbosityLevel is "verbose" or "debug"
		/// </summary>
		public static void InfoVerbose(string message, params object[] p) {
			if(config.Verbosity == VerbosityLevel.Verbose || config.Verbosity == VerbosityLevel.Debug) {
				WriteLine(Apps.Pigmeo.PMC, string.Format(message, p));
			}
		}

		/// <summary>
		/// Prints a message with debugging information about PMC when VerbosityLevel is "debug"
		/// </summary>
		/// <param name="message"></param>
		/// <param name="p"></param>
		public static void InfoDebug(string message, params object[] p) {
			if(config.Verbosity == VerbosityLevel.Debug) {
				WriteLine(Apps.Pigmeo.PMC, string.Format("[DEBUG] " + message, p));
			}
		}
	}
}
