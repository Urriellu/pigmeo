using System;
using System.Collections.Generic;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public class MethodCollection:List<Method> {
		/// <summary>
		/// Gets a PIR Method from this collection whose original reflected method is the same as the given one
		/// </summary>
		public Method GetFromPRefl(PRefl.Method OriginalMethod) {
			for(int i=0;i<this.Count;i++){
				if(this[i].OriginalMethod == OriginalMethod) return this[i];
			}
			throw new ArgumentException("The method does not exist");
		}

		/// <summary>
		/// Finds out wheter there is a PIR Method in this collection that was derived from the given reflected method
		/// </summary>
		/// <param name="MethodBeingParsed"></param>
		/// <returns></returns>
		public bool AnyDerivesFrom(PRefl.Method MethodBeingParsed) {
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].OriginalMethod == MethodBeingParsed) return true;
			}
			return false;
		}
	}
}