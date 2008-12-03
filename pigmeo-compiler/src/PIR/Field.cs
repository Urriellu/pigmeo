using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Extensions;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public abstract class Field:TypeMember {
		protected Field(Program ParentProgram, PRefl.Field ReflectedField) {
			ShowInfo.InfoDebug("Converting reflected Field {0} to PIR", ReflectedField.FullNameWithAssembly);
			this.ParentProgram = ParentProgram;
			this.ParentType = ParentProgram.Types[ReflectedField.ParentType.FullName];
			this.FieldType = ParentProgram.Types[ReflectedField.FieldType.FullName];
			Name = ReflectedField.Name;
			IsPublic = ReflectedField.IsPublic;
			IsStatic = ReflectedField.IsStatic;

			foreach(PRefl.CustomAttr cattr in ReflectedField.CustomAttributes) {
				#region find AsmName
				if(cattr.CAttrType.FullName == "Pigmeo.AsmName") {
					try {
						if(cattr.Parameters.Count == 1) {
							_AsmName = ((string)cattr.Parameters[0].Value);
						} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Parsing CustomAttribute Pigmeo.AsmName but constructor is unknown");
					} catch(InvalidCastException) {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Parsing CustomAttribute Pigmeo.AsmName but constructor is unknown (invalid cast)");
					}
				}
				#endregion
			}
		}

		public static Field NewByArch(Program ParentProgram, PRefl.Field ReflectedField) {
			switch(ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					return new PIC.Field(ParentProgram, ReflectedField);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					return null;
			}
		}

		public Type FieldType;

		public bool IsPublic;
		public bool IsStatic;

		public override string ToString() {
			string[] attrs = ToStringAttributes();
			string Output = "";
			if(attrs.Length > 0) Output += "[" + attrs.CommaSeparatedList() + "]" + "\n";
			if(IsPublic) Output += "public ";
			if(IsStatic) Output += "static ";
			Output += FieldType.Name + " " + Name;
			return Output;
		}

		public string ToStringTypeAndName() {
			return FieldType.Name + " " + Name;
		}

		public virtual string[] ToStringAttributes() {
			List<string> attrs = new List<string>();
			attrs.Add("AsmName(\"" + AsmName + "\")");
			return attrs.ToArray();
		}
	}
}
