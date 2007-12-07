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
using System.Collections.Generic;

namespace Pigmeo.Compiler {

	/// <summary>
	/// Stuff about errors and warnings that can be thrown when running pigmeo-compiler
	/// </summary>
	/// <remarks>
	/// .NET exception handling is not used for these kind of errors because it is not able to throw warnings and non-fatal errors without adding a lot of try-catch blocks everywhere and sometimes we only want to show a message
	/// </remarks>
	public class ErrorsAndWarnings {
		public enum errType { Error, Warning };

		/// <summary>
		/// Stores all the information about the errors and warnings
		/// </summary>
		private static Dictionary<string,string> ErrWarns = new Dictionary<string,string>();

		private static UInt32 _TotalWarnings;
		/// <summary>
		/// Gets the total amount of warnings shown
		/// </summary>
		public static UInt32 TotalWarnings {
			get {
				return _TotalWarnings;
			}
		}

		private static UInt32 _TotalErrors;
		/// <summary>
		/// Gets the total amount of errors thrown
		/// </summary>
		public static UInt32 TotalErrors{
			get {
				return _TotalErrors;
			}
		}



		/// <summary>
		/// Shows a message with info about the error or warning
		/// </summary>
		/// <param name="type">Type (error or warning)</param>
		/// <param name="ID">Its ID (i.e. CFG0032)</param>
		/// <param name="exit">Specifies if the execution must be stopped (set true for fatal errors)</param>
		public static void Throw(errType type, string ID, bool exit, params string[] p) {
			if(ErrWarns.ContainsKey(ID)) {
				switch(type) {
					case errType.Warning:
						_TotalWarnings++;
						Console.Write("Warning");
						break;
					case errType.Error:
						_TotalErrors++;
						Console.Write("Error");
						break;
				}
				Console.Write(" {0}: {1}", ID, ErrWarns[ID]);
				if(p.Length > 0) {
					Console.Write(". Extra info: {0}", p[0]);
				}
				Console.Write(Environment.NewLine);
				Console.WriteLine("\tSee http://pigmeo.org/InfoError.php?id={0}", ID);

				if(exit) Environment.Exit(1);
			} else {
				//the error ID doesn't exist. It means an internal bug
				ErrorsAndWarnings.Throw(errType.Error, "INT0002", true, "Trying to throw error/warning " + ID);
			}
		}

		/// <summary>
		/// Initializes the <see cref="ErrorsAndWarnings"/> class.
		/// </summary>
		static ErrorsAndWarnings() {
			//internals
			ErrWarns.Add("INT0001", "Unknown exception");
			ErrWarns.Add("INT0002", "Unknown error");
			ErrWarns.Add("INT0003", "Unimplemented");

			//warnings
			ErrWarns.Add("W0001", "You are using an old config file version");
			ErrWarns.Add("W0002", "Found unknown optimization in the config file. It will be ignored");

			//config file errors
			ErrWarns.Add("CFG0001", "Unknown version of config file");
			ErrWarns.Add("CFG0002", "XML node \"PigmeoCompilerConfig\" not found");
			ErrWarns.Add("CFG0003", "Unsupported config file version");
			ErrWarns.Add("CFG0004", "Required XML Node not found in the config file");
			ErrWarns.Add("CFG0005", "Wrong XML syntax or structure");
			ErrWarns.Add("CFG0006", "Invalid resource in the XML node \"ResourceFiles\"");

			//frontend errors
			ErrWarns.Add("FE0001", "Unable to load assembly");
			ErrWarns.Add("FE0002", "Exception thrown by MonoMerge"); //DEPRECATED
			ErrWarns.Add("FE0003", "Unable to find the device library");
			ErrWarns.Add("FE0004", "The assembly doesn't contain a path to a device library");

			//backend errors
			ErrWarns.Add("BE0001", "Unsupported target architecture");
		}
	}
}
