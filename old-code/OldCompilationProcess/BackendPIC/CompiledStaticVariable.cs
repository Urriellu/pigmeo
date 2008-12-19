using Mono.Cecil;

namespace Pigmeo.Compiler.BackendPIC {
	public static partial class CompileToAsm {
		public class CompiledStaticVariable {
			private string prefix;
			private string name;

			/// <summary>
			/// Normalized name of the variable that will be used to call it in assembly language
			/// </summary>
			public string AsmName {
				get {
					if(_AsmName == null) {
						_AsmName = prefix + "_" + name;
					}
					return _AsmName;
				}
			}
			private string _AsmName;


			public CompiledStaticVariable(string prefix, string name) {
				this.prefix = prefix;
				this.name = name;
			}
		}
	}
}
