﻿using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Shifts an integer value to the right by a specified number of bits and puts the result on the stack. It replicates the high order bit on each shift, preserving the sign of the original value
		/// </summary>
		public class shr:Instruction {
			public shr(Method OriginalMethod, MCCil.Instruction OriginalInstruction)
				: base(OriginalMethod, OriginalInstruction) {
				this.OpCode = OpCodes.shr;
			}
		}
	}
}