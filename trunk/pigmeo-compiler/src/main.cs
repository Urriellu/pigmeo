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
			#region program initialization
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs ar) {
				UnknownError.UnhandledExceptionHandler(sender, ar.ExceptionObject as Exception);
			};

			ShowExternalInfo.InfoDebugDel = delegate(string Message) {
				ShowInfo.InfoDebug(Message);
			};

			ShowExternalInfo.InfoDebugDel2 = delegate(string Message, object[] DelArgs) {
				ShowInfo.InfoDebug(Message, DelArgs);
			};

			ShowExternalInfo.InfoDebugDecompileDel = delegate(string Title, object obj) {
				ShowInfo.InfoDebugDecompile(Title, obj);
			};

			config.Internal.LoadSettings();
			CmdLine.ParseParams(args);
			if(config.Internal.CompilationConfigFile != null) config.Compilation.ReadCompilationConfigFile();

			ShowInfo.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "Pigmeo Compiler", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());
			#endregion

			#region tests if we only need to print some information and not actually compile
			if(config.Internal.OnlyPrintInfo) {
				ShowInfo.InfoDebug("Printing a information about {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				foreach(string RepLine in ExeReport.BuildReport(config.Internal.UserApp)) {
					Console.WriteLine(RepLine);
				}
				Environment.Exit(0);
			}

			if(config.Internal.OnlyPrintTargetArch) {
				ShowInfo.InfoDebug("Printing the target architecture of {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				Pigmeo.Internal.Reflection.Assembly ass = new Pigmeo.Internal.Reflection.Assembly(config.Internal.UserApp);
				Console.WriteLine(ass.TargetArch);
				Environment.Exit(0);
			}

			if(config.Internal.OnlyPrintTargetBranch) {
				ShowInfo.InfoDebug("Printing the target branch of {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				Pigmeo.Internal.Reflection.Assembly ass = new Pigmeo.Internal.Reflection.Assembly(config.Internal.UserApp);
				Console.WriteLine(ass.TargetBranch);
				Environment.Exit(0);
			}
			#endregion

			//run the user interface
			switch(config.Internal.UI) {
				case UserInterface.WinForms:
					System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
					System.Windows.Forms.Application.ThreadException += delegate(object sender, System.Threading.ThreadExceptionEventArgs ar) {
						UnknownError.UnhandledExceptionHandler(sender, ar.Exception);
					};
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
					}
					break;
				case UserInterface.Console:
					ShowInfo.InfoDebug("Running console interface");
					if(config.Internal.UserApp != null) {
						ShowInfo.InfoVerbose(i18n.str(100));
						if(!config.Internal.Experimental) GlobalShares.Compile();
						else GlobalShares.Compile(config.Internal.UserApp);
					} else CmdLine.Usage();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface");
					break;
			}
			return 0;
		}
	}
}
