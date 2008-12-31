using System;
using System.Collections.Generic;
using System.IO;
using Pigmeo.Internal;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler {
	/// <summary>
	/// The Frontend generates a Pigmeo Intermediate Representation from a .NET executable
	/// </summary>
	public static partial class Frontend {
		/// <summary>
		/// Runs the CIL Frontend
		/// </summary>
		/// <remarks>
		/// The CIL Frontend generates a Pigmeo Intermediate Representation from a .NET executable and optimizes it for all the architectures
		/// </remarks>
		public static Program Run(string CompilingFile) {
			ShowInfo.InfoDebug("Running the Frontend");

			PRefl.Assembly ReflectedAssembly = PRefl.Assembly.GetFromFile(CompilingFile);
			ShowInfo.InfoDebugDecompile("Reflected assembly", ReflectedAssembly);
			Program PlainProgram = Program.GetFromCIL(ReflectedAssembly);
			ShowInfo.InfoDebugDecompile("Original assembly converted to PIR", PlainProgram);
			Program OptimizedProgram = OptimizeProgram(PlainProgram);
			ShowInfo.InfoDebugDecompile("PIR optimized", OptimizedProgram);

			return OptimizedProgram;
		}

		/// <summary>
		/// Optimizes the generated PIR for all the architectures
		/// </summary>
		/// <remarks>
		/// Architecture or family-related optimizations are done in the backend of each architecure
		/// </remarks>
		private static Program OptimizeProgram(Program OriginalProgram) {
			Program OptimizedProg = OriginalProgram;

			#region optimizations that don't have influence on other optimizations and must be executed at the beginning
			OptimizedProg.AvoidTOSS();
			#endregion

			#region optimizations that DO have influence on other optimizations
			bool KeepOptimizing = true;
			while(KeepOptimizing) {
				KeepOptimizing = false;
				OptimizedProg.FindSingleCallInlinizable();
				OptimizedProg.FindShortInlinizableMethods();
				if(OptimizedProg.InLineAll()) KeepOptimizing = true;
				if(OptimizedProg.ImplementInternally()) KeepOptimizing = true;
			}
			#endregion

			#region optimizations that don't have influence on other optimizations and must be executed at the beginning
			OptimizedProg.RemoveUnused();
			#endregion

			return OptimizedProg;
		}
	}
}
