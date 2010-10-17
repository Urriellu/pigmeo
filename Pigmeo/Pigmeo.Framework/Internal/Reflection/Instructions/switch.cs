using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Implements a jump table. Based on the value on top of stack jumps to a given instruction
		/// </summary>
		public class Switch:InstructionArrayOperand {
			/// <summary>
			/// Instantiates a new object that represents a "switch" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public Switch(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.Switch;
			}
		}
	}
}