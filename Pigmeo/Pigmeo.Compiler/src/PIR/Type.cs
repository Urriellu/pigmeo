using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class Type {
		public Program ParentProgram;

		/// <summary>
		/// The Type's name. Note that in PIR there is no distinction between Name and FullName, because the Namespace is now part of its name
		/// </summary>
		public string Name;

		public Type BaseType;
		public MethodCollection Methods = new MethodCollection();
		public FieldCollection Fields = new FieldCollection();

		public bool IsPublic;

		/// <summary>
		/// Clones this object
		/// </summary>
		public abstract Type Clone();

		protected Type(Program ParentProgram) {
			this.ParentProgram = ParentProgram;
		}

		/// <summary>
		/// Generates a PIR of a Type from a reflected type
		/// </summary>
		protected Type(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			this.ParentProgram = ParentProgram;
			Name = ReflectedType.FullName;
			IsPublic = ReflectedType.IsPublic;
		}

		public UInt32 Size {
			get {
				if(IsUInt8 || IsInt8) return 1;
				else if(IsUInt16 || IsInt16) return 2;
				else if(IsUInt32 || IsInt32) return 4;
				else if(IsUInt64 || IsInt64) return 8;
				else {
					UInt32 s = 0;
					foreach(Field f in Fields) {
						s += f.Size;
					}
					return s;
				}
			}
		}

		public bool IsUInt8 {
			get {
				return Name == "System.Byte";
			}
		}

		public bool IsInt8 {
			get {
				return Name == "System.SByte";
			}
		}

		public bool IsUInt16 {
			get {
				return Name == "System.UInt16";
			}
		}

		public bool IsInt16 {
			get {
				return Name == "System.Int16";
			}
		}

		public bool IsUInt32 {
			get {
				return Name == "System.UInt32";
			}
		}

		public bool IsInt32 {
			get {
				return Name == "System.Int32";
			}
		}

		public bool IsUInt64 {
			get {
				return Name == "System.UInt64";
			}
		}

		public bool IsInt64 {
			get {
				return Name == "System.Int64";
			}
		}
	}
}
