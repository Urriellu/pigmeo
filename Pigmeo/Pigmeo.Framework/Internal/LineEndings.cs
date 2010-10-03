namespace Pigmeo.Internal {
	/// <summary>
	/// Types of end of lines (carriage return, line feed...) depending on Operating System
	/// </summary>
	public struct LineEndings {
		/// <summary>
		/// Unix-style line ending (Linux, BSD, OSX, BeOS...) (New Line/Line Feed)
		/// </summary>
		public const string Unix = "\n";

		/// <summary>
		/// Windows-style line ending (Carriage Return + New Line/Line Feed)
		/// </summary>
		public const string Windows = "\r\n";

		/// <summary>
		/// MacOS9-style line ending (Carriage Return)
		/// </summary>
		public const string MacOS9 = "\r";

		/// <summary>
		/// List of all available line endings
		/// </summary>
		public static string[] LineEndingsArray = { Windows, Unix, MacOS9 };
	}
}
