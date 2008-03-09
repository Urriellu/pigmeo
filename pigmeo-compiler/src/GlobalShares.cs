using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler {
	/// <summary>
	/// Miscellaneous variables and objects available for the entire application
	/// </summary>
	public static class GlobalShares {
		/// <summary>
		/// Assembly which is going to be compiled. It is usually created from Frontend()
		/// </summary>
		/// <remarks>
		/// We need to store the assembly here so we can compile it (in the backend) after running the frontend without saving it to disk
		/// </remarks>
		public static Mono.Cecil.AssemblyDefinition AssemblyToCompile;

		/// <summary>
		/// List of references of the user application
		/// </summary>
		public static List<string> UserAppReferenceFiles = new List<string>();
	}
}
