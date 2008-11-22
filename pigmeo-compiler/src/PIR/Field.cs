using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public abstract class Field:TypeMember {
		/*public Field(Program ParentProgram, PRefl.Field ReflectedField) {
			ShowInfo.InfoDebug("Converting reflected Field {0} to PIR", ReflectedField.FullNameWithAssembly);
			this.ParentProgram = ParentProgram;
			this.ParentType = ParentProgram.Types[ReflectedField.ParentType.FullName];
			this.FieldType = ParentProgram.Types[ReflectedField.FieldType.FullName];
			Name = ReflectedField.Name;
			IsPublic = ReflectedField.IsPublic;
			IsStatic = ReflectedField.IsStatic;
		}*/

		public static Field NewByArch(Program ParentProgram, PRefl.Field ReflectedField) {
			ShowInfo.InfoDebug("Converting reflected Field {0} to PIR", ReflectedField.FullNameWithAssembly);
			Field NewField = null;
			switch(ParentProgram.TargetArch) {
				case Architecture.PIC:
					NewField = new PIC.Field(ReflectedField);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					break;
			}
			NewField.ParentProgram = ParentProgram;
			NewField.ParentType = ParentProgram.Types[ReflectedField.ParentType.FullName];
			NewField.FieldType = ParentProgram.Types[ReflectedField.FieldType.FullName];
			NewField.Name = ReflectedField.Name;
			NewField.IsPublic = ReflectedField.IsPublic;
			NewField.IsStatic = ReflectedField.IsStatic;
			return NewField;
		}

		public Type FieldType;

		public bool IsPublic;
		public bool IsStatic;

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			if(IsStatic) Output += "static ";
			Output += FieldType.Name + " " + Name;
			return Output;
		}

		public string ToStringTypeAndName() {
			return FieldType.Name + " " + Name;
		}
	}
}
