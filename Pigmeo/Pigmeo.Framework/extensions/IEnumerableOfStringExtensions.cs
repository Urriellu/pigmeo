using System;
using System.Collections.Generic;

namespace Pigmeo.Extensions {
	public static class IEnumerableOfStringExtensions {
		/// <summary>
		/// Gets the list of strings separated by a comma plus a space
		/// </summary>
		public static string CommaSeparatedList(this IEnumerable<string> strs) {
			return strs.CommaSeparatedList(true);
		}

		/// <summary>
		/// Gets the list of strings separated by a comma
		/// </summary>
		/// <param name="spaced">True if the list is separated by a comma followed by a space. False if the separator is just a comma</param>
		public static string CommaSeparatedList(this IEnumerable<string> strs, bool spaced) {
			string separator = ",";
			if(spaced) separator = ", ";
			string list = "";
			foreach(string str in strs) list += str + separator;
			if(list.Length > 2) list = list.Substring(0, list.Length - separator.Length);
			return list;
		}
	}
}
