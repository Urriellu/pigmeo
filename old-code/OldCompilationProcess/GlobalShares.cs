using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using Pigmeo.Compiler.PIR;

namespace Pigmeo.Compiler {
	class GlobalShares {
		/// <summary>
		/// Runs the compilation
		/// </summary>
		[Obsolete("Use Compile(string FileToCompile")]
		public static void Compile() {
			DateTime StartTime = DateTime.Now;
			ErrorsAndWarnings.TotalErrors = 0;
			CompilationProgress = 0;
			try {
				CilFrontend.Frontend();
				CompilationProgress = 40;
				if(ErrorsAndWarnings.TotalErrors > 0) {
					ShowInfo.InfoVerbose(i18n.str(136, ErrorsAndWarnings.TotalErrors));
					return;
				}
				Backend.RunBackend(GlobalShares.AssemblyToCompile);
				if(ErrorsAndWarnings.TotalErrors > 0) {
					ShowInfo.InfoVerbose(i18n.str(136, ErrorsAndWarnings.TotalErrors));
					return;
				}
				CompilationProgress = 80;
				//Assembler.RunAssembler();
			} catch(Exception e) {
				if(ErrorsAndWarnings.TotalErrors > 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0008", false);
				else throw e;
			}

			if(ErrorsAndWarnings.TotalErrors == 0) {
				ShowInfo.InfoVerbose(i18n.str(11));
				GlobalShares.CompilationProgress = 100;
			} else ShowInfo.InfoVerbose(i18n.str("CompEndErrors", ErrorsAndWarnings.TotalErrors));
			DateTime EndTime = DateTime.Now;
			TimeSpan CompilationTime = EndTime - StartTime;
			ShowInfo.InfoVerbose(i18n.str("CompileTime", CompilationTime.Minutes, CompilationTime.Seconds, CompilationTime.Milliseconds));
			if(ErrorsAndWarnings.TotalErrors > 0) Environment.Exit(1);
		}
	}
}
