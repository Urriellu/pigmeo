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
using Pigmeo.Internal;

namespace Pigmeo.Compiler {

	/// <summary>
	/// Stuff about errors and warnings that can be thrown when running pigmeo-compiler
	/// </summary>
	/// <remarks>
	/// .NET exception handling is not used for these kind of errors because it is not able to throw warnings and non-fatal errors without adding a lot of try-catch blocks everywhere and sometimes we only want to show a message
	/// </remarks>
	public class ErrorsAndWarnings {
		/// <summary>
		/// Available types of thrown errors
		/// </summary>
		public enum errType { Error, Warning };

		/// <summary>
		/// Stores all the information about the errors and warnings
		/// </summary>
		private static Dictionary<string, string> ErrWarns = new Dictionary<string, string>();

		/// <summary>
		/// Gets the total amount of warnings shown
		/// </summary>
		public static UInt32 TotalWarnings {
			get {
				return _TotalWarnings;
			}
		}
		private static UInt32 _TotalWarnings;

		/// <summary>
		/// Gets the total amount of errors thrown
		/// </summary>
		public static UInt32 TotalErrors;



		/// <summary>
		/// Shows a message with info about the error or warning
		/// </summary>
		/// <param name="type">Type (error or warning)</param>
		/// <param name="ID">Its ID (i.e. CFG0032)</param>
		/// <param name="exit">Specifies if the execution must be stopped (set true for fatal errors)</param>
		/// <param name="p">Miscellaneus extra information shown to the user. Remember: this string is language-dependent, but if ID=="INT0001" you don't need to translate it because it's only useful for developers.</param>
		public static void Throw(errType type, string ID, bool exit, params string[] p) {
			if(ErrWarns.ContainsKey(ID)) {
				string message = "";
				switch(type) {
					case errType.Warning:
						_TotalWarnings++;
						message += i18n.str(26);
						break;
					case errType.Error:
						TotalErrors++;
						message += i18n.str(27);
						break;
				}
				message += string.Format(" {0}: {1}", ID, ErrWarns[ID]);
				if(p.Length > 0) {
					message += i18n.str(28, p[0]);
				}
				string StackTrace = Environment.StackTrace;
				//StackTrace = StackTrace.Remove(0, StackTrace.IndexOf(Environment.NewLine, StackTrace.IndexOf(Environment.NewLine) + 1) + 1); //remove System.Environment.get_StackTrace() and Pigmeo.Compiler.ErrorsAndWarnings.Throw() from the stack trace
				if(type == errType.Error) {
					UI.UIs.PrintErrorMessage(message);
					UI.UIs.PrintErrorMessage(StackTrace);
					UI.UIs.PrintErrorMessage(i18n.str(29, ID));
				} else {
					UI.UIs.PrintMessage(message);
					UI.UIs.PrintMessage(StackTrace);
					UI.UIs.PrintMessage(i18n.str(29, ID));
				}

				if(exit) Environment.Exit(1);
			} else {
				//the error ID doesn't exist. It means an internal bug
				ErrorsAndWarnings.Throw(errType.Error, "INT0002", true, i18n.str(30, ID));
			}
		}

		/// <summary>
		/// Throws an ErrorsAndWarning based on a given exception. This is called when an unhandled exception is caught
		/// </summary>
		public static void ThrowUnhandledException(Exception e) {
			string ExceptionStr = "Type: " + e.GetType().Name + ", Message: " + e.Message + ", source: " + e.TargetSite.Name + ", Stack trace:" + Environment.NewLine + e.StackTrace;
			Exception Inner = e.InnerException;
			while(Inner != null) {
				ExceptionStr += Environment.NewLine + Inner.Message.ToString();
				Inner = Inner.InnerException;
			}
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, ExceptionStr);
		}

		/// <summary>
		/// Fills the list of errors and warnings available for tha current language. It must be called each time the language is changed or the strings will continue being printed in the previous language
		/// </summary>
		public static void LoadErrAndWarnStrings() {
			ErrWarns.Clear();
			
			//internals
			ErrWarns.Add("INT0001", i18n.str("UnknExc"));
			ErrWarns.Add("INT0002", i18n.str("UnknErrWarn"));
			ErrWarns.Add("INT0003", i18n.str("Unimplemented"));
			//ErrWarns.Add("INT0004", i18n.str(34));
			ErrWarns.Add("INT0005", i18n.str("InvProgVal"));
			ErrWarns.Add("INT0006", i18n.str("TargetDevInfoIsNull"));
			ErrWarns.Add("INT0007", i18n.str("UIUnsupOpt"));
			ErrWarns.Add("INT0008", i18n.str("UnkCompilExc"));

			//warnings
			ErrWarns.Add("W0001", i18n.str("OldConfFile"));
			ErrWarns.Add("W0002", i18n.str("UnkOptim"));
			ErrWarns.Add("W0003", i18n.str("WinFormsNotAvail"));

			//configuration errors
			ErrWarns.Add("CFG0001", i18n.str("UnkConfFileVers"));
			ErrWarns.Add("CFG0002", i18n.str("XmlNodeNotFound"));
			ErrWarns.Add("CFG0003", i18n.str("UnsupConfFileVers"));
			ErrWarns.Add("CFG0004", i18n.str("ReqXmlNodeNotFound"));
			ErrWarns.Add("CFG0005", i18n.str("InvalidXml"));
			ErrWarns.Add("CFG0006", i18n.str(43)); //DEPRECATED
			ErrWarns.Add("CFG0007", i18n.str("FileNotFound"));

			//frontend errors
			ErrWarns.Add("FE0001", i18n.str("UnableLoadAss")); //DEPRECATED
			ErrWarns.Add("FE0002", i18n.str(46)); //DEPRECATED
			ErrWarns.Add("FE0003", i18n.str("UnableFindDevLib"));
			ErrWarns.Add("FE0004", i18n.str(48)); //DEPRECATED
			ErrWarns.Add("FE0005", i18n.str("UnableFindFieldDef"));
			ErrWarns.Add("FE0006", i18n.str("UnkCilOp"));
			ErrWarns.Add("FE0007", i18n.str("UnsupCallStatMth"));

			//backend errors
			ErrWarns.Add("BE0001", i18n.str("UnsupTrgArch"));
			ErrWarns.Add("BE0002", i18n.str("UnsupNumSys"));
			ErrWarns.Add("BE0003", i18n.str("UnsupCilInst"));
			ErrWarns.Add("BE0004", i18n.str("TypeNotSup"));
			ErrWarns.Add("BE0005", i18n.str("UnsupExcepImpl"));
			ErrWarns.Add("BE0006", i18n.str("ExcepDisbld"));
			ErrWarns.Add("BE0007", i18n.str("UnsupEOAppBehav"));
			ErrWarns.Add("BE0008", i18n.str("StMethodsNotImpl"));
		}

		/// <summary>
		/// Initializes the <see cref="ErrorsAndWarnings"/> class.
		/// </summary>
		static ErrorsAndWarnings() {
			LoadErrAndWarnStrings();
		}
	}
}
