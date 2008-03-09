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
using System.Collections;
using Pigmeo.Internal;

namespace Pigmeo.Compiler {

	public class main {
		public static int Main(string[] args) {
			try {
				CmdLine.ParseParams(args);
				config.Internal.ReadCompilerConfigFile();
				if(config.Internal.CompilationConfigFile!=null) config.Compilation.ReadCompilationConfigFile();
				ShowInfo.InfoDebug("Running " + config.Internal.ExePath);

				//run the user interface
				switch(config.Internal.UI) {
					case UserInterface.WinForms:
						ShowInfo.InfoVerbose(i18n.str(10));
						System.Windows.Forms.Application.EnableVisualStyles();
						System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
						UI.UIs.WinFormsMainWindow = new UI.WinForms.MainWindow();
						System.Windows.Forms.Application.Run(UI.UIs.WinFormsMainWindow);
						break;
					case UserInterface.Console:
						ShowInfo.InfoVerbose("Running Console-based user interface");
						CilFrontend.Frontend();
						Backend.RunBackend(GlobalShares.AssemblyToCompile);
						//Assembler.RunAssembler();
						ShowInfo.InfoVerbose(i18n.str(11));
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
