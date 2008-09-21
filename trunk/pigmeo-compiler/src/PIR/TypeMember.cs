using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public abstract class TypeMember {
		/// <summary>
		/// Type (enum, class...) this TypeMember (field, method...) belongs to
		/// </summary>
		public Type ParentType;

		public string Name;

		public string FullName {
			get {
				return ParentType.Name + "::" + Name;
			}
		}
	}
}
