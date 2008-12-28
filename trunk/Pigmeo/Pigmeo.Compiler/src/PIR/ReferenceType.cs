using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a reference type
	/// </summary>
	public abstract class ReferenceType:Type {
		protected ReferenceType(Program ParentProgram):base(ParentProgram) {
		}

		/// <summary>
		/// Generates a PIR of a ReferenceType from a reflected type
		/// </summary>
		protected ReferenceType(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}
	}
}