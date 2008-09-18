using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Internal {
	/// <summary>
	/// Methods useful for printing debug or any other kind of information
	/// </summary>
	/// <remarks>
	/// These methods are delegates that a parent program (the one referencing this library) handles
	/// </remarks>
	public static class ShowExternalInfo {
		public delegate void InfoDebugDelegate(string Message);
		public delegate void InfoDebugDelegate2(string Message, params object[] args);
		public delegate void InfoDebugDecompileDelegate(string Title, object obj);
		public static InfoDebugDelegate InfoDebugDel;
		public static InfoDebugDelegate2 InfoDebugDel2;
		public static InfoDebugDecompileDelegate InfoDebugDecompileDel;

		/// <summary>
		/// Prints debug information
		/// </summary>
		/// <remarks>
		/// In order for this delegate to work, it must be handled by the application referencing this library. For example Pigmeo Compiler must add a delegate here so debug information from this library can be printed corrently
		/// </remarks>
		public static void InfoDebug(string message) {
			InfoDebugDel.Invoke(message);
		}

		/// <summary>
		/// Prints debug information
		/// </summary>
		public static void InfoDebug(string message, params object[] args) {
			InfoDebugDel2.Invoke(message, args);
		}

		/// <summary>
		/// Prints the decompilation of an Assembly, Program or any member as debug information
		/// </summary>
		/// <param name="Title">Title attached to the debug information</param>
		/// <param name="obj">Object to decompile</param>
		public static void InfoDebugDecompile(string Title, object obj) {
			InfoDebugDecompileDel.Invoke(Title, obj);
		}
	}
}
