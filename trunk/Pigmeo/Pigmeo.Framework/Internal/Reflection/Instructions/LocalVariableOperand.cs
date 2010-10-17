using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is a Local Variable
		/// </summary>
		public abstract class LocalVariableOperand:Instruction {
			/// <summary>
			/// Local variable index
			/// </summary>
			public UInt16 VariableIndex {
				get;
				protected set;
			}

			/// <summary>
			/// Local variable being copied to the stack
			/// </summary>
			public LocalVariable Variable {
				get {
					return ParentMethod.LocalVariables[VariableIndex];
				}
			}

			/// <summary>
			/// Instantiates a new object that represents a CIL instruction whose operand is a Local Variable
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public LocalVariableOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				if(OriginalInstruction.Operand is UInt16) VariableIndex = (UInt16)OriginalInstruction.Operand;
				if(OriginalInstruction.Operand is MCCil.VariableDefinition) VariableIndex = ParentMethod.ParentAssembly.GetAType(((MCCil.VariableDefinition)OriginalInstruction.Operand).Method.DeclaringType.FullName).Methods.GetFromCecil(((MCCil.VariableDefinition)OriginalInstruction.Operand).Method).LocalVariables[((MCCil.VariableDefinition)OriginalInstruction.Operand).Name].Index;
				ReferencesALocalVar = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a Local Variable: {0} {1}", OriginalInstruction.OpCode.ToString(), Variable.Name);
			}

			public override string ToString() {
				return base.ToString() + " " + Variable.Name;
			}
		}
	}
}