using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Custom Attribute Parameter
	/// </summary>
	public class CustomAttrParam {
		/// <summary>
		/// The type of this parameter
		/// </summary>
		public Type Type { get; protected set; }

		/// <summary>
		/// This parameter's value. It must be the same type as defined in "Type"
		/// </summary>
		public object Value { get; protected set; }

		/// <summary>
		/// Creates a reflected .NET Custom Attribute Parameter
		/// </summary>
		/// <param name="Type">The type of this parameter</param>
		/// <param name="Value">Its value. It must be the same type previously specified</param>
		public CustomAttrParam(Type Type, object Value) {
			this.Type = Type;
			this.Value = Value;
		}
	}
}
