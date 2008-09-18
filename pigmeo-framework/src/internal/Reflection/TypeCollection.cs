using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public class TypeCollection:List<Type> {
		public TypeCollection(int Capacity) : base(Capacity) { }
		
		/// <summary>
		/// Determines wheter a Type exists inside this collection
		/// </summary>
		public bool Contains(string TypeName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this TypeCollection or not", TypeName);
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].FullName == TypeName || this[i].Name == TypeName) return true;
			}
			return false;
		}

		public Type this[string TypeName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the type {0} from this TypeCollection", TypeName);
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].FullName == TypeName || this[i].Name == TypeName) return this[i];
				}
				throw new ArgumentException("The type does not exist");
			}
		}
	}
}
