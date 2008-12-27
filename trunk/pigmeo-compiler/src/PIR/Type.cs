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

		public abstract UInt32 Size { get; }
	}
}
