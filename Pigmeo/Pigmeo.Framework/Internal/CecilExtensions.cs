﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace Pigmeo.Internal {
	/// <summary>
	/// Extensions to Mono.Cecil.MethodDefinition class
	/// </summary>
	public static class MethodDefinitionExtensions {
		/// <summary>
		/// Get the full name of this Method
		/// </summary>
		/// <param name="method">The given Method</param>
		public static string GetFullName(this MethodDefinition method) {
			return method.DeclaringType.FullName + "." + method.Name;
		}

		/// <summary>
		/// Checks if this Method is the Entry Point
		/// </summary>
		/// <param name="method">The given Method</param>
		public static bool IsEntryPoint(this MethodDefinition method) {
			MethodDefinition entry = method.DeclaringType.Module.Assembly.EntryPoint;
			if(method.Name == entry.Name && method.DeclaringType.FullName == entry.DeclaringType.FullName) return true;
			else return false;
		}
	}

	/// <summary>
	/// Extensions to Mono.Cecil.Instruction class
	/// </summary>
	public static class InstructionExtensions {
		/// <summary>
		/// Indicates if the instruction is a 'ldc' (load constant)
		/// </summary>
		public static bool IsLdc(this Instruction inst) {
			return inst.OpCode.IsLdc();
		}

		/// <summary>
		/// Indicates if the instruction is a 'ldc.i4' (load int32 constant)
		/// </summary>
		public static bool IsLdcI4(this Instruction inst) {
			return inst.OpCode.IsLdcI4();
		}

		/// <summary>
		/// Indicates if the instruction is an addition
		/// </summary>
		public static bool IsAdd(this Instruction inst) {
			return inst.OpCode.IsAdd();
		}

		/// <summary>
		/// Indicates if the opcode is a 'conv'
		/// </summary>
		public static bool IsConv(this Instruction inst) {
			return inst.OpCode.IsConv();
		}

		/// <summary>
		/// Indicates if the current instruction references another instruction (the argument passed to the CIL instruction is another instruction)
		/// </summary>
		public static bool ReferencesAnotherInstruction(this Instruction inst) {
			if(inst.Operand != null && inst.Operand.GetType() == typeof(Instruction)) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the current instruction references a static method
		/// </summary>
		public static bool ReferencesStaticMethod(this Instruction inst) {
			if(inst.Operand != null && inst.Operand.GetType() == typeof(MethodDefinition) && (inst.Operand as MethodDefinition).IsStatic) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if this instructions references a static field (ldsfld, stsfld...)
		/// </summary>
		public static bool ReferencesStaticField(this Instruction inst) {
			//if(inst.OpCode == OpCodes.Ldsfld || inst.OpCode == OpCodes.Stsfld) return true;
			if(inst.Operand != null && (inst.Operand.GetType() == typeof(FieldReference) || inst.Operand.GetType() == typeof(FieldDefinition))) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if this instruction pushes anything into the stack
		/// </summary>
		public static bool PushesIntoStack(this Instruction inst) {
			if(inst.IsAdd() || inst.IsConv() || inst.IsLdc()) return true;
			else return false;
		}

		public static bool CallsStaticFunction(this Instruction inst) {
			return (inst.OpCode == OpCodes.Call);
		}

		public static string Disassemble(this Instruction inst) {
			return string.Format("IL_{0:x4}: {1} {2}", inst.Offset, inst.OpCode.ToString(), (inst.Operand != null) ? inst.Operand.ToString() : "");
		}

		/// <summary>
		/// Gets the numeric value defined as the operand in a ldc.i4.* instruction
		/// </summary>
		public static Int32 GetLdcI4Value(this Instruction inst) {
			if(inst.OpCode == OpCodes.Ldc_I4_0) return 0;
			else if(inst.OpCode == OpCodes.Ldc_I4_1) return 1;
			else if(inst.OpCode == OpCodes.Ldc_I4_2) return 2;
			else if(inst.OpCode == OpCodes.Ldc_I4_3) return 3;
			else if(inst.OpCode == OpCodes.Ldc_I4_4) return 4;
			else if(inst.OpCode == OpCodes.Ldc_I4_5) return 5;
			else if(inst.OpCode == OpCodes.Ldc_I4_6) return 6;
			else if(inst.OpCode == OpCodes.Ldc_I4_7) return 7;
			else if(inst.OpCode == OpCodes.Ldc_I4_8) return 8;
			else if(inst.OpCode == OpCodes.Ldc_I4_M1) return -1;
			else if(inst.OpCode == OpCodes.Ldc_I4) return (Int32)inst.Operand;
			else if(inst.OpCode == OpCodes.Ldc_I4_S) return byte.Parse(inst.Operand.ToString()); //why doesn't a cast work?
			else throw new Exception("Unknown opcode " + inst.OpCode.ToString());
		}
	}

	/// <summary>
	/// Extensions to Mono.Cecil.Opcode class
	/// </summary>
	public static class OpCodeExtensions {
		/// <summary>
		/// Indicates if the opcode is a 'ldc' (load constant)
		/// </summary>
		public static bool IsLdc(this OpCode opc) {
			if(opc.IsLdcI4() ||
				opc == OpCodes.Ldc_I8 ||
				opc == OpCodes.Ldc_R4 ||
				opc == OpCodes.Ldc_R8
				) return true;
			return false;
		}

		/// <summary>
		/// Indicates if the opcode is a 'ldc.i4' (load int32 constant)
		/// </summary>
		public static bool IsLdcI4(this OpCode opc) {
			if(opc == OpCodes.Ldc_I4 ||
				opc == OpCodes.Ldc_I4_0 ||
				opc == OpCodes.Ldc_I4_1 ||
				opc == OpCodes.Ldc_I4_2 ||
				opc == OpCodes.Ldc_I4_3 ||
				opc == OpCodes.Ldc_I4_4 ||
				opc == OpCodes.Ldc_I4_5 ||
				opc == OpCodes.Ldc_I4_6 ||
				opc == OpCodes.Ldc_I4_7 ||
				opc == OpCodes.Ldc_I4_8 ||
				opc == OpCodes.Ldc_I4_M1 ||
				opc == OpCodes.Ldc_I4_S
				) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the opcode is an addition
		/// </summary>
		public static bool IsAdd(this OpCode opc) {
			if(opc == OpCodes.Add ||
				opc == OpCodes.Add_Ovf ||
				opc == OpCodes.Add_Ovf_Un
				) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the opcode is a substraction
		/// </summary>
		public static bool IsSub(this OpCode opc) {
			if(opc == OpCodes.Sub ||
				opc == OpCodes.Sub_Ovf ||
				opc == OpCodes.Sub_Ovf_Un
				) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the opcode is a 'conv'
		/// </summary>
		public static bool IsConv(this OpCode opc) {
			if(opc == OpCodes.Conv_I ||
				opc == OpCodes.Conv_I1 ||
				opc == OpCodes.Conv_I2 ||
				opc == OpCodes.Conv_I4 ||
				opc == OpCodes.Conv_I8 ||
				opc == OpCodes.Conv_Ovf_I ||
				opc == OpCodes.Conv_Ovf_I1 ||
				opc == OpCodes.Conv_Ovf_I2 ||
				opc == OpCodes.Conv_Ovf_I4 ||
				opc == OpCodes.Conv_Ovf_I8 ||
				opc == OpCodes.Conv_Ovf_I_Un ||
				opc == OpCodes.Conv_Ovf_I1_Un ||
				opc == OpCodes.Conv_Ovf_I2_Un ||
				opc == OpCodes.Conv_Ovf_I4_Un ||
				opc == OpCodes.Conv_Ovf_I8_Un ||
				opc == OpCodes.Conv_Ovf_U ||
				opc == OpCodes.Conv_Ovf_U1 ||
				opc == OpCodes.Conv_Ovf_U2 ||
				opc == OpCodes.Conv_Ovf_U4 ||
				opc == OpCodes.Conv_Ovf_U8 ||
				opc == OpCodes.Conv_Ovf_U_Un ||
				opc == OpCodes.Conv_Ovf_U1_Un ||
				opc == OpCodes.Conv_Ovf_U2_Un ||
				opc == OpCodes.Conv_Ovf_U4_Un ||
				opc == OpCodes.Conv_Ovf_U8_Un ||
				opc == OpCodes.Conv_R_Un ||
				opc == OpCodes.Conv_R4 ||
				opc == OpCodes.Conv_R8 ||
				opc == OpCodes.Conv_U ||
				opc == OpCodes.Conv_U1 ||
				opc == OpCodes.Conv_U2 ||
				opc == OpCodes.Conv_U4 ||
				opc == OpCodes.Conv_U8
				) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the frontend should modify the instruction or not
		/// </summary>
		public static bool IsFrontendDontTouch(this OpCode opc) {
			List<OpCode> Untouchables = new System.Collections.Generic.List<OpCode>();
			Untouchables.Add(OpCodes.Nop);
			Untouchables.Add(OpCodes.Ret);
			if(opc.IsLdc() || opc.IsAdd() || opc.IsSub() || opc.IsConv() || Untouchables.Contains(opc)) return true;
			else return false;
		}
	}
}
