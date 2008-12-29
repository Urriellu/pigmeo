namespace Pigmeo.Internal {
	public struct LineEndings {
		public const string Unix = "\n"; //New Line/Line Feed
		public const string Windows = "\r\n"; //Carriage Return + New Line/Line Feed
		public const string MacOS9 = "\r"; //Carriage Return

		public static string[] LineEndingsArray = { Windows, Unix, MacOS9 };
	}
}
