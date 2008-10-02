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

		/// <summary>
		/// Instantiates a new object that represents a .NET Type (class)
		/// </summary>
		/// <param name="ParentAssembly">.NET Assembly this Type is contained in</param>
		/// <param name="OriginalType">This Type, as represented by Mono.Cecil</param>
		public Type(Assembly ParentAssembly, Mono.Cecil.TypeDefinition OriginalType) {
			this.ParentAssembly = ParentAssembly;
			this.OriginalType = OriginalType;
		}

		public Type BaseType {
			get {
				if(_BaseType == null && OriginalType.BaseType != null) {
					_BaseType = ParentAssembly.GetAType(OriginalType.BaseType.FullName);
				}
				return _BaseType;
			}
		}
		protected Type _BaseType;

		/// <summary>
		/// Methods contained in this Type
		/// </summary>
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

		/// <summary>
		/// Fields/variables that belong to this type (static fields or instance-dependent)
		/// </summary>
		public FieldCollection Fields {
			get {
				if(_Fields == null) {
					ShowExternalInfo.InfoDebug("Retrieving fields of type {0} (Mono.Cecil->P.I.Reflection)", Name);
					_Fields = new FieldCollection(OriginalType.Fields.Count);
					foreach(Mono.Cecil.FieldDefinition CclField in OriginalType.Fields) {
						_Fields.Add(new Field(this, CclField));
					}
				}
				return _Fields;
			}
		}
		protected FieldCollection _Fields;

		/// <summary>
		/// Type's name, without parent namespaces
		/// </summary>
		public string Name {
			get {
				return OriginalType.Name;
			}
		}

		/// <summary>
		/// Type's fullname (including namespaces)
		/// </summary>
		public string FullName {
			get {
				return OriginalType.FullName;
			}
		}

		/// <summary>
		/// Type's full name, including assembly this type belongs to, namespaces and its own name. For example "[mscorlib]System.More.Namespaces.ClassName"
		/// </summary>
		public string FullNameWithAssembly {
			get {
				return string.Concat("[", ParentAssembly.Name, "]", FullName);
			}
		}

		/// <summary>
		/// Type's parent namespaces
		/// </summary>
		public string Namespace {
			get {
				return OriginalType.Namespace;
			}
		}

		/// <summary>
		/// Specifies that this type cannot be instantiated
		/// </summary>
		public bool IsAbstract {
			get {
				return OriginalType.IsAbstract;
			}
		}

		/// <summary>
		/// Specifies that this type is a class
		/// </summary>
		public bool IsClass {
			get {
				return OriginalType.IsClass;
			}
		}

		/// <summary>
		/// Specifies that this type is an enum
		/// </summary>
		public bool IsEnum {
			get {
				return OriginalType.IsEnum;
			}
		}

		/// <summary>
		/// Indicates if this type is a value-type or not
		/// </summary>
		public bool IsValueType {
			get {
				return OriginalType.IsValueType;
			}
		}

		/// <summary>
		/// Sealed types can't have derived types
		/// </summary>
		public bool IsSealed {
			get {
				return OriginalType.IsSealed;
			}
		}

		/// <summary>
		/// Specifies if this type is public
		/// </summary>
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
			Output += FullName + ":";
			if(BaseType == null) Output += "WithoutBaseType";
			else Output += BaseType.FullNameWithAssembly;
			Output += " {\n";
			foreach(Field f in Fields) {
				Output += "\t" + f.ToString() + "\n";
			}
			if(Fields.Count > 0) Output += "\n";
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
