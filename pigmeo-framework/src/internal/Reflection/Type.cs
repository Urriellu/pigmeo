using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Type (class, struct, enum...)
	/// </summary>
	public class Type {
		/// <summary>
		/// This Type, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.TypeDefinition OriginalType;

		/// <summary>
		/// The Type's parent assembly. That's the assembly this Type is contained in
		/// </summary>
		public Assembly ParentAssembly;
		
		public Type(Assembly ParentAssembly, Mono.Cecil.TypeDefinition OriginalType) {
			this.ParentAssembly = ParentAssembly;
			this.OriginalType = OriginalType;
		}

		public MethodCollection Methods {
			get {
				if(_Methods == null) {
					ShowExternalInfo.InfoDebug("Retrieving methods of type {0} (Mono.Cecil->P.I.Reflection)", Name);
					_Methods = new MethodCollection(OriginalType.Methods.Count);
					foreach(Mono.Cecil.MethodDefinition Method in OriginalType.Methods) {
						_Methods.Add(new Method(this, Method));
					}
				}
				return _Methods;
			}
		}
		protected MethodCollection _Methods;

		public string Name {
			get {
				return OriginalType.Name;
			}
		}

		public string FullName {
			get {
				return OriginalType.FullName;
			}
		}

		public string Namespace {
			get {
				return OriginalType.Namespace;
			}
		}

		public bool IsAbstract {
			get {
				return OriginalType.IsAbstract;
			}
		}

		public bool IsClass {
			get {
				return OriginalType.IsClass;
			}
		}

		public bool IsEnum {
			get {
				return OriginalType.IsEnum;
			}
		}

		public bool IsSealed {
			get {
				return OriginalType.IsSealed;
			}
		}

		public bool IsPublic {
			get {
				return OriginalType.IsPublic;
			}
		}

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			if(IsAbstract) Output += "abstract ";
			if(IsSealed) Output += "sealed ";
			if(IsEnum) Output += "enum ";
			if(IsClass) Output += "class ";
			Output += FullName + " {\n";
			foreach(Method m in Methods) {/*Output += "\t" + m.ToString();*/
				foreach(string line in m.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "}\n\n";
			return Output;
		}
	}
}
