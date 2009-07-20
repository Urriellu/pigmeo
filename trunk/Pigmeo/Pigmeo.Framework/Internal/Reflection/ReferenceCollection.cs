using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Collections;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of references to .NET Assemblies
	/// </summary>
	public class ReferenceCollection:List<Reference> {
		public ReferenceCollection() {
		}

		/// <summary>
		/// Creates a new ReferenceCollection that contains the given references
		/// </summary>
		/// <param name="References"></param>
		public ReferenceCollection(IEnumerable<Reference> References) {
			this.AddRange(References);
		}

		/// <summary>
		/// Indicates if this collection contains a Reference with the given full name
		/// </summary>
		public bool ContainsFullName(string FullName) {
			foreach(Reference r in this) {
				if(r.FullName == FullName) return true;
			}
			return false;
		}

		/// <summary>
		/// Indicates if this collection contains a Reference with the given name
		/// </summary>
		public bool ContainsName(string Name) {
			foreach(Reference r in this) {
				if(r.Name == Name) return true;
			}
			return false;
		}

		/// <summary>
		/// Finds the assembly which contains the definition of type given its full name (including namespace)
		/// </summary>
		public Assembly GetOwnerOfType(string TypeFullName) {
			foreach(Reference r in this) {
				if(r.Assembly.Types.Contains(TypeFullName)) return r.Assembly;
			}
			throw new ReflectionException(string.Format("Type {0} not found in any of the references: {1}", TypeFullName, FullNames.CommaSeparatedList()));
		}

		/// <summary>
		/// List of referenced assemblies (only their names)
		/// </summary>
		public string[] Names {
			get {
				string[] _Names = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _Names[i] = this[i].Name;
				ShowExternalInfo.InfoDebug("Referenced libraries: {0}", _Names.CommaSeparatedList());
				return _Names;
			}
		}

		/// <summary>
		/// List of referenced assemblies (file names with extension)
		/// </summary>
		public string[] Files {
			get {
				string[] _Files = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _Files[i] = this[i].FileName;
				return _Files;
			}
		}

		/// <summary>
		/// List of referenced assemblies with full names (includes Name, Version, Culture and PublicKeyToken)
		/// </summary>
		public string[] FullNames {
			get {
				string[] _FullNames = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _FullNames[i] = this[i].FullName;
				return _FullNames;
			}
		}

		/// <summary>
		/// List of paths to the .NET Assemblies in this collection of references
		/// </summary>
		public string[] FullPaths {
			get {
				string[] _FullPaths = new string[this.Count];
				for(int i = 0 ; i < this.Count ; i++) _FullPaths[i] = this[i].FullPath;
				return _FullPaths;
			}
		}

		/// <summary>
		/// Gets a Reference given its full name
		/// </summary>
		public Reference this[string Name] {
			get {
				foreach(Reference r in this) {
					if(r.Name == Name) return r;
				}
				return null;
			}
		}

		/// <summary>
		/// Gets a comma-separated list of the names of references in this collection
		/// </summary>
		public override string ToString() {
			return Names.CommaSeparatedList();
		}
	}
}
