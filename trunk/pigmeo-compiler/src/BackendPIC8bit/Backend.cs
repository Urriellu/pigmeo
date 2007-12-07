using Mono.Cecil;
using System.Collections.Generic;

namespace Pigmeo.Compiler.BackendPIC8bit {
	/// <summary>
	/// Converts a .NET assembly to assembly language for a 8-bit Microchip PIC microcontroller
	/// </summary>
	public class Backend {
		/// <summary>
		/// Runs the backend/compiler
		/// </summary>
		/// <returns>
		/// Compiled source code in assembly language. Each value of the collection represents a line
		/// </returns>
		public static List<string> RunBrackend(AssemblyDefinition OriginalAssembly) {
			ShowInfo.InfoVerbose("Running the 8-bit PIC backend");

			AssemblyDefinition OptimizedAssembly = OptimizeCIL(OriginalAssembly);
			AssemblyDefinition AssemblyWithKernel = AddKernel(OptimizedAssembly);
			Asm AsmLangApp = CompileToAsm.Run(AssemblyWithKernel);
			Asm OptimizedAsmApp = OptimizeAsm(AsmLangApp);

			return OptimizedAsmApp.AsmCode;
		}

		private static AssemblyDefinition OptimizeCIL(AssemblyDefinition AssemblyToOptimize) {
			AssemblyDefinition OptimizedAssembly = AssemblyToOptimize;
			return OptimizedAssembly;
		}

		private static AssemblyDefinition AddKernel(AssemblyDefinition assembly) {
			AssemblyDefinition AssemblyWithKernel = assembly;
			return AssemblyWithKernel;
		}

		private static Asm OptimizeAsm(Asm asm) {
			Asm OptimizedAsm = new Asm(asm);
			return OptimizedAsm;
		}
	}
}
