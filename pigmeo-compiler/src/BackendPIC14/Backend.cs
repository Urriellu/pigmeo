using Mono.Cecil;
using System.Collections.Generic;

namespace Pigmeo.Compiler.BackendPIC14 {
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

			ShowInfo.InfoDebug("Optimizing CIL for PIC14 architecture");
			AssemblyDefinition OptimizedAssembly = OptimizeCIL(OriginalAssembly);
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 50;

			ShowInfo.InfoDebug("Adding the kernel to the assembly");
			AssemblyDefinition AssemblyWithKernel = AddKernel(OptimizedAssembly);
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 55;

			ShowInfo.InfoDebug("Compiling to assembly language");
			Asm AsmLangApp = CompileToAsm.Run(AssemblyWithKernel);
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 65;

			ShowInfo.InfoDebug("Optimizing the assembly language for the target architecture");
			Asm OptimizedAsmApp = OptimizeAsm(AsmLangApp);
			if(config.Internal.UI == UserInterface.WinForms) UI.UIs.WinFormsMainWindow.ProgBar.Value = 75;

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
