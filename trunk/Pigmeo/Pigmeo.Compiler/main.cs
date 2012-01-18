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
using System.IO;

namespace Pigmeo.Compiler {
	public class main {
		public static int Main(string[] args) {
			#region Debug using Visual Studio
#if DEBUG && VisualStudio
			const string DebugExampleID = "001"; //change this depending of the example you are debugging

			ShowInfo.InfoDebug(string.Format("Debugging example program {0} using Visual Studio", DebugExampleID));

			//find example executable
			string PathExampleExe = SharedSettings.ExeLocation + "/../../../DevExamples/";
			DirectoryInfo DirExampleExe = new System.IO.DirectoryInfo(PathExampleExe);
			DirExampleExe = new DirectoryInfo(DirExampleExe.GetDirectories(DebugExampleID + "-*")[0].FullName + "/VS");
			DirExampleExe = new DirectoryInfo(DirExampleExe.GetDirectories()[0].FullName);
			string DebugVsPrjName = DirExampleExe.Name;
			DirExampleExe = new DirectoryInfo(DirExampleExe.GetDirectories()[0].FullName + "/bin/Release");
			PathExampleExe = DirExampleExe.FullName + "/" + DebugVsPrjName + ".exe";
			if (!File.Exists(PathExampleExe)) throw new Exception("Example not found: " + DebugExampleID + ". You must compile that project in Release mode before passing it to Pigmeo Compiler, so there is a Release/something.exe file ready to be compiled by Pigmeo");

			//we can't pass arguments to Visual Studio while debugging if the project is hosted on a network share. Fuck
			args = ("--debug --ui console " + PathExampleExe).Split(' ');
			config.Internal.DebugExampleVS = true;

			UIs.DebugVS = new UI.WinForms.FrmDebugVS(ShowInfo.OutputMessages);
			UIs.DebugVS.Show();
#endif
			#endregion

			#region program initialization
#if !DEBUG
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs ar) {
				UnknownError.UnhandledExceptionHandler(sender, ar.ExceptionObject as Exception);
			};
#endif

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
			if (config.Internal.CompilationConfigFile != null) config.Compilation.ReadCompilationConfigFile();

			ShowInfo.InfoDebug("Running {0} {1} on {2} as user {3}. CLR version: {4}", "Pigmeo Compiler", SharedSettings.AppVersion, Environment.OSVersion.ToString(), Environment.UserName, Environment.Version.ToString());
			#endregion

			#region tests if we only need to print some information and not actually compile
			if (config.Internal.OnlyPrintInfo) {
				ShowInfo.InfoDebug("Printing a information about {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				foreach (string RepLine in ExeReport.BuildReport(config.Internal.UserApp)) {
					Console.WriteLine(RepLine);
				}
				Environment.Exit(0);
			}

			if (config.Internal.OnlyPrintTargetArch) {
				ShowInfo.InfoDebug("Printing the target architecture of {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				Pigmeo.Internal.Reflection.Assembly ass = Pigmeo.Internal.Reflection.Assembly.GetFromFile(config.Internal.UserApp);
				Console.WriteLine(ass.Target.Architecture);
				Environment.Exit(0);
			}

			if (config.Internal.OnlyPrintTargetBranch) {
				ShowInfo.InfoDebug("Printing the target branch of {0}", config.Internal.UserApp);
				config.Internal.UI = UserInterface.Console;
				Pigmeo.Internal.Reflection.Assembly ass = Pigmeo.Internal.Reflection.Assembly.GetFromFile(config.Internal.UserApp);
				Console.WriteLine(ass.Target.Branch);
				Environment.Exit(0);
			}
			#endregion

			//run the user interface
			switch (config.Internal.UI) {
				case UserInterface.WinForms:
#if !DEBUG
					System.Windows.Forms.Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
					System.Windows.Forms.Application.ThreadException += delegate(object sender, System.Threading.ThreadExceptionEventArgs ar) {
						UnknownError.UnhandledExceptionHandler(sender, ar.Exception);
					};
#endif
					try {
						ShowInfo.InfoVerbose(i18n.str(10));
						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
						UI.UIs.WinFormsMainWindow = new UI.WinForms.MainWindow();
						System.Windows.Forms.Application.Run(UI.UIs.WinFormsMainWindow);
					} catch (TypeInitializationException e) {
						if (e.TargetSite.ReflectedType.FullName == "System.Windows.Forms.Application" && e.TargetSite.Name == "EnableVisualStyles") {
							ShowInfo.InfoDebug("WinForms not supported");
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Warning, "W0003", false);
							config.Internal.UI = UserInterface.Console;
							goto case UserInterface.Console;
						} else throw e;
					}
					break;
				case UserInterface.Console:
					ShowInfo.InfoDebug("Running console interface");
					if (config.Internal.UserApp != null) {
						ShowInfo.InfoVerbose(i18n.str(100));
						string[] AsmCode = GlobalShares.Compile(config.Internal.UserApp);
						if (config.Internal.GenerateAsmFile) FileManager.Write(config.Internal.FileAsm, AsmCode);

						if (config.Internal.DebugExampleVS) {
							UI.UIs.DebugVS.SetExeInfo(ExeReport.BuildReport(config.Internal.UserApp));
							UI.UIs.DebugVS.SetAsm(AsmCode);
							UIs.DebugVS.UpdateEndCompilation();
							System.Windows.Forms.Application.Run(UI.UIs.DebugVS);
						}
					} else CmdLine.Usage();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0001", true, "Unknown configured user interface");
					break;
			}
			if (ErrorsAndWarnings.TotalErrors > 0) return 1;
			else return 0;
		}
	}
}
