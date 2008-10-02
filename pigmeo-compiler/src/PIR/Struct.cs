using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Struct:ReferenceType {
		public Struct(PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ReflectedType, IncludeMembers) {
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
			Output += Name + " {\n";
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
