using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using Pigmeo.Compiler.PIR;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Miscellaneous variables and objects available for the entire application
	/// </summary>
	public static class GlobalShares {
		/// <summary>
		/// Assembly which is going to be compiled. It is usually created from Frontend()
		/// </summary>
		/// <remarks>
		/// We need to store the assembly here so we can compile it (in the backend) after running the frontend without saving it to disk
		/// </remarks>
		public static Mono.Cecil.AssemblyDefinition AssemblyToCompile;

		/// <summary>
		/// List of references of the user application
		/// </summary>
		public static List<string> UserAppReferenceFiles = new List<string>();

		/// <summary>
		/// Gets or sets the compilation 
		/// </summary>
		public static int CompilationProgress {
			get {
				return _CompilationProgress;
			}
			set {
				if(value < 0 || value > 100) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0005", false, "Received value: " + value.ToString());
				else {
					_CompilationProgress = value;
					UI.UIs.UpdateProgressBar(value);
				}
			}
		}
		private static int _CompilationProgress = 0;

		/// <summary>
		/// Runs the compilation
		/// </summary>
		public static string[] Compile(string CompilingFile) {
			string[] AssemblyCode = null;
			DateTime StartTime = DateTime.Now;
			ErrorsAndWarnings.TotalErrors = 0;
			CompilationProgress = 0;
#if !DEBUG
			try {
#endif
				Program UserProgram = Frontend.Run(config.Internal.UserApp);
				AssemblyCode = Backend.Run(UserProgram);
#if !DEBUG
			} catch(Exception e) {
				if(ErrorsAndWarnings.TotalErrors > 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0008", false, e.Message);
				else throw e;
			}
#endif

			if(ErrorsAndWarnings.TotalErrors == 0) {
				ShowInfo.InfoVerbose(i18n.str(11));
				GlobalShares.CompilationProgress = 100;
			} else ShowInfo.InfoVerbose(i18n.str("CompEndErrors", ErrorsAndWarnings.TotalErrors));
			DateTime EndTime = DateTime.Now;
			TimeSpan CompilationTime = EndTime - StartTime;
			ShowInfo.InfoVerbose(i18n.str("CompileTime", CompilationTime.Minutes, CompilationTime.Seconds, CompilationTime.Milliseconds));
			return AssemblyCode;
		}
	}
}
