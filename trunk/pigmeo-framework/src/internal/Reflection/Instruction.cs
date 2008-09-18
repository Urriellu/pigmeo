using System;
using System.Collections.Generic;
using Mono.Cecil;
using MCCil = Mono.Cecil.Cil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected CIL Instruction
	/// </summary>
	public abstract class Instruction {
		/// <summary>
		/// This Instruction, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.Cil.Instruction OriginalInstruction;

		/// <summary>
		/// The Instruction's parent method. That's the Method this Instruction is placed within
		/// </summary>
		public readonly Method ParentMethod;

		public static Instruction GetFromCecilInstruction(Method OriginalMethod, MCCil.Instruction OriginalInstr) {
			Instruction NewInst = null;
			if(OriginalInstr.OpCode == MCCil.OpCodes.Add) NewInst = Instructions.add.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Conv_U1) return Instructions.conv_u1.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4) return Instructions.ldc_i4.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_0) return Instructions.ldc_i4_0.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_1) return Instructions.ldc_i4_1.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_2) return Instructions.ldc_i4_2.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_3) return Instructions.ldc_i4_3.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_4) return Instructions.ldc_i4_4.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_5) return Instructions.ldc_i4_5.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_6) return Instructions.ldc_i4_6.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_7) return Instructions.ldc_i4_7.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_8) return Instructions.ldc_i4_8.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_M1) return Instructions.ldc_i4_m1.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldsfld) return Instructions.ldsfld.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ret) return Instructions.ret.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stsfld) return Instructions.stsfld.GetFromCecilInstruction(OriginalMethod, OriginalInstr);
			else throw new ReflectionException("Unknown CIL instruction: " + OriginalInstr.OpCode.Name);
			return NewInst;
		}

		/*public OpCodes OpCode {
			get {
				if(_OpCode == null) {
					if(OriginalInstruction.OpCode == MCCil.OpCodes.Add) _OpCode = OpCodes.add;
				} else throw new ReflectionException("Unknown CIL instruction: " + OriginalInstruction.OpCode.Name);
				return _OpCode.Value;
			}
		}
		protected OpCodes? _OpCode = null;*/
		public OpCodes OpCode {
			get;
			protected set;
		}

		/// <summary>
		/// 
		/// </summary>
		public string OpCodeName {
			get {
				//Note for developers: we don't need to parse opcodes whose real name is exactly the same as its value in the OpCodes enum
				switch(OpCode) {
					case OpCodes.ldc_i4:
						return "ldc.i4";
					case OpCodes.ldc_i4_0:
						return "ldc.i4.0";
					case OpCodes.ldc_i4_1:
						return "ldc.i4.1";
					case OpCodes.ldc_i4_2:
						return "ldc.i4.2";
					case OpCodes.ldc_i4_3:
						return "ldc.i4.3";
					case OpCodes.ldc_i4_4:
						return "ldc.i4.4";
					case OpCodes.ldc_i4_5:
						return "ldc.i4.5";
					case OpCodes.ldc_i4_6:
						return "ldc.i4.6";
					case OpCodes.ldc_i4_7:
						return "ldc.i4.7";
					case OpCodes.ldc_i4_8:
						return "ldc.i4.8";
					case OpCodes.ldc_i4_m1:
						return "ldc.i4.m1";
					default:
						return OpCode.ToString();
				}
			}
		}

		public object Operand {
			get;
			protected set;
		}

		protected Instruction(Method ParentMethod, MCCil.Instruction OriginalInstruction) {
			if(ParentMethod == null) throw new ArgumentNullException("ParentMethod");
			if(OriginalInstruction == null) throw new ArgumentNullException("OriginalInstruction");
			this.ParentMethod = ParentMethod;
			this.OriginalInstruction = OriginalInstruction;
		}

		public override string ToString() {
			return OpCodeName;
		}
	}
}