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

namespace Pigmeo.Compiler {

	public class main {
		public static int Main(string[] args) {
			try {
				CmdLine.ParseParams(args);
				if(config.Internal.ConfigFile!=null) config.Compilation.ReadCompilationConfigFile();

				CilFrontend.Frontend();
				Backend.RunBackend();
				Assembler.RunAssembler();
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
