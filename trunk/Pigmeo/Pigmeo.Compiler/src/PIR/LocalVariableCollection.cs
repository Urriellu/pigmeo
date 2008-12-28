using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class LocalVariableCollection:List<LocalVariable> {
		public bool Contains(string LocalVariableName) {
			foreach(LocalVariable m in this) {
				if(m.Name == LocalVariableName) return true;
			}
			return false;
		}
	}
}