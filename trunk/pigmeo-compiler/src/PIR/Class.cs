﻿using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class Class:ReferenceType {
		protected Class(Program ParentProgram)
			: base(ParentProgram) {
		}

		protected Class(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ParentProgram, ReflectedType, IncludeMembers) {
			IsAbstract = ReflectedType.IsAbstract;
			IsSealed = ReflectedType.IsSealed;
		}

		public static Class NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			switch(ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					return new PIC.Class(ParentProgram, ReflectedType, IncludeMembers);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					return null;
			}
		}

		public static Class NewByArch(Program ParentProgram) {
			switch(ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					return new PIC.Class(ParentProgram);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					return null;
			}
		}

		public bool IsAbstract;

		public bool IsSealed;

		public override Type Clone() {
			return CloneClass();
		}

		public Class CloneClass() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			if(IsAbstract) Output += "abstract ";
			if(IsSealed) Output += "sealed ";
			Output += "class ";
			Output += Name;
			if(BaseType == null) Output += ":WithoutBaseType";
			else Output += ":" + BaseType.Name;
			Output += " {\n";
			foreach(Field f in Fields) {
				foreach(string line in f.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "\n";
			foreach(Method m in Methods) {
				foreach(string line in m.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "}\n";
			return Output;
		}
	}
}
