using System;
using System.Collections.Generic;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.PIR {
	public class TypeCollection:List<Type> {
		public bool Contains(string TypeName) {
			foreach(Type t in this) {
				if(t.Name == TypeName) return true;
			}
			return false;
		}

		public string[] TypesNames {
			get {
				string[] names = new string[Count];
				for(int i = 0 ; i < Count ; i++) names[i] = this[i].Name;
				return names;
			}
		}

		public Type this[string TypeName] {
			get {
				foreach(Type t in this) {
					if(t.Name == TypeName) return t;
				}
				throw new ArgumentException(string.Format("The Type \"{0}\" does not exist in the current collection. Known types: {1}", TypeName, TypesNames.CommaSeparatedList()));
			}
		}
	}
}
