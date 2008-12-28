using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a value type
	/// </summary>
	public abstract class ValueType:Type {
		#region static members
		/// <summary>
		/// Generates a PIR of a ValueType from a reflected type
		/// </summary>
		public ValueType(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers):base(ParentProgram, ReflectedType, IncludeMembers) {
		}
		#endregion
	}
}