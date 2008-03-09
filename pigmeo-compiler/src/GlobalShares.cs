using System.Collections.Generic;
using Pigmeo.Internal;

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
		/// Runs the compilation
		/// </summary>
		public static void Compile() {
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 0;
			CilFrontend.Frontend();
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 40;
			Backend.RunBackend(GlobalShares.AssemblyToCompile);
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 80;
			//Assembler.RunAssembler();

			ShowInfo.InfoVerbose(i18n.str(11));
			if(config.Internal.UI == UserInterface.WinForms) {
				UI.UIs.WinFormsMainWindow.ProgBar.Value = 100;
				UI.UIs.WinFormsMainWindow.txtOutput.Text += i18n.str(11);
			}
		}
	}
}
