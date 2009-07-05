using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Jumps to a given instruction if the two values on top of the stack are not equal (for unsigned int) or unordered (for floating point)
		/// </summary>
		public class bne_un:InstructionOperand {
			public bne_un(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.bne_un;
			}
		}
	}
}