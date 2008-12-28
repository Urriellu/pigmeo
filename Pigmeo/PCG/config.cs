using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pigmeo.Internal;

namespace Pigmeo.PCG {
	/// <summary>
	/// Contains all the configuration variables
	/// </summary>
	public static class config {
		public static bool Debug = false;
		public static bool Interactive = true;

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

		public static void LoadSettings() {
			i18n.CurrentApp = "pcg";
			lang = i18n.DefaultLang;
			Developers.Add("Adrián Bulnes [Urriellu] <urriellu@pigmeo.org>");
		}
	}
}
