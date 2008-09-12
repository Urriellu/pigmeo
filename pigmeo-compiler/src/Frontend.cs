using System;
using System.Collections.Generic;
using System.IO;
using Pigmeo.Compiler.PIR;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler {
	public static partial class Frontend {
		private static List<string> MethodsToParse = new List<string>(5);
		private static PRefl.Assembly ReflectedAssembly = new PRefl.Assembly(config.Internal.UserApp);
		private static Program PlainProgram = new Program();

		public static Program Run(string file) {
			ShowInfo.InfoDebug("Running the Frontend");

			//some tests
			foreach(string Ref in ReflectedAssembly.References.Names) Console.WriteLine(Ref);
			foreach(string Ref in ReflectedAssembly.References.Files) Console.WriteLine(Ref);
			foreach(string Ref in ReflectedAssembly.References.FullNames) Console.WriteLine(Ref);
			foreach(string Ref in ReflectedAssembly.References.FullPaths) Console.WriteLine(Ref);
			Console.WriteLine(PRefl.Assembly.IsAssembly("PigmeoTestCS.pdb"));
			Console.WriteLine(PRefl.Assembly.IsAssembly("PigmeoTestCS.exe"));
			

			return null;
		}
	}
}
