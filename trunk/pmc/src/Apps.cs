namespace Pigmeo.PMC {
	/// <summary>
	/// List of available applications which can be called from within PMC
	/// </summary>
	public static class Apps {
		/// <summary>
		/// High level language compilers
		/// </summary>
		public static class HL {
			public static App gmcs = new App("Mono C# Compiler", "mcs", "gmcs");
			public static App CustomHLCompiler;
		}

		/// <summary>
		/// Pigmeo-related applications
		/// </summary>
		public static class Pigmeo {
			public static App PMC = new App("PMC", "pmc", "pmc");
			public static App PigmeoCompiler = new App("Pigmeo Compiler", "pigmeo-compiler", "pigmeo");
		}

		/// <summary>
		/// Assembler applications
		/// </summary>
		public static class Assemblers {
			public static App gpasm = new App("GNU PIC Assembler", "gpasm", "gpasm");
			public static App CustomAssembler;
		}
	}
}
