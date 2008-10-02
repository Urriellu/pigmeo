﻿using System;
using System.Collections.Generic;
using System.IO;
using Pigmeo.Internal;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler {
	/// <summary>
	/// The Frontend generates Pigmeo Intermediate Representation of a .NET executable, including all it needs 
	/// </summary>
	public static partial class Frontend {
		private static List<string> MethodsToParse = new List<string>(5);

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

		private static Program OptimizeProgram(Program OriginalProgram) {
			Program OptimizedProg = OriginalProgram;
			//OptimizedProg.Optimize.RemoveUnused();
			//OptimizedProg.Optimize.ConstantizeFullMethods();
			return OptimizedProg;
		}
	}
}
