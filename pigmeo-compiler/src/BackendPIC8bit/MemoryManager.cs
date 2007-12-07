using System.Collections.Generic;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.BackendPIC8bit {
	public static partial class CompileToAsm {
		public static class MemoryManager {
			public static Dictionary<RegisterAddress_PIC8bit,CompiledStaticVariable> StaticVariables = new Dictionary<RegisterAddress_PIC8bit,CompiledStaticVariable>();

		}
	}
}
