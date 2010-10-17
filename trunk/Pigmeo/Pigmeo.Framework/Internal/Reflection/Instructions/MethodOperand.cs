using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	public static partial class Instructions {
		/// <summary>
		/// Instruction whose operand is a method
		/// </summary>
		public abstract class MethodOperand:Instruction {
			/// <summary>
			/// Method this instruction references
			/// </summary>
			public Method ReferencedMethod {
				get {
					if(_ReferencedMethod == null) {
						MethodReference method = (MethodReference)OriginalInstruction.Operand;
						_ReferencedMethod = ParentMethod.ParentAssembly.GetAType(method.DeclaringType.FullName).Methods.GetFromCecil(method);
					}
					return _ReferencedMethod;
				}
			}
			protected Method _ReferencedMethod;

			/// <summary>
			/// Instantiates a new object that represents a CIL instruction whose operand is a Method
			/// </summary>
			/// <param name="ParentMethod">Method that has/contains/executes this instruction</param>
			/// <param name="OriginalInstruction">Original instruction, as represented by Mono.Cecil</param>
			public MethodOperand(Method ParendMethod, MCCil.Instruction OriginalInstruction)
				: base(ParendMethod, OriginalInstruction) {
				ReferencesAMethod = true;
				ShowExternalInfo.InfoDebug("Instantiating new instruction which references a Method: {0} {1}", OriginalInstruction.OpCode.ToString(), ((MethodReference)OriginalInstruction.Operand).Name);
			}

			public override string ToString() {
				return base.ToString() + " " + ReferencedMethod.FullNameWAssParams;
			}
		}
	}
}