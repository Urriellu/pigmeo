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
			/// Referenced Instruction index in the Parent Method's body
			/// </summary>
			public int RefdInstrIndex {
				get {
					if(!_RefdInstrIndex.HasValue) {
						//so dirty, I know :-(
						int index = 0;
						MCCil.Instruction i = OriginalInstruction.Operand as MCCil.Instruction;
						while(i.Previous != null) {
							index++; Console.WriteLine(index);
							i = i.Previous;
						}
						_RefdInstrIndex = index;
					}
					return _RefdInstrIndex.Value;
				}
				//protected set;
			}
			protected int? _RefdInstrIndex;

			/// <summary>
			/// Instruction this Instruction references
			/// </summary>
			public Instruction RefdInstr {
				get {
					if(_RefdInstr == null) {
						_RefdInstr = ParentMethod.Instructions[RefdInstrIndex];
					}
					return _RefdInstr;
				}
			}
			protected Instruction _RefdInstr;

			public InstructionOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				//RefdInstrIndex = ParendMethod.Instructions.Count;
				ReferencesInstruction = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references another Instruction: {0}", OriginalInstruction.OpCode);
			}

			public override string ToString() {
				return base.ToString() + " " + RefdInstr.Label;
			}
		}
	}
}