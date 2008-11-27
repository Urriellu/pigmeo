using System;
using System.Collections.Generic;
using System.IO;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	public static class FileManager {
		/// <summary>
		/// Writes text to a file
		/// </summary>
		public static void Write(string file, string[] Lines) {
			ShowInfo.InfoDebug("Saving file {0}", file);

			TextWriter tw;
			try {
				tw = new StreamWriter(file, false, System.Text.Encoding.ASCII);
				tw.NewLine = config.Internal.EndOfLine;
				foreach(string str in Lines) {
					tw.WriteLine(str);
				}
				tw.Close();
			} catch {
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0007", true, file);
			}
		}
	}
}
