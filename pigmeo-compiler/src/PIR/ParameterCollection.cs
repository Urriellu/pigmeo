using System;
using System.Collections.Generic;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.PIR {
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
		/// <param name="ParameterName">Name of the Parameter being checked</param>
		public bool Contains(string ParameterName) {
			for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
				if(this[i].Name == ParameterName) return true;
			}
			return false;
		}

		public string[] ParamNames {
			get {
				string[] names = new string[Count];
				for(int i = 0 ; i < Count ; i++) names[i] = this[(UInt16)i].Name;
				return names;
			}
		}

		/// <summary>
		/// Returns a Parameter given its name
		/// </summary>
		/// <param name="ParameterName">Name of the local variable being retrieved</param>
		public Parameter this[string ParameterName] {
			get {
				for(UInt16 i = 0 ; i < (UInt16)this.Count ; i++) {
					if(this[i].Name == ParameterName) return this[i];
				}
				throw new ArgumentException("The Parameter does not exist");
			}
		}

		public override string ToString() {
			string[] p = new string[Count];
			for(int i = 0 ; i < Count ; i++) p[i] = this[(UInt16)i].ToString();
			return p.CommaSeparatedList();
		}
	}
}
