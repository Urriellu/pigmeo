﻿using Mono.Cecil;
using System.Collections.Generic;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;

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
			ShowInfo.InfoVerbose(i18n.str(112));

			ShowInfo.InfoDebug("Optimizing CIL for PIC14 architecture");
			AssemblyDefinition OptimizedAssembly = OptimizeCIL(OriginalAssembly);
			GlobalShares.CompilationProgress = 50;

			ShowInfo.InfoDebug("Adding the kernel to the assembly");
			AssemblyDefinition AssemblyWithKernel = AddKernel(OptimizedAssembly);
			GlobalShares.CompilationProgress = 55;

			ShowInfo.InfoDebug("Compiling to assembly language");
			Asm AsmLangApp = CompileToAsm.Run(AssemblyWithKernel);
			GlobalShares.CompilationProgress = 65;

			ShowInfo.InfoDebug("Optimizing the assembly language for the target architecture");
			Asm OptimizedAsmApp = OptimizeAsm(AsmLangApp);
			GlobalShares.CompilationProgress = 75;

			return OptimizedAsmApp.AsmCode;
		}

		[PigmeoToDo("Unimplemented")]
		private static AssemblyDefinition OptimizeCIL(AssemblyDefinition AssemblyToOptimize) {
			AssemblyDefinition OptimizedAssembly = AssemblyToOptimize;
			return OptimizedAssembly;
		}

		[PigmeoToDo("Unimplemented")]
		private static AssemblyDefinition AddKernel(AssemblyDefinition assembly) {
			AssemblyDefinition AssemblyWithKernel = assembly;
			return AssemblyWithKernel;
		}

		[PigmeoToDo("Unimplemented")]
		private static Asm OptimizeAsm(Asm asm) {
			Asm OptimizedAsm = new Asm(asm);
			return OptimizedAsm;
		}
	}
}