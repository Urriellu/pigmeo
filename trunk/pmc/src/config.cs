using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Internal.Reflection;

namespace Pigmeo.PMC {
	/// <summary>
	/// Available verbosity levels (the amount of messages printed to the user)
	/// </summary>
	public enum VerbosityLevel { Quiet, Verbose, Debug }

	/// <summary>
	/// Contains all the configuration variables
	/// </summary>
	public static class config {
		/// <summary>
		/// Verbosity level (the amount of messages printed to the user)
		/// </summary>
		public static VerbosityLevel Verbosity = VerbosityLevel.Quiet;

		public static char PathSplitter = '/';

		/// <summary>
		/// Full path to the directory that contains the PMC executable file. The last character is NOT a slash ('/')
		/// </summary>
		public static string ExeLocation {
			get {
				if(_ExeLocation == null) _ExeLocation = System.IO.Path.GetDirectoryName(ExePath);
				return _ExeLocation;
			}
		}
		private static string _ExeLocation;

		/// <summary>
		/// Full path to the PMC executable file
		/// </summary>
		public static string ExePath {
			get {
				if(_ExePath == null) _ExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
				return _ExePath;
			}
		}
		private static string _ExePath;

		/// <summary>
		/// Language used for showing messages
		/// </summary>
		public static string lang {
			get {
				return _lang;
			}
			set {
				_lang = value;
				i18n.CurrentLanguage = value;
				i18n.LoadLangStrings();
			}
		}
		private static string _lang;

		/// <summary>
		/// List of developers
		/// </summary>
		public static List<string> Developers = new List<string>();

		public static List<string> SourceFiles = new List<string>();

		public static void LoadSettings() {
			i18n.CurrentApp = "pmc";

			lang = i18n.DefaultLang;

			Developers.Add("Adrián Bulnes [Urriellu] <urriellu@pigmeo.org>");
		}

		/// <summary>
		/// .NET/CLI programming language in which the source code being compiled was written
		/// </summary>
		public static CLILanguages CompilingLang;

		public static string CompiledExePath = "userapp.exe";
		public static string AsmFilePath = "userapp.asm";

		public static Assembly ReflectedUserApp {
			get {
				if(_ReflectedUserApp == null) _ReflectedUserApp = Assembly.GetFromFile(CompiledExePath);
				return _ReflectedUserApp;
			}
		}
		private static Assembly _ReflectedUserApp;
	}
}
