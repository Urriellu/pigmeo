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

		public Type this[string TypeName] {
			get {
				foreach(Type t in this) {
					if(t.Name == TypeName) return t;
				}
				throw new ArgumentException("The Type does not exist in the current collection");
			}
		}
	}
}
