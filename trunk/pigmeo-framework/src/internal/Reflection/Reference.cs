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
		protected readonly AssemblyNameReference CclRef;

		public Reference(AssemblyNameReference OriginalReference) {
			CclRef = OriginalReference;
		}

		/// <summary>
		/// The Assembly (the object representation) of this Reference
		/// </summary>
		public Assembly Assembly {
			get {
				if(_Assembly == null) {
					_Assembly = new Assembly(FullPath);
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
				return CclRef.Name;
			}
		}

		/// <summary>
		/// Full name of this reference. This includes its name, version, culture and public key token
		/// </summary>
		public string FullName {
			get {
				return CclRef.FullName;
			}
		}

		public string FileName {
			get {
				return Path.GetFileName(FullPath);
			}
		}

		public string FullPath {
			get {
				if(_FullPath == null) {
					try {
						_FullPath = System.Reflection.Assembly.Load(FullName).Location;
					} catch {
						//the following is done because I didn't manage to load an assembly located in the working directory (if it is the same as the directory where the original assembly (UserApp) is placed), even when it is supposed to work with Assembly.Load()
						try {
							_FullPath = System.Reflection.Assembly.LoadFile(Name + ".dll").Location;
						} catch {
							throw new ReflectionException("Assembly not found: " + Name);
						}
					}
				}
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
