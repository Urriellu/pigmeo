using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler {
	/// <summary>
	/// The possible compiler statuses
	/// </summary>
	public enum CompilerStage {
		/// <summary>
		/// Compiler initialization
		/// </summary>
		Initialization,

		/// <summary>
		/// Intermediate stages between different stages
		/// </summary>
		Intermediate,

		/// <summary>
		/// Running the high level language compiler
		/// </summary>
		HighLevelCompiler,

		/// <summary>
		/// Running the Frontend
		/// </summary>
		Frontend,

		/// <summary>
		/// Running the backend
		/// </summary>
		Backend,

		/// <summary>
		/// Running the assembler
		/// </summary>
		Assembler
	}
}
