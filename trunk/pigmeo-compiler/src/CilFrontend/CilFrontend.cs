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
using Mono.Merge;
using Mono.Cecil;

namespace PigmeoCompiler {
	/// <summary>
	/// Everything related to the CIL Frontend, which parses the CIL, 
	/// creates the required packages and optimizes it for all the architectures
	/// </summary>
	public class CilFrontend {
		/// <summary>
		/// Runs the CIL Frontend
		/// </summary>
		/// <remarks>
		/// The CIL Frontend makes packages from all the required CIL 
		/// and optimizes it for all the architectures
		/// </remarks>
		public static void Frontend() {
			ShowInfo.InfoVerbose("Running CIL Frontend...");
			MakeCilPackage();
			MakeUsefulCilPackage();
			OptimizeCil();
		}

		/// <summary>
		/// Crates a big package which contains all the libraries passed 
		/// as reference files
		/// </summary>
		private static void MakeCilPackage() {
			ShowInfo.InfoVerbose("Creating a package that contains everything...");
			
			MergeContext context = Driver.GetDefaultContext();
			foreach(ResourceFile res in config.Compilation.ResourceFiles) {
				context.Assemblies.Add(res.path);
			}

			AssemblyDefinition primary = AssemblyFactory.GetAssembly(context.Assemblies[0]);

			for(int i = 1 ; i < context.Assemblies.Count ; i++) {
				AssemblyDefinition asm = AssemblyFactory.GetAssembly(context.Assemblies[i]);
				asm.Accept(new StructureMerger(context, primary, asm));
			}

			FixReflectionAfterMerge fix = new FixReflectionAfterMerge(context, primary, primary);
			fix.Process();

			Console.WriteLine("Saving file {0}", config.Internal.FilePckGross);
			AssemblyFactory.SaveAssembly(primary, config.Internal.FilePckGross);

		}


		/// <summary>
		/// Removes all the unuseful things from the first CIL package, 
		/// and only the things used in the application for microcontrollers will remain.
		/// </summary>
		private static void MakeUsefulCilPackage() {
			ShowInfo.InfoVerbose("Removing unuseful thing from the CIL package...");
		}

		private static void OptimizeCil() {
			ShowInfo.InfoVerbose("Optimizing CIL for all the architectures");
		}
	}
}
