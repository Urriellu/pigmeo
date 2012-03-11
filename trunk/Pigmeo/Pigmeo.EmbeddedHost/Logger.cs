using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.EmbeddedHost {
	public static class Logger {
		public static void LogHost(string text, params object[] p) {
			string s = GetStamp("Host") + string.Format(text, p);
			Log(s);
		}

		private static void Log(string s) {
			Console.WriteLine(s);
		}

		private static string GetStamp(string p) {
			return "[" + DateTime.Now.ToLongTimeString() + " - " + p + "] ";
		}
	}
}
