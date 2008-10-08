using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Load argument address onto the stack
		/// </summary>
		public class ldarga:ParameterOperand {
			public ldarga(Method ParentMethod, MCCil.Instruction OriginalInstruction)
				: base(ParentMethod, OriginalInstruction) {
				Console.WriteLine("Secuence de {0}: {1}", ((Mono.Cecil.ParameterDefinition)OriginalInstruction.Operand).Name, ((Mono.Cecil.ParameterDefinition)OriginalInstruction.Operand).Sequence);
				if(OriginalInstruction.Operand is Mono.Cecil.ParameterDefinition) Index = (UInt16)((((Mono.Cecil.ParameterDefinition)OriginalInstruction.Operand).Sequence) - 1);
				this.OpCode = OpCodes.ldarga;
			}
		}
	}
}