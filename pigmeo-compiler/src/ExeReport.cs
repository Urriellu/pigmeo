using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	public class ExeReport {
		protected static List<string> ReportStrings;

		[PigmeoToDo("Must be rewritten using P.I.Reflection and maybe PIR")]
		public static List<string> BuildReport(string FilePath) {
			ReportStrings = new List<string>();
			string FileName = System.IO.Path.GetFileName(FilePath);
			ShowInfo.InfoDebug("Retrieving information about {0}", FilePath);

			ReportStrings.Add(i18n.str("InfoAbout", FileName));

			return ReportStrings;
		}
	}
}
