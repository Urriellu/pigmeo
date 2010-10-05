using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Reflection type or member allowed to have custom attributes
	/// </summary>
	public interface IAttributable {
		/// <summary>
		/// Collection of Custom Attributes
		/// </summary>
		CustomAttrCollection CustomAttributes { get; }
	}
}
