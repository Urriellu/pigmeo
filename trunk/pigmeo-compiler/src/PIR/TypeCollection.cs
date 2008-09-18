using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class TypeCollection:List<Type> {
		public bool Contains(string TypeName) {
			foreach(Type t in this) {
				if(t.Name == TypeName) return true;
			}
			return false;
		}
	}
}
