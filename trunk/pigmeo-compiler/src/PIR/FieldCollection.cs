using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class FieldCollection:List<Field> {
		public bool Contains(string FieldName) {
			foreach(Field m in this) {
				if(m.Name == FieldName) return true;
			}
			return false;
		}
	}
}