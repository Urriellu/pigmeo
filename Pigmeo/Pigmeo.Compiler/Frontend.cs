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
			GlobalShares.Stage = CompilerStage.Frontend;

			ShowInfo.NewOutMsgBlock("Reflecting assembly");
			PRefl.Assembly ReflectedAssembly = PRefl.Assembly.GetFromFile(CompilingFile);

			ShowInfo.NewOutMsgBlock("Reflected assembly");
			ShowInfo.InfoDebugDecompile("Reflected assembly", ReflectedAssembly);
			if(config.Internal.DebugExampleVS) UIs.DebugVS.SetReflectedAssembly(ReflectedAssembly);

			ShowInfo.NewOutMsgBlock("PIRefl->PIR");
			Program PlainProgram = Program.GetFromCIL(ReflectedAssembly);
			ShowInfo.EndOutMsgBlock();

			ShowInfo.InfoVerbose(i18n.str("CompilingApp", PlainProgram.Name, PlainProgram.Target.Architecture, PlainProgram.Target.Family, PlainProgram.Target.Branch));

			ShowInfo.NewOutMsgBlock("Original assembly converted to PIR");
			ShowInfo.InfoDebugDecompile("Original assembly converted to PIR", PlainProgram);
			ShowInfo.EndOutMsgBlock();

			//File.WriteAllText(PlainProgram.Name + "-disassembled-beforeopt.pir", PlainProgram.ToString());
			
			Program OptimizedProgram = OptimizeProgram(PlainProgram);

			ShowInfo.NewOutMsgBlock("PIR optimized");
			ShowInfo.InfoDebugDecompile("PIR optimized", OptimizedProgram);
			ShowInfo.EndOutMsgBlock();

			//File.WriteAllText(OptimizedProgram.Name + "-disassembled-optimized.pir", OptimizedProgram.ToString());

			ShowInfo.InfoVerbose("The final program contains {0} types ({1} classes, {2} structs), {3} methods", OptimizedProgram.Types.Count, OptimizedProgram.ClassCount, OptimizedProgram.StructCount, OptimizedProgram.MethodCount);
			
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
			//OptimizedProg.AvoidTOSS();
			#endregion

			#region optimizations that DO have influence on other optimizations
			bool KeepOptimizing = true;
			while(KeepOptimizing) {
				KeepOptimizing = false;
				if(OptimizedProg.AvoidTOSS()) KeepOptimizing = true;
				OptimizedProg.FindSingleCallInlinizable();
				OptimizedProg.FindShortInlinizableMethods();
				if(OptimizedProg.InLineAll()) KeepOptimizing = true;
				if(OptimizedProg.ImplementInternally()) KeepOptimizing = true;
				if(OptimizedProg.RemoveDumbTempVars()) KeepOptimizing = true;
				if(OptimizedProg.RemoveDeadLV()) KeepOptimizing = true;
				if(OptimizedProg.RemoveJumpToNext()) KeepOptimizing = true;
				if(OptimizedProg.Constantize()) KeepOptimizing = true;
			}
			#endregion

			#region optimizations that don't have influence on other optimizations and must be executed at the beginning
			OptimizedProg.RemoveUnused();
			#endregion

			return OptimizedProg;
		}
	}
}
