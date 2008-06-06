using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents an exception thrown by PMC
	/// </summary>
	public class PmcException:Exception {
		public PmcException(string message):base(message) { }
	}
}
