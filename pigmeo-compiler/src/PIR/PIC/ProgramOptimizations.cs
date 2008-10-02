using System;
using System.Collections.Generic;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// List of available optimizations that can be done to a Program for PIC
	/// </summary>
	public class ProgramOptimizations:PIR.ProgramOptimizations {
		//There are no special optimizations for PICs yet
		public ProgramOptimizations(Program ProgramToOptimize) : base(ProgramToOptimize) {
		}
	}
}
