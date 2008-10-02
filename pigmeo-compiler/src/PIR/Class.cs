using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class Class:ReferenceType {
		public Class(PRefl.Type ReflectedType, bool IncludeMembers)
			: base(ReflectedType, IncludeMembers) {
			IsAbstract = ReflectedType.IsAbstract;
			IsSealed = ReflectedType.IsSealed;
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
				Output += "\t" + f.ToString() + "\n";
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
