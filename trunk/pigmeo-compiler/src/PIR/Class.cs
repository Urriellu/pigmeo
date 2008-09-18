using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class Class:Type {
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
			Output += Name + " {\n";
			foreach(Method m in Methods) {
				foreach(string line in m.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "}\n\n";
			return Output;
		}
	}
}
