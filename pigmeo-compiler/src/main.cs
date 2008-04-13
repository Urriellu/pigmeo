/*
This file is part of Pigmeo.

Pigmeo is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 3 of the License, or
(at your option) any later version.

Pigmeo is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>. 
*/

using System;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;

namespace Pigmeo.Compiler {

	public class main {
		public static int Main(string[] args) {
			try {
				config.Internal.ReadCompilerConfigFile();
				CmdLine.ParseParams(args);
				if(config.Internal.CompilationConfigFile != null) config.Compilation.ReadCompilationConfigFile();

				ShowInfo.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", config.Internal.AppName, config.Internal.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());

				if(config.Internal.OnlyPrintInfo) {
					ShowInfo.InfoDebug("Printing a information about {0}", config.Internal.UserApp);
					foreach(string RepLine in ExeReport.BuildReport(config.Internal.UserApp)) {
						Console.WriteLine(RepLine);
					}
					Environment.Exit(0);
				}

				//run the user interface
				switch(config.Internal.UI) {
					case UserInterface.WinForms:
						try {
							ShowInfo.InfoVerbose(i18n.str(10));
							System.Windows.Forms.Application.EnableVisualStyles();
							System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
							UI.UIs.WinFormsMainWindow = new UI.WinForms.MainWindow();
							System.Windows.Forms.Application.Run(UI.UIs.WinFormsMainWindow);
						} catch(TypeInitializationException e) {
							if(e.TargetSite.ReflectedType.FullName == "System.Windows.Forms.Application" && e.TargetSite.Name == "EnableVisualStyles") {
								ShowInfo.InfoDebug("WinForms not supported");
								ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Warning, "W0003", false);
								config.Internal.UI = UserInterface.Console;
								goto case UserInterface.Console;
							} else throw e;
						} catch (Exception e) {
							ShowInfo.InfoDebug("Catching unhandled exception on WinForms interface");
							//ErrorsAndWarnings.ThrowUnhandledException(e, false);
							UIs.WinFormsUnhndldExcMail = new UI.WinForms.UnhandledExceptionSendMailWindow(e);
							UIs.WinFormsUnhndldExcMail.ShowDialog(UIs.WinFormsMainWindow);
							System.Windows.Forms.Application.Restart();
						}
						break;
					case UserInterface.Console:
						ShowInfo.InfoDebug("Running console interface");
						if(config.Internal.UserApp != null) {
							ShowInfo.InfoVerbose(i18n.str(100));
							GlobalShares.Compile();
						} else CmdLine.Usage();
						break;
					default:
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface");
						break;
				}
			} catch(Exception e) { //unhandled exception
				ShowInfo.InfoDebug("Cathing an unhandled exception");
				ErrorsAndWarnings.ThrowUnhandledException(e);
			}
			return 0;
		}
	}
}
