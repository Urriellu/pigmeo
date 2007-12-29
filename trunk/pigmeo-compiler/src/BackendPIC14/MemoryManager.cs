using System.Collections.Generic;
using Pigmeo.Internal.PIC14;

namespace Pigmeo.Compiler.BackendPIC14 {
	public static partial class CompileToAsm {
		public static class MemoryManager {
			//public static Dictionary<RegisterAddress,CompiledStaticVariable> StaticVariables = new Dictionary<RegisterAddress,CompiledStaticVariable>();
			public static Dictionary<RegisterAddress, string> StaticVariables = new Dictionary<RegisterAddress, string>();
		}
	}
}
