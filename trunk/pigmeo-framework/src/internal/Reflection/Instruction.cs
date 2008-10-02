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

		/// <summary>
		/// Gets a Pigmeo.Internal.Reflection.Instruction from its Mono.Cecil representation
		/// </summary>
		/// <param name="ParentMethod">Method this instruction is contained in</param>
		/// <param name="OriginalInstr">This instruction, as represented by Mono.Cecil</param>
		public static Instruction GetFromCecilInstruction(Method ParentMethod, MCCil.Instruction OriginalInstr) {
			string DebugTxt = "Parsing CIL instruction while converting to P.I.Reflection. Cecil OpCode: " + OriginalInstr.OpCode.Name;
			if(OriginalInstr.Operand != null) DebugTxt += ", Operand type: " + OriginalInstr.Operand.GetType().FullName;
			ShowExternalInfo.InfoDebug(DebugTxt);

			if(OriginalInstr.OpCode == MCCil.OpCodes.Add) return new Instructions.add(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Call) return new Instructions.call(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Conv_U1) return new Instructions.conv_u1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4) return new Instructions.ldc_i4(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_0) return new Instructions.ldc_i4_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_1) return new Instructions.ldc_i4_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_2) return new Instructions.ldc_i4_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_3) return new Instructions.ldc_i4_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_4) return new Instructions.ldc_i4_4(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_5) return new Instructions.ldc_i4_5(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_6) return new Instructions.ldc_i4_6(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_7) return new Instructions.ldc_i4_7(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_8) return new Instructions.ldc_i4_8(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_M1) return new Instructions.ldc_i4_m1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_I4_S) return new Instructions.ldc_i4_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc) return new Instructions.ldloc(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_S) return new Instructions.ldloc_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_0) return new Instructions.ldloc_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_1) return new Instructions.ldloc_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_2) return new Instructions.ldloc_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_3) return new Instructions.ldloc_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldsfld) return new Instructions.ldsfld(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ret) return new Instructions.ret(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc) return new Instructions.stloc(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_S) return new Instructions.stloc_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_0) return new Instructions.stloc_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_1) return new Instructions.stloc_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_2) return new Instructions.stloc_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_3) return new Instructions.stloc_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stsfld) return new Instructions.stsfld(ParentMethod, OriginalInstr);
			throw new ReflectionException("Unknown CIL instruction: " + OriginalInstr.OpCode.Name);
		}

		/// <summary>
		/// The Operation Code of this instruction
		/// </summary>
		public OpCodes OpCode {
			get;
			protected set;
		}

		/// <summary>
		/// Gets this instruction's OpCode proper name. For example: "ldc.i4.0" instead of "ldc_i4_0"
		/// </summary>
		public string OpCodeName {
			get {
				return OpCode.ToString().Replace('_', '.').ToLowerInvariant();
			}
		}

		/// <summary>
		/// Indicates if this instruction references a Field
		/// </summary>
		public bool ReferencesAField = false;

		/// <summary>
		/// Indicates if this instruction references a Method
		/// </summary>
		public bool ReferencesAMethod = false;

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