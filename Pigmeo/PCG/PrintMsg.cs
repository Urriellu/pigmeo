﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PCG {
	/// <summary>
	/// Methods used to print messages
	/// </summary>
	public static class PrintMsg {
		/// <summary>
		/// Prints any kind of message to the standard output
		/// </summary>
		/// <param name="message">Message being printed to the standard output</param>
		/// <param name="p">Formatting objects</param>
		public static void WriteLine(string message, params object[] p) {
			Console.WriteLine(message, p);
		}

		/// <summary>
		/// Prints any kind of message to the error output
		/// </summary>
		/// <param name="message">Message being printed to the error output</param>
		/// <param name="p">Formatting objects</param>
		private static void WriteErrorLine(string message, params object[] p) {
			Console.Error.WriteLine(message, p);
		}

		/// <summary>
		/// Prints a message with debugging information about PCG when debugging
		/// </summary>
		/// <param name="message">Message being printed to the error output</param>
		/// <param name="p">Formatting objects</param>
		public static void WriteInfoDebug(string message, params object[] p) {
			if(config.Debug) {
				WriteLine("[DEBUG] " + message, p);
			}
		}

		/// <summary>
		/// Prints an error message
		/// </summary>
		/// <param name="message">Error message to print</param>
		/// <param name="p">Formatting objects</param>
		public static void WriteError(string message, params object[] p) {
			WriteErrorLine(message, p);
		}
	}
}
