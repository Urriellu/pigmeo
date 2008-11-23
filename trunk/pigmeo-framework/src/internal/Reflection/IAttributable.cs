using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public interface IAttributable {
		CustomAttrCollection CustomAttributes { get; }
	}
}
