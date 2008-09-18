﻿using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class MethodCollection:List<Method> {
		public bool Contains(string MethodName) {
			foreach(Method m in this) {
				if(m.Name == MethodName) return true;
			}
			return false;
		}
	}
}