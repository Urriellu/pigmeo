using System;
using System.Collections.Generic;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of Methods
	/// </summary>
	public class MethodCollection:List<Method> {
		/// <summary>
		/// Creates a new collection of methods with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public MethodCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if a Method exists in this collection, by its given name
		/// </summary>
		/// <param name="MethodName">Name of the Method being looked for</param>
		public bool Contains(string MethodName) {
			ShowExternalInfo.InfoDebug("Checking wheter {0} exists in this MethodCollection or not", MethodName);
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].Name == MethodName) return true;
			}
			return false;
		}

		public string[] Names {
			get {
				if(_Names == null) {
					_Names = new string[this.Count];
					for(int i = 0 ; i < this.Count ; i++) _Names[i] = this[i].Name;
				}
				return _Names;
			}
		}
		protected string[] _Names;

		/// <summary>
		/// Retrieves a Method from this collection, by its given name
		/// </summary>
		/// <param name="MethodName">Name of the method being retrieved</param>
		public Method this[string MethodName] {
			get {
				ShowExternalInfo.InfoDebug("Trying to retrieve the method {0} from this MethodCollection. Known methods: {1}", MethodName, Names.CommaSeparatedList());
				for(int i = 0 ; i < this.Count ; i++) {
					if(this[i].Name == MethodName) return this[i];
				}
				throw new ArgumentException("The method does not exist");
			}
		}
	}
}
