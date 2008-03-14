using System;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// All the available user interfaces and methods that intermediates between the interfaces and the compilation logic
	/// </summary>
	public static class UIs {
		/// <summary>
		/// Main Window using WinForms
		/// </summary>
		public static UI.WinForms.MainWindow WinFormsMainWindow;

		/// <summary>
		/// Updates the compilation progress status on each interface
		/// </summary>
		/// <param name="value"></param>
		public static void UpdateProgressBar(int value) {
			switch(config.Internal.UI) {
				case UserInterface.Console:
					PrintMessage("Compilation status: {0}%", value);
					break;
				case UserInterface.WinForms:
					if(WinFormsMainWindow != null) WinFormsMainWindow.ProgBar.Value = value;
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
					if(WinFormsMainWindow != null) WinFormsMainWindow.txtOutput.Text += message + Environment.NewLine;
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
					if(WinFormsMainWindow != null) WinFormsMainWindow.txtOutput.Text += message;
					goto case UserInterface.Console;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface " + config.Internal.UI.ToString());
					break;
			}
		}
	}
}
