using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Pigmeo.Internal {
	/// <summary>
	/// Contains all the variables and methods required for showing internationalized strings. Before using any of it you must set CurrentLanguage and CurrentApp
	/// </summary>
	/// <remarks>
	/// Only one language will be loaded at a time. All the strings are loaded automatically by this class. All the strings are stored in flat files, called "CurrentApp.CurrentLanguage.lang". For examen if Pigmeo Compiler is showing messages in spanish, the file "pigmeo-compiler.es.lang" will be loaded.
	/// </remarks>
	public class i18n {
		protected static string LangFilesPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/i18n";

		/// <summary>
		/// Gets or sets the current language
		/// </summary>
		public static string CurrentLanguage {
			get {
				if(_CurrentLanguage == null) _CurrentLanguage = "en";
				return _CurrentLanguage;
			}
			set {
				//if(languages.ContainsKey(value)) _CurrentLanguage = value;
				if(AvailableLanguages.Contains(value)) {
					_CurrentLanguage = value;
					LangStrings.Clear();
				} else throw new Exception("Unknown language: " + value);
			}
		}
		private static string _CurrentLanguage;

		/// <summary>
		/// Name of the application using this library.
		/// </summary>
		public static string CurrentApp;

		public static List<string> AvailableLanguages {
			get {
				if(_AvailableLanguages == null) {
					_AvailableLanguages = new List<string>();
					//get the list of available languages
					_AvailableLanguages.Clear();
					DirectoryInfo dir = new DirectoryInfo(LangFilesPath);
					FileInfo[] files = dir.GetFiles(CurrentApp + ".*.lang");
					if(files.Length == 0) throw new Exception(string.Format("No language files found in {0}. CurrentApp={1}", LangFilesPath, CurrentApp));
					foreach(FileInfo fi in files) {
						_AvailableLanguages.Add(fi.Name.Remove(0, CurrentApp.Length + 1).Replace(".lang", ""));
					}
				}
				return _AvailableLanguages;
			}
		}
		protected static List<string> _AvailableLanguages;

		public static string GetLangFromNativeName(string NativeName) {
			string TwoLetterName = "";
			foreach(CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
				if(culture.NativeName == NativeName) TwoLetterName = culture.TwoLetterISOLanguageName;
			}
			return TwoLetterName;
		}

		protected static Dictionary<string, string> LangStrings = new Dictionary<string, string>();

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification</param>
		/// <param name="replacements">Strings that replace {0}, {1}, {2}... in the original string</param>
		public static string str(UInt32 ID, params object[] replacements) {
			return str(ID.ToString(), replacements);
		}

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification</param>
		/// <param name="replacements">Strings that replace {0}, {1}, {2}... in the original string</param>
		public static string str(string ID, params object[] replacements) {
			if(LangStrings.Keys.Count == 0) LoadLangStrings();
			string str = "";
			if(LangStrings.ContainsKey(ID)) str = LangStrings[ID];
			else throw new Exception("Unknown i18n ID: " + ID);
			return str;
		}

		protected static void LoadLangStrings() {
			if(_CurrentLanguage == null) throw new Exception("Language not set");
			if(CurrentApp == null) throw new Exception("Application name not set");

			LangStrings.Clear();
			string ID = "", text = "";

			//first load english strings
			TextReader tr = new StreamReader(LangFilesPath + "/" + CurrentApp + ".en.lang");
			while(true) {
				string NewLine = tr.ReadLine();
				if(NewLine != null) {
					ParseLine(NewLine, out ID, out text);
					if(LangStrings.ContainsKey(ID)) throw new Exception("Duplicated ID: " + ID);
					LangStrings.Add(ID, text);
				} else break;
			}
			tr.Close();

			//replace some of them with the configured language strings
			tr = new StreamReader(LangFilesPath + "/" + CurrentApp + "." + CurrentLanguage + ".lang");
			while(true) {
				string NewLine = tr.ReadLine();
				if(NewLine != null) {
					ParseLine(NewLine, out ID, out text);
					if(!LangStrings.ContainsKey(ID)) throw new Exception(string.Format("The language {0} has an incorrect string ID: {1}", CurrentLanguage, ID));
					LangStrings[ID] = text;
				} else break;
			}
			tr.Close();
		}

		/// <summary>
		/// Parse a line from a language file
		/// </summary>
		/// <param name="LineText">The entire text of the line</param>
		/// <param name="ID">Outputs the ID of the line</param>
		/// <param name="text">Outputs the associated text with that ID</param>
		protected static void ParseLine(string LineText, out string ID, out string text) {
			ID = LineText.Remove(LineText.IndexOf(' '));
			text = LineText.Substring(ID.Length + 1);
		}
	}
}
