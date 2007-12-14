using System;
using System.Collections.Generic;

namespace Pigmeo.Internal
{
	public class i18n {
		public static string lang;

		public static Dictionary<string, Dictionary<UInt32, string>> languages = new Dictionary<string, Dictionary<uint, string>>();

		public static string str(UInt32 ID) {
			string str="";
			if(languages.ContainsKey(lang) && languages[lang].ContainsKey(ID)) str = languages[lang][ID];
			else {
				if(languages["eng"].ContainsKey(ID)) str = languages["eng"][ID];
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		static i18n() {
			languages.Add("eng", new Dictionary<uint, string>()); //english
			languages.Add("spa", new Dictionary<uint, string>()); //spanish

			//NOTE: if you want to change a string, add a new one, reference it from wherever you want and ignore the old one
			languages["eng"].Add(0, "hello world");


			languages["spa"].Add(0, "hola mundo");
		}
	}
}
