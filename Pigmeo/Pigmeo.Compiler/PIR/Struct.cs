using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class Struct:ValueType {
		protected Struct(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}

		public static Struct NewByArch(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			switch(ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					return new PIC.Struct(ParentProgram, ReflectedType, IncludeMembers);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					return null;
			}
		}

		public override Type Clone() {
			return CloneStruct();
		}

		public Struct CloneStruct() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			Output += "struct ";
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
