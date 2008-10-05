using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of Method Parameters
	/// </summary>
	public class ParameterCollection:Dictionary<UInt16,Parameter> {
		/// <summary>
		/// Creates a new collection of parameters with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public ParameterCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if a parameter exists in this collection
		/// </summary>
		/// <param name="VariableName">Name of the Parameter being checked</param>
		public bool Contains(string ParameterName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this ParameterCollection or not", ParameterName);
			for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
				if(this[i].Name == ParameterName) return true;
			}
			return false;
		}

		/// <summary>
		/// Returns a Parameter given its name
		/// </summary>
		/// <param name="ParameterName">Name of the local variable being retrieved</param>
		public Parameter this[string ParameterName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the parameter {0} from this ParameterCollection", ParameterName);
				for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
					if(this[i].Name == ParameterName) return this[i];
				}
				throw new ArgumentException("The Parameter does not exist");
			}
		}
	}
}
