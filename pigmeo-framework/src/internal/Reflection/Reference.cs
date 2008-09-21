using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.IO;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a .NET assembly referenced by another .NET assembly
	/// </summary>
	public class Reference {
		/// <summary>
		/// This reference, as represented by Mono.Cecil
		/// </summary>
		protected readonly AssemblyNameReference OriginalReference;

		/// <summary>
		/// Instantiates a new Reference object from its original reference as represented by Mono.Cecil
		/// </summary>
		/// <param name="OriginalReference">This reference, as represented by Mono.Cecil</param>
		public Reference(AssemblyNameReference OriginalReference) {
			this.OriginalReference = OriginalReference;
		}

		/// <summary>
		/// The Assembly (the object representation) of this Reference
		/// </summary>
		public Assembly Assembly {
			get {
				if(_Assembly == null) {
					_Assembly = Assembly.GetFromFullName(OriginalReference.FullName);
				}
				return _Assembly;
			}
		}
		protected Assembly _Assembly;

		/// <summary>
		/// The name of this Reference. This is just the assembly name, without extension nor any other kind of information
		/// </summary>
		public string Name {
			get {
				return OriginalReference.Name;
			}
		}

		/// <summary>
		/// Full name of this reference. This includes its name, version, culture and public key token
		/// </summary>
		public string FullName {
			get {
				return OriginalReference.FullName;
			}
		}

		/// <summary>
		/// Name of the .NET Assembly file this reference represents
		/// </summary>
		public string FileName {
			get {
				return Path.GetFileName(FullPath);
			}
		}

		/// <summary>
		/// Full path to the .NET Assembly file this reference represents
		/// </summary>
		public string FullPath {
			get {
				if(_FullPath == null) _FullPath = Assembly.ReflectedFile;
				return _FullPath;
			}
		}
		protected string _FullPath;

		public override int GetHashCode() {
			return base.GetHashCode();
		}

		public override bool Equals(object obj) {
			if(obj == null) return false;
			Reference R = obj as Reference;
			if(R == null) return false;
			return this.Equals(R);
		}

		public bool Equals(Reference R) {
			return R.FullName == this.FullName;
		}

		public static bool operator ==(Reference a, Reference b) {
			return a.FullName == b.FullName;
		}

		public static bool operator !=(Reference a, Reference b) {
			return a.FullName != b.FullName;
		}
	}
}
