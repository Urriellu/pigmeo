using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Extensions {
	public static class StringArrayExtensions {
		/// <summary>
		/// Gets the list of strings separated by a comma
		/// </summary>
		public static string CommaSeparatedList(this string[] strs) {
			string list = "";
			for(int i = 0 ; i < strs.Length ; i++) {
				if(i == 0) list += strs[i];
				else list += ", " + strs[i];
			}
			return list;
		}
	}
}
