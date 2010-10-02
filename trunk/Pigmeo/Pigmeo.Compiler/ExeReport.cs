using System;
using System.Collections.Generic;
using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler {
	public class ExeReport {
		protected static List<string> ReportStrings;

		/// <summary>
		/// Builds a report with detailed information about an assembly (.exe file)
		/// </summary>
		/// <param name="FilePath">Full path to the assembly</param>
		/// <returns>Collection of lines with all the information</returns>
		public static List<string> BuildReport(string FilePath) {
			ReportStrings = new List<string>();
			string FileName = System.IO.Path.GetFileName(FilePath);
			ShowInfo.InfoDebug("Retrieving information about {0}", FilePath);

			ReportStrings.Add(i18n.str("InfoAbout", FileName));

			Assembly ass = Assembly.GetFromFile(FilePath);
			ReportStrings.Add(ass.FullName);
			ReportStrings.Add("EntryPoint: " + ass.EntryPoint.FullNameWAssParams);
			ReportStrings.Add("References: " + ass.References.ToString());
			ReportStrings.Add("Target Architecture: " + ass.Target.Architecture);
			ReportStrings.Add("Target Family: " + ass.Target.Family);
			ReportStrings.Add("Target Branch: " + ass.Target.Branch);
			ReportStrings.Add("Types: " + ass.Types);

			return ReportStrings;
		}
	}
}
