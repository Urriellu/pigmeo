using Mono.Cecil;

namespace Pigmeo.Compiler.BackendPIC8bit {
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


			/*public byte Address {
				get{
					if(_Address==null){
						//_Address=;
					}
				}
			}
			private byte _Address;*/



			public CompiledStaticVariable(string prefix, string name) {
				this.prefix = prefix;
			}
		}
	}
}
