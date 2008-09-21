using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Field
	/// </summary>
	public class Field {
		/// <summary>
		/// This Field, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.FieldDefinition OriginalField;

		/// <summary>
		/// Type of this field
		/// </summary>
		public readonly Type VariableType;

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
			VariableType = ParentAssembly.GetOwnerOfType(OriginalField.FieldType.FullName).Types[OriginalField.FieldType.FullName];
			ShowExternalInfo.InfoDebug("New class field {0} of type {1} in type {2}", Name, VariableType.FullNameWithAssembly, ParentType.FullNameWithAssembly);
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
				return string.Concat(ParentType.FullNameWithAssembly, FullName);
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

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			if(IsPrivate) Output += "private ";
			if(IsStatic) Output += "static ";
			Output += VariableType.FullNameWithAssembly + " ";
			Output += Name;
			return Output;
		}
	}
}