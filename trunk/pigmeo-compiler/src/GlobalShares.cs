using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

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
		public static void Compile() {
			CompilationProgress = 0;
			CilFrontend.Frontend();
			CompilationProgress = 40;
			Backend.RunBackend(GlobalShares.AssemblyToCompile);
			CompilationProgress = 80;
			//Assembler.RunAssembler();

			ShowInfo.InfoVerbose(i18n.str(11));
			GlobalShares.CompilationProgress = 100;
		}
	}
}
