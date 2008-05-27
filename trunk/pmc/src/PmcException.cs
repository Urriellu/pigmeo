using System;
using System.Collections.Generic;
using System.Text;

namespace Pigmeo.PMC {
	/// <summary>
	/// Represents an exception thrown by PMC
	/// </summary>
	public class PmcException:Exception {
		public readonly string msg;

		public PmcException(string message) {
			this.msg = message;
		}
	}
}
