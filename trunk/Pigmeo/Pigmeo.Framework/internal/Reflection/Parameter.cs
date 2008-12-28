using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET method parameter
	/// </summary>
	public abstract class Parameter {
		/// <summary>
		/// Type of this parameter
		/// </summary>
		public Type ParamType { get; protected set; }

		/// <summary>
		/// .NET Assembly this parameter is contained in
		/// </summary>
		public Assembly ParentAssembly {
			get {
				return ParentMethod.ParentAssembly;
			}
		}

		/// <summary>
		/// The Parameter's parent Method. That's the Method this Parameter belongs to
		/// </summary>
		public Method ParentMethod { get; protected set; }

		/// <summary>
		/// Name of this Parameter
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// Index of this Parameter in the list of its parent method parameters
		/// </summary>
		public UInt16 Index { get; protected set; }

		public override string ToString() {
			return string.Concat(ParamType.FullNameWithAssembly, " ", Name);
		}
	}
}