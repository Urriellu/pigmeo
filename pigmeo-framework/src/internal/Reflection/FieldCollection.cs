using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public class FieldCollection:List<Field> {
		/// <summary>
		/// Creates a new collection of fields with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public FieldCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if a Field exists in this collection, by its given name
		/// </summary>
		/// <param name="FieldName">Name of the Field being looked for</param>
		public bool Contains(string FieldName) {
			ShowExternalInfo.InfoDebug("Checking whether {0} exists in this FieldCollection or not", FieldName);
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].Name == FieldName) return true;
			}
			return false;
		}

		/// <summary>
		/// Retrieves a Field from this collection, by its given name
		/// </summary>
		/// <param name="FieldName">Name of the Field being retrieved</param>
		public Field this[string FieldName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the field {0} from this FieldCollection", FieldName);
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].Name == FieldName) return this[i];
				}
				throw new ArgumentException("The Field does not exist");
			}
		}
	}
}
