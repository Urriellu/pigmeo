﻿using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class ComparisonOperation:Operation {
		protected ComparisonOperation(Method ParentMethod)
			: base(ParentMethod) {
		}

		public override string ToString() {
			string ret = Label + ": " + Result + " " + AssignmentSign + " ";
			for(int i = 0 ; i < Arguments.Length ; i++) {
				ret += Arguments[i];
				if(i != Arguments.Length - 1) ret += " " + Operator + " ";
			}
			return ret;
		}
	}
}
