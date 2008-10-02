using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a reference type
	/// </summary>
	public abstract class ReferenceType:Type {
		/// <summary>
		/// Generates a PIR of a ReferenceType from a reflected type
		/// </summary>
		public ReferenceType(PRefl.Type ReflectedType, bool IncludeMembers):base(ReflectedType, IncludeMembers) {
		}
	}
}