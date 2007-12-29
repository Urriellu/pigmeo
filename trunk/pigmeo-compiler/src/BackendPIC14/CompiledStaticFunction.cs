using Mono.Cecil;

namespace Pigmeo.Compiler.BackendPIC8bit {
	public static partial class CompileToAsm {
		public class CompiledStaticFunction {
			/// <summary>
			/// The original MethodDefinition of this function
			/// </summary>
			public readonly MethodDefinition OriginalMethod;

			/// <summary>
			/// Normalized name of the function that will be used to call it in assembly language
			/// </summary>
			public string AsmName {
				get {
					if(_AsmName == null) {
						if(config.Internal.AssemblyToCompile.EntryPoint == OriginalMethod)
							_AsmName = "EntryPoint";
						else {
							_AsmName = OriginalMethod.Name.Replace('.', '_');
						}
					}
					return _AsmName;
				}
			}
			private string _AsmName;

			/// <summary>
			/// Gets the compiled code of this funcion
			/// </summary>
			/// <remarks>
			/// The compilation is automatic
			/// </remarks>
			public Asm AsmCode {
				get {
					if(_AsmCode == null) {
						//compile the method to assembly language
						ShowInfo.InfoDebug("Compiling method " + OriginalMethod.Name + " as " + AsmName);
						_AsmCode = new Asm();
						_AsmCode.Instructions.Add(new Label(AsmName, ""));
						_AsmCode.Instructions.Add(new ADDWF("test", "PORTu", Destination.F, ""));
					}
					return _AsmCode;
				}
			}
			private Asm _AsmCode;


			public CompiledStaticFunction(MethodDefinition method) {
				OriginalMethod = method;
			}
		}
	}
}
