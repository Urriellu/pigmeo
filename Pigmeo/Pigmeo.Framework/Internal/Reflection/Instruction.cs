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

		public int Index {
			get {
				if(_Index == null) _Index = ParentMethod.Instructions.IndexOf(this);
				return _Index.Value;
			}
		}
		protected int? _Index;

		public string Label {
			get {
				return "IL" + string.Format("{0:x4}", Index);
			}
		}

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
			else if(OriginalInstr.OpCode == MCCil.OpCodes.And) return new Instructions.and(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ble) return new Instructions.ble(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Box) return new Instructions.box(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Blt) return new Instructions.blt(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Blt_S) return new Instructions.blt_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Br) return new Instructions.br(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Br_S) return new Instructions.br_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Brfalse) return new Instructions.brfalse(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Brfalse_S) return new Instructions.brfalse_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Call) return new Instructions.call(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Callvirt) return new Instructions.callvirt(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Conv_U1) return new Instructions.conv_u1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Div) return new Instructions.div(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg) return new Instructions.ldarg(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg_S) return new Instructions.ldarg_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg_0) return new Instructions.ldarg_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg_1) return new Instructions.ldarg_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg_2) return new Instructions.ldarg_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarg_3) return new Instructions.ldarg_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarga) return new Instructions.ldarga(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldarga_S) return new Instructions.ldarga_s(ParentMethod, OriginalInstr);
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
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_R4) return new Instructions.ldc_r4(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldc_R8) return new Instructions.ldc_r8(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldfld) return new Instructions.ldfld(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc) return new Instructions.ldloc(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_S) return new Instructions.ldloc_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_0) return new Instructions.ldloc_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_1) return new Instructions.ldloc_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_2) return new Instructions.ldloc_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloc_3) return new Instructions.ldloc_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloca) return new Instructions.ldloca(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldloca_S) return new Instructions.ldloca_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldsfld) return new Instructions.ldsfld(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldsflda) return new Instructions.ldsflda(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ldstr) return new Instructions.ldstr(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Mul) return new Instructions.mul(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Newobj) return new Instructions.newobj(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Or) return new Instructions.or(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Pop) return new Instructions.pop(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Ret) return new Instructions.ret(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Shl) return new Instructions.shl(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc) return new Instructions.stloc(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_S) return new Instructions.stloc_s(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_0) return new Instructions.stloc_0(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_1) return new Instructions.stloc_1(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_2) return new Instructions.stloc_2(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stloc_3) return new Instructions.stloc_3(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stfld) return new Instructions.stfld(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stobj) return new Instructions.stobj(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Stsfld) return new Instructions.stsfld(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Sub) return new Instructions.sub(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Throw) return new Instructions.Throw(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Volatile) return new Instructions.Volatile(ParentMethod, OriginalInstr);
			else if(OriginalInstr.OpCode == MCCil.OpCodes.Xor) return new Instructions.xor(ParentMethod, OriginalInstr);
			throw new ReflectionException(string.Format("Unknown CIL instruction \"{0}\" in method \"{1}\"", OriginalInstr.OpCode.Name, ParentMethod.FullNameWAssParams));
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
		/// Gets the previous Instruction. Null if this is the first one
		/// </summary>
		public Instruction Previous {
			get {
				if(Index > 0) return ParentMethod.Instructions[Index - 1];
				else return null;
			}
		}

		/// <summary>
		/// Gets the next Instruction. Null if this is the last one
		/// </summary>
		public Instruction Next {
			get {
				if(Index < ParentMethod.Instructions.Count - 1) return ParentMethod.Instructions[Index + 1];
				else return null;
			}
		}

		/// <summary>
		/// Indicates if this instruction references a Field
		/// </summary>
		public bool ReferencesAField = false;

		/// <summary>
		/// Indicates if this instruction references a Local Variable
		/// </summary>
		public bool ReferencesALocalVar = false;

		/// <summary>
		/// Indicates if this instruction references a Method Parameter
		/// </summary>
		public bool ReferencesAParameter = false;

		/// <summary>
		/// Indicates if this instruction references a Type
		/// </summary>
		public bool ReferencesAType = false;

		/// <summary>
		/// Indicates if this instruction references a CIL Instruction
		/// </summary>
		public bool ReferencesInstruction = false;

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
			return Label + ": " + OpCodeName;
		}
	}
}