namespace Pigmeo.PMC {
	public class CLILanguages {
		public readonly string RealName;

		protected CLILanguages(string RealName) {
			this.RealName = RealName;
		}

		public override string ToString() {
			return RealName;
		}

		#region enum-like languages
		public static CLILanguages CSharp = new CLILanguages("C#");
		public static CLILanguages VBNET = new CLILanguages("Visual Basic .NET");
		public static CLILanguages Nemerle = new CLILanguages("Nemerle");
		#endregion
	}
}
