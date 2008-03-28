using System;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// All the available user interfaces and methods that intermediates between the interfaces and the compilation logic
	/// </summary>
	public static class UIs {
		/// <summary>
		/// Main window using WinForms
		/// </summary>
		public static WinForms.MainWindow WinFormsMainWindow;

		/// <summary>
		/// About window using WinForms
		/// </summary>
		public static WinForms.AboutWindow WinFormsAboutWindow;

		/// <summary>
		/// Assembly language source code editor window using WinForms
		/// </summary>
		public static WinForms.AsmEditorWindow WinFormsAsmEditor;

		/// <summary>
		/// Updates the compilation progress status on each interface
		/// </summary>
		/// <param name="value"></param>
		public static void UpdateProgressBar(int value) {
			switch(config.Internal.UI) {
				case UserInterface.Console:
					if(config.Internal.Verbosity != VerbosityLevel.Quiet) PrintMessage(i18n.str(114, value));
					break;
				case UserInterface.WinForms:
					if(WinFormsMainWindow != null) {
						WinFormsMainWindow.ProgBar.Value = value;
						WinFormsMainWindow.lblProgress.Text = value.ToString() + "%";
						WinFormsMainWindow.ProgBar.Refresh();
						WinFormsMainWindow.lblProgress.Refresh();
					}
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface " + config.Internal.UI.ToString());
					break;
			}
			if(config.Internal.Verbosity == VerbosityLevel.Debug) System.Threading.Thread.Sleep(50); //slow down the compilation when debugging
		}

		/// <summary>
		/// Updates the language-dependent strings on the current active graphical interface
		/// </summary>
		public static void UpdateLanguageStrings() {
			switch(config.Internal.UI) {
				case UserInterface.Console:
					//the console doesn't need to be updated
					break;
				case UserInterface.WinForms:
					if(WinFormsMainWindow != null) WinFormsMainWindow.LoadLanguageStrings();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface " + config.Internal.UI.ToString());
					break;
			}
		}

		/// <summary>
		/// Prints a message to the standard output and/or to the graphical interface
		/// </summary>
		/// <param name="message">The message being printed</param>
		/// <param name="args">Parameters to format with the message</param>
		public static void PrintMessage(string message, params object[] args) {
			message = string.Format(message, args);
			switch(config.Internal.UI) {
				case UserInterface.Console:
					Console.WriteLine(message);
					break;
				case UserInterface.WinForms:
					if(WinFormsMainWindow != null) {
						WinFormsMainWindow.txtOutput.AppendText(message + Environment.NewLine);
						WinFormsMainWindow.txtOutput.Refresh();
					}
					goto case UserInterface.Console;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface " + config.Internal.UI.ToString());
					break;
			}
		}

		/// <summary>
		/// Prints a message to the standard error output and/or to the graphical interface
		/// </summary>
		/// <param name="message">The error message being printed</param>
		/// <param name="args">Parameters to format with the message</param>
		public static void PrintErrorMessage(string message, params object[] args) {
			message = string.Format(message, args);
			switch(config.Internal.UI) {
				case UserInterface.Console:
					System.Console.Error.WriteLine(message);
					break;
				case UserInterface.WinForms:
					if(WinFormsMainWindow != null) {
						WinFormsMainWindow.txtOutput.AppendText(message + Environment.NewLine);
						WinFormsMainWindow.txtOutput.Refresh();
					}
					goto case UserInterface.Console;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface " + config.Internal.UI.ToString());
					break;
			}
		}
	}
}
