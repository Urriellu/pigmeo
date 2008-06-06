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
			return strs.CommaSeparatedList(true);
		}

		/// <summary>
		/// Gets the list of strings separated by a comma
		/// </summary>
		/// <param name="spaced">True if the list is separated by a comma followed by a space. False if the separator is just a comma</param>
		public static string CommaSeparatedList(this string[] strs, bool spaced) {
			string separator = ",";
			if(spaced) separator = ", ";

			string list = "";
			for(int i = 0 ; i < strs.Length ; i++) {
				if(i == 0) list += strs[i];
				else list += separator + strs[i];
			}
			return list;
		}
	}
}
