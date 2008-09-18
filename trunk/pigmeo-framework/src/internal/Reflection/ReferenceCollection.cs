using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Collections;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.Reflection {
	public class ReferenceCollection:IEnumerable<Reference> {
		protected readonly Reference[] References;

		public ReferenceCollection(Reference[] References) {
			this.References = References;
		}

		/// <summary>
		/// List of referenced assemblies (only their names)
		/// </summary>
		public string[] Names {
			get {
				if(_Names == null) {
					_Names = new string[References.Length];
					for(int i = 0 ; i < References.Length ; i++) _Names[i] = References[i].Name;
					ShowExternalInfo.InfoDebug("Referenced libraries: {0}", _Names.CommaSeparatedList());
				}
				return _Names;
			}
		}
		protected static string[] _Names;

		/// <summary>
		/// List of referenced assemblies (file names with extension)
		/// </summary>
		public string[] Files {
			get {
				if(_Files == null) {
					_Files = new string[References.Length];
					for(int i = 0 ; i < References.Length ; i++) _Files[i] = References[i].FileName;
				}
				return _Files;
			}
		}
		protected static string[] _Files;

		/// <summary>
		/// List of referenced assemblies with full names (includes Name, Version, Culture and PublicKeyToken)
		/// </summary>
		public string[] FullNames {
			get {
				if(_FullNames == null) {
					_FullNames = new string[References.Length];
					for(int i = 0 ; i < References.Length ; i++) _FullNames[i] = References[i].FullName;
				}
				return _FullNames;
			}
		}
		protected static string[] _FullNames;

		public string[] FullPaths {
			get {
				if(_FullPaths == null) {
					_FullPaths = new string[References.Length];
					for(int i = 0 ; i < References.Length ; i++) _FullPaths[i] = References[i].FullPath;
				}
				return _FullPaths;
			}
		}
		protected static string[] _FullPaths;

		public IEnumerator<Reference> GetEnumerator() {
			for(int i = 0 ; i < References.Length ; i++) {
				yield return References[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public override string ToString() {
			string Output = Names.CommaSeparatedList();
			return Output;
		}
	}
}
