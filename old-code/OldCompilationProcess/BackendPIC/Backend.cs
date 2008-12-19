using System;
using Mono.Cecil;
using System.Collections.Generic;
using Pigmeo;
using Pigmeo.Compiler.PIR.PIC;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.BackendPIC {
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
		[Obsolete("Use the new compilation process. Call BackendPIC.Backend.Run() instead")]
		public static List<string> RunBrackend(AssemblyDefinition OriginalAssembly) {
			ShowInfo.InfoDebug("Running the PIC backend");

			AssemblyDefinition OptimizedAssembly = OptimizeCIL(OriginalAssembly);
			GlobalShares.CompilationProgress = 50;

			AssemblyDefinition AssemblyWithKernel = AddKernel(OptimizedAssembly);
			GlobalShares.CompilationProgress = 55;

			Asm AsmLangApp = CompileToAsm.Run(AssemblyWithKernel);
			GlobalShares.CompilationProgress = 65;

			Asm OptimizedAsmApp = OptimizeAsm(AsmLangApp);
			GlobalShares.CompilationProgress = 75;

			return OptimizedAsmApp.AsmCode;
		}

		[PigmeoToDo("Unimplemented"), Obsolete("Use the new compilation process")]
		private static AssemblyDefinition OptimizeCIL(AssemblyDefinition AssemblyToOptimize) {
			ShowInfo.InfoDebug("Optimizing CIL for PIC architecture");

			AssemblyDefinition OptimizedAssembly = AssemblyToOptimize;
			return OptimizedAssembly;
		}

		[PigmeoToDo("Unimplemented"), Obsolete("Use the new compilation process")]
		private static AssemblyDefinition AddKernel(AssemblyDefinition assembly) {
			ShowInfo.InfoDebug("Adding the kernel to the assembly");

			AssemblyDefinition AssemblyWithKernel = assembly;
			return AssemblyWithKernel;
		}

		[PigmeoToDo("Unimplemented"), Obsolete("Use the new compilation process")]
		private static Asm OptimizeAsm(Asm asm) {
			ShowInfo.InfoDebug("Optimizing the assembly language for the PIC architecture");

			Asm OptimizedAsm = new Asm(asm);
			return OptimizedAsm;
		}
	}
}
