using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Specifies if the result of the operation of some byte oriented instructions will be stored in W or in a file/register
	/// </summary>
	public enum Destination:byte { W = 0, F = 1 } //this should be one bit
}
