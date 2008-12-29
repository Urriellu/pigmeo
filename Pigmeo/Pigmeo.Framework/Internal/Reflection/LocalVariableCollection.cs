using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of Method Local Variables
	/// </summary>
	public class LocalVariableCollection:Dictionary<UInt16,LocalVariable> {
		/// <summary>
		/// Creates a new collection of local variables with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public LocalVariableCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if a variable exists in this collection
		/// </summary>
		/// <param name="VariableName">Name of the local variable being checked</param>
		public bool Contains(string VariableName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this LocalVariableCollection or not", VariableName);
			for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
				if(this[i].Name == VariableName) return true;
			}
			return false;
		}

		/// <summary>
		/// Returns a local variable given its name
		/// </summary>
		/// <param name="LocalVariableName">Name of the local variable being retrieved</param>
		public LocalVariable this[string LocalVariableName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the local variable {0} from this LocalVariableCollection", LocalVariableName);
				for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
					if(this[i].Name == LocalVariableName) return this[i];
				}
				throw new ArgumentException("The LocalVariable does not exist");
			}
		}
	}
}
