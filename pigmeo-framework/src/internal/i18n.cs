using System;
using System.Collections.Generic;

namespace Pigmeo.Internal
{
	public class i18n {
		public static string lang;

		public static Dictionary<string, Dictionary<UInt32, string>> languages = new Dictionary<string, Dictionary<uint, string>>();

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		public static string str(UInt32 ID) {
			string str="";
			if(languages.ContainsKey(lang) && languages[lang].ContainsKey(ID)) str = languages[lang][ID];
			else {
				if(languages["eng"].ContainsKey(ID)) str = languages["eng"][ID];
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		/// <param name="replacements">Strings that replace {0}, {1}, {2}... in the original string</param>
		public static string str(UInt32 ID, params string[] replacements) {
			string str = "";
			if(languages.ContainsKey(lang) && languages[lang].ContainsKey(ID)) str = string.Format(languages[lang][ID], replacements);
			else {
				if(languages["eng"].ContainsKey(ID)) str = string.Format(languages["eng"][ID], replacements);
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Static constructor. It loads all the strings
		/// </summary>
		static i18n() {
			languages.Add("eng", new Dictionary<uint, string>()); //english
			languages.Add("spa", new Dictionary<uint, string>()); //spanish

			//NOTE: if you want to change a string don't do it. Add a new one instead, reference it from wherever you want and ignore the old one
			//languages["eng"].Add(, "");
			languages["eng"].Add(0, "hello world");
			languages["eng"].Add(1, "File");
			languages["eng"].Add(2, "Open");
			languages["eng"].Add(3, "Exit");
			languages["eng"].Add(4, "About {0}");
			languages["eng"].Add(5, "About");
			languages["eng"].Add(6, "Help");
			languages["eng"].Add(7, "This application takes a .NET executable and converts it to assembly language for microcontrollers or embedded systems.");
			languages["eng"].Add(8, "Developers:");
			languages["eng"].Add(9, "For more information, visit the project website");
			languages["eng"].Add(10, "Running WinForms user interface");
			languages["eng"].Add(11, "Finished");
			languages["eng"].Add(12, "Error");
			languages["eng"].Add(13, "This functionality hasn't been implemented yet");


			languages["spa"].Add(0, "hola mundo");
			languages["spa"].Add(1, "Archivo");
			languages["spa"].Add(2, "Abrir");
		}
	}
}
