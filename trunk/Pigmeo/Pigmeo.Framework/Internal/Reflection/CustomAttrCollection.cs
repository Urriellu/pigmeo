using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of Custom Attributes
	/// </summary>
	public class CustomAttrCollection:List<CustomAttr> {
		/// <summary>
		/// Creates a new collection of Custom Attributes from a Mono.Cecil.CustomAttribubuteCollection
		/// </summary>
		public CustomAttrCollection(Assembly ParentAssembly, IAttributable AssignedTo, CustomAttributeCollection OriginalCAttrCollection) : base(OriginalCAttrCollection.Count) {
			for(UInt16 i = 0 ; i < (UInt16)OriginalCAttrCollection.Count ; i++) {
				Add(new CustomAttr(ParentAssembly, AssignedTo, OriginalCAttrCollection[i]));
			}
		}

		/// <summary>
		/// Represent this Custom Attribute Collection as a string
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			string ret = "[";
			for(int i = 0 ; i < Count ; i++) {
				ret += this[i].ToString();
				if(i != Count - 1) ret += ", ";
			}
			ret += "]";
			return ret;
		}
	}
}
