using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public class MethodCollection:List<Method> {
		public MethodCollection(int Capacity) : base(Capacity) { }

		public bool Contains(string MethodName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this MethodCollection or not", MethodName);
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].Name == MethodName) return true;
			}
			return false;
		}

		public Method this[string MethodName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the method {0} from this MethodCollection", MethodName);
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].Name == MethodName) return this[i];
				}
				throw new ArgumentException("The method does not exist");
			}
		}
	}
}
