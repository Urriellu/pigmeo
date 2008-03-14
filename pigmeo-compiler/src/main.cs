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
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {

	public class main {
		public static int Main(string[] args) {
			try {
				CmdLine.ParseParams(args);
				config.Internal.ReadCompilerConfigFile();
				if(config.Internal.CompilationConfigFile!=null) config.Compilation.ReadCompilationConfigFile();

				ShowInfo.InfoDebug("Running {0} on {1} as user {2}. CLR version: {3}", config.Internal.AppName, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());

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
								ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0004", false);
								config.Internal.UI = UserInterface.Console;
								goto case UserInterface.Console;
							} else throw e;
						}
						break;
					case UserInterface.Console:
						ShowInfo.InfoVerbose("Running Console-based user interface");
						GlobalShares.Compile();
						break;
					default:
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface");
						break;
				}
			} catch(Exception e) { //unhandled exception
				string ExceptionStr = "Type: "+e.GetType().Name+", Message: " + e.Message + ", source: " + e.TargetSite.Name+", Stack trace:\n"+e.StackTrace;
				Exception Inner = e.InnerException;
				while(Inner != null) {
					ExceptionStr += "\n"+Inner.Message.ToString();
					Inner = Inner.InnerException;
				}
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, ExceptionStr);

			}
			return 0;
		}
	}
}
