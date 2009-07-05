using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is an array referencing other Instructions
		/// </summary>
		public abstract class InstructionArrayOperand:Instruction {
			/// <summary>
			/// Referenced Instructions indices in the Parent Method's body
			/// </summary>
			public int[] RefdInstrsIndices {
				get {
					if(_RefdInstrsIndices == null) {
						MCCil.Instruction[] MCCilInstrs = OriginalInstruction.Operand as MCCil.Instruction[];
						_RefdInstrsIndices = new int[MCCilInstrs.Length];
						for(int i = 0; i < _RefdInstrsIndices.Length; i++) {

							//so dirty, I know :-(
							int index = 0;
							MCCil.Instruction inst = MCCilInstrs[i];
							while(inst.Previous != null) {
								index++;
								inst = inst.Previous;
							}
							_RefdInstrsIndices[i] = index;
						}
					}
					return _RefdInstrsIndices;
				}
				//protected set;
			}
			protected int[] _RefdInstrsIndices;

			/// <summary>
			/// Instructions this Instruction references
			/// </summary>
			public Instruction[] RefdInstrs {
				get {
					if(_RefdInstrs == null) {
						MCCil.Instruction[] MCCilInstrs = OriginalInstruction.Operand as MCCil.Instruction[];
						_RefdInstrs = new Instruction[MCCilInstrs.Length];
						for(int i = 0; i < _RefdInstrs.Length; i++) {
							_RefdInstrs[i] = ParentMethod.Instructions[RefdInstrsIndices[i]];
						}
					}
					return _RefdInstrs;
				}
			}
			protected Instruction[] _RefdInstrs;

			public InstructionArrayOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand == null) throw new ArgumentException("It has no operand! (Instruction[] Operand expected)");
				if(!(OriginalInstruction.Operand is MCCil.Instruction[])) throw new ArgumentException("Wrong operand");
				ReferencesInstructions = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references more Instructions: {0}", OriginalInstruction.OpCode);
			}

			public override string ToString() {
				string ret = base.ToString();
				foreach(Instruction inst in RefdInstrs) {
					ret += " " + inst.Label;
				}
				return ret;
			}
		}
	}
}