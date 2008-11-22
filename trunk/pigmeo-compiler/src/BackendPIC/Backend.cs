using System;
using Mono.Cecil;
using System.Collections.Generic;
using Pigmeo.Compiler.PIR.PIC;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;

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

		/// <summary>
		/// Runs the PIC Backend
		/// </summary>
		/// <returns>
		/// Compiled source code in assembly language. One line per index
		/// </returns>
		public static string[] Run(Program UserProgram) {
			ShowInfo.InfoDebug("Running the PIC Backend");

			OptimizeProgram(UserProgram);
			AsmCode UserProgamCode = ConvertToAsm(UserProgram);
			return UserProgamCode.Code;
		}

		/// <summary>
		/// Optimizes the PIR for the PIC Architecture
		/// </summary>
		protected static void OptimizeProgram(Program UserProgram) {
			#region optimizations that don't have influence on other optimizations
			//optimizations here
			#endregion

			#region optimizations that DO have influence on other optimizations
			bool KeepOptimizing = true;
			while(KeepOptimizing) {
				KeepOptimizing = false;
				//optimizations here
			}
			#endregion

			UserProgram.RemoveClassHierarchy();
		}

		protected static AsmCode ConvertToAsm(Program UserProgram) {
			AsmCode Code = new AsmCode();

			return Code;
		}
	}
}
