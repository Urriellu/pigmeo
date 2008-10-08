using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is another Instruction
		/// </summary>
		public abstract class InstructionOperand:Instruction {
			/// <summary>
			/// Instruction index in the Parent Method's body
			/// </summary>
			public int Index {
				get;
				protected set;
			}

			/// <summary>
			/// Instruction this Instruction references
			/// </summary>
			public Instruction RefdInstr {
				get {
					if(_RefdInstr == null) {
						_RefdInstr = ParentMethod.Instructions[Index];
					}
					return _RefdInstr;
				}
			}
			protected Instruction _RefdInstr;

			public InstructionOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				ReferencesInstruction = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references another Instruction: {0}", OriginalInstruction.OpCode);
			}

			public override string ToString() {
				return base.ToString() + " " + RefdInstr.Label;
			}
		}
	}
}