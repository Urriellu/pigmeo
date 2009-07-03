using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Field
	/// </summary>
	public class Field:IAttributable {
		/// <summary>
		/// This Field, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.FieldDefinition OriginalField;

		/// <summary>
		/// Type of this field
		/// </summary>
		public Type FieldType {
			get {
				if(_FieldType == null) {
					ShowExternalInfo.InfoDebug("Getting the type of Field {0}", FullNameWithAssembly);
					string FieldTypeName = OriginalField.FieldType.FullName;
					if(FieldTypeName.Contains("modreq")) {
						ShowExternalInfo.InfoDebug("This field type has a modreq...");
						int FirstPar = FieldTypeName.IndexOf('(');
						int L = FieldTypeName.Length-FirstPar-2;
						string modreq = FieldTypeName.Substring(FirstPar+1, L);
						ShowExternalInfo.InfoDebug("...of type {0}", modreq);
						switch(modreq) {
							case "System.Runtime.CompilerServices.IsVolatile":
								ShowExternalInfo.InfoDebug("{0} is volatile", FullNameWithAssembly);
								IsVolatile = true;
								break;
							default:
								throw new Exception("Unknown modreq type: " + modreq);
						}
						FieldTypeName = FieldTypeName.Split(' ')[0];
					}
					_FieldType = ParentAssembly.GetOwnerOfType(FieldTypeName).Types[FieldTypeName];
				}
				return _FieldType;
			}
		}
		protected Type _FieldType;

		/// <summary>
		/// .NET Assembly this Method is contained in
		/// </summary>
		public Assembly ParentAssembly {
			get {
				return ParentType.ParentAssembly;
			}
		}

		/// <summary>
		/// The Field's parent type. That's the Type this Field is contained in
		/// </summary>
		public readonly Type ParentType;

		/// <summary>
		/// Creates a new object that represents a Field
		/// </summary>
		/// <param name="ParentType">Type (class, interface...) this Field belongs to</param>
		/// <param name="OriginalField">This Field, as represented by Mono.Cecil</param>
		public Field(Type ParentType, Mono.Cecil.FieldDefinition OriginalField) {
			this.ParentType = ParentType;
			this.OriginalField = OriginalField;
		}

		/// <summary>
		/// Field's name
		/// </summary>
		public string Name {
			get {
				return OriginalField.Name;
			}
		}

		/// <summary>
		/// Field's full name, including namespaces, parent type and its own name. For example "System.Some.More.Namespaces.ParentClass::ThisField"
		/// </summary>
		public string FullName {
			get {
				return ParentType.FullName + "::" + Name;
			}
		}

		/// <summary>
		/// Field's full name, including assembly this type belongs to, namespaces, parent type and its own name. For example "[mscorlib]System.More.Namespaces.ClassName::ThisField"
		/// </summary>
		public string FullNameWithAssembly {
			get {
				return string.Concat(ParentType.FullNameWithAssembly, "::", Name);
			}
		}


		public bool IsPublic {
			get {
				return OriginalField.IsPublic;
			}
		}

		public bool IsPrivate {
			get {
				return OriginalField.IsPrivate;
			}
		}

		public bool IsStatic {
			get {
				return OriginalField.IsStatic;
			}
		}

		public bool IsVolatile { get; protected set; }

		public CustomAttrCollection CustomAttributes {
			get {
				if(_CustomAttributes == null) _CustomAttributes = new CustomAttrCollection(ParentAssembly, this, OriginalField.CustomAttributes);
				return _CustomAttributes;
			}
		}
		protected CustomAttrCollection _CustomAttributes;

		public override string ToString() {
			string Output = "";
			if(CustomAttributes.Count > 0) Output += CustomAttributes.ToString() + "\n";
			if(IsPublic) Output += "public ";
			if(IsPrivate) Output += "private ";
			if(IsStatic) Output += "static ";
			Output += FieldType.FullNameWithAssembly + " ";
			Output += Name;
			return Output;
		}
	}
}