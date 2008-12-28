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

		public Field this[string FieldName] {
			get {
				foreach(Field f in this) {
					if(f.Name == FieldName) return f;
				}
				throw new ArgumentException("The Field does not exist in the current collection");
			}
		}
	}
}