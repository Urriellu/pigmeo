using System;
using System.Collections.Generic;
using Pigmeo.Extensions;

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

		/// <summary>
		/// List of types (only their names)
		/// </summary>
		public string[] Names {
			get {
				string[] _Names = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _Names[i] = this[i].Name;
				ShowExternalInfo.InfoDebug("Types in collection: {0}", _Names.CommaSeparatedList());
				return _Names;
			}
		}

		/// <summary>
		/// List of types in collection with full names (including namespaces)
		/// </summary>
		public string[] FullNames {
			get {
				string[] _FullNames = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _FullNames[i] = this[i].FullName;
				return _FullNames;
			}
		}

		public Type this[string TypeFullName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the type {0} from this TypeCollection", TypeFullName);
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].FullName == TypeFullName || this[i].Name == TypeFullName) return this[i];
				}
				throw new ArgumentException(string.Format("The type {0} does not exist in this TypeCollection. Known types: {1}", TypeFullName, FullNames.CommaSeparatedList()));
			}
		}
	}
}
