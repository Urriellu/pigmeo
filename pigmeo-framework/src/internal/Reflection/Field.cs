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
					_FieldType = ParentAssembly.GetOwnerOfType(OriginalField.FieldType.FullName).Types[OriginalField.FieldType.FullName];
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