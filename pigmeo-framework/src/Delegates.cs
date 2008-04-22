using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo {
	public static class Delegates {
		/// <summary>
		/// Reads a variable and returns a boolean value
		/// </summary>
		public delegate bool ReadBool();

		/// <summary>
		/// Sets a bool variable to a given value
		/// </summary>
		/// <returns></returns>
		public delegate void SetBool(bool value);
	}
}
