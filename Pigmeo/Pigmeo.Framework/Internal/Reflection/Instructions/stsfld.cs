using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Replaces the value of a static field with a value from the stack
		/// </summary>
		public class stsfld:FieldOperand {
			/// <summary>
			/// Gets a new PIRefld.stsfld from its Mono.Cecil representation
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstr">Original instruction, as represented by Mono.Cecil</param>
			public static new stsfld GetFromCecilInstruction(Method ParentMethod, MCCil.Instruction OriginalInstr) {
				return new stsfld(ParentMethod, OriginalInstr);
			}

			/// <summary>
			/// Instantiates a new object that represents a "stsfld" CIL instruction
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public stsfld(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				this.OpCode = OpCodes.stsfld;
			}
		}
	}
}