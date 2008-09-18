using System;

namespace Pigmeo.Compiler.PIR {
	public abstract class Type {
		/// <summary>
		/// The Type's name. Note that in PIR there is no distinction between Name and FullName, because the Namespace is now part of its name
		/// </summary>
		public string Name;

		public MethodCollection Methods = new MethodCollection();

		public bool IsPublic;

		public bool IsAbstract;

		public bool IsSealed;

		/// <summary>
		/// Clones this object
		/// </summary>
		public abstract Type Clone();
	}
}
