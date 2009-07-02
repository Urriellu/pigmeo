using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public enum OpCodes {
		/// <summary>
		/// Executes the addition arithmetic operation on the two topmost variables on the stack, and pushes the result on top of the stack
		/// </summary>
		add,
		add_ovf,
		/// <summary>
		/// Computes the bitwise AND of two values and pushes the result on the stack
		/// </summary>
		and,
		ckfinite,
		div,
		div_un,
		mul,
		mul_ovf,
		mul_ovf_un,
		neg,
		not,
		/// <summary>
		/// Computes the bitwise complement (OR) of the two integer values on top of stack and pushes the result on the stack
		/// </summary>
		or,
		rem,
		rem_un,
		/// <summary>
		/// Shifts an integer valueto the left (in zeroes) by a specified number of bits and puts the result on the stack
		/// </summary>
		shl,
		shr,
		shr_un,
		sub,
		sub_ovf,
		sub_ovf_un,
		ldarg,
		ldarg_s,
		ldarg_0,
		ldarg_1,
		ldarg_2,
		ldarg_3,
		ldarga,
		ldarga_s,
		ldelem,
		ldelem_i1,
		ldelem_i2,
		ldelem_i4,
		ldelem_i8,
		ldelem_u1,
		ldelem_u2,
		ldelem_u4,
		ldelem_u8,
		ldelem_r4,
		ldelem_r8,
		ldelem_i,
		ldelem_ref,
		ldelema,
		ldfld,
		ldflda,
		ldlen,
		ldftn,
		ldind_i1,
		ldind_i2,
		ldind_i4,
		ldind_i8,
		ldind_u1,
		ldind_u2,
		ldind_u4,
		ldind_u8,
		ldind_r4,
		ldind_r8,
		ldind_i,
		ldind_ref,
		/// <summary>
		/// Load local variable into stack
		/// </summary>
		ldloc,
		/// <summary>
		/// Load local variable onto stack, short form
		/// </summary>
		ldloc_s,
		/// <summary>
		/// Load local variable 0 onto stack
		/// </summary>
		ldloc_0,
		/// <summary>
		/// Load local variable 1 onto stack
		/// </summary>
		ldloc_1,
		/// <summary>
		/// Load local variable 2 onto stack
		/// </summary>
		ldloc_2,
		/// <summary>
		/// Load local variable 3 onto stack
		/// </summary>
		ldloc_3,
		ldloca,
		ldloca_s,
		ldnull,
		ldobj,
		ldsize,
		ldstr,
		ldtoken,
		ldvirtftn,
		mkrefany,
		refanytype,
		refanyval,
		starg,
		starg_s,
		stind_i1,
		stind_i2,
		stind_i4,
		stind_i8,
		stind_r4,
		stind_r8,
		stind_i,
		stind_ref,
		/// <summary>
		/// Pop a value from stack into a local variable
		/// </summary>
		stloc,
		stloc_s,
		/// <summary>
		/// Pop a value from stack into local variable 0
		/// </summary>
		stloc_0,
		/// <summary>
		/// Pop a value from stack into local variable 1
		/// </summary>
		stloc_1,
		/// <summary>
		/// Pop a value from stack into local variable 2
		/// </summary>
		stloc_2,
		/// <summary>
		/// Pop a value from stack into local variable 3
		/// </summary>
		stloc_3,
		stelem,
		stelem_i1,
		stelem_i2,
		stelem_i4,
		stelem_i8,
		stelem_r4,
		stelem_r8,
		stelem_i,
		stelem_ref,
		stfld,
		stobj,
		/// <summary>
		/// Computes the bitwise XOR of the two integer values on top of stack and pushes the result on the stack
		/// </summary>
		xor,
		add_ovf_un,
		/// <summary>
		/// Loads a constant and puts it on top of stack as int32
		/// </summary>
		ldc_i4,
		/// <summary>
		/// Loads the constant value of 0 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_0,
		/// <summary>
		/// Loads the constant value of 1 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_1,
		/// <summary>
		/// Loads the constant value of 2 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_2,
		/// <summary>
		/// Loads the constant value of 3 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_3,
		/// <summary>
		/// Loads the constant value of 4 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_4,
		/// <summary>
		/// Loads the constant value of 5 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_5,
		/// <summary>
		/// Loads the constant value of 6 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_6,
		/// <summary>
		/// Loads the constant value of 7 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_7,
		/// <summary>
		/// Loads the constant value of 8 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_8,
		/// <summary>
		/// Loads the constant value of -1 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_m1,
		/// <summary>
		/// Loads a constant as int8 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_s,
		ldc_r4,
		ldc_r8,
		/// <summary>
		/// Pushes the value of a static field on the stack
		/// </summary>
		ldsfld,
		/// <summary>
		/// Pushes the address of a static field on the stack
		/// </summary>
		ldsflda,
		/// <summary>
		/// Return from the current method
		/// </summary>
		ret,
		/// <summary>
		/// Replaces the value of a static field with a value from the stack
		/// </summary>
		stsfld,
		/// <summary>
		/// Compares the two values on top of the stack. If they are equal, then 1 (of type int32) is pushed on the stack. Otherwise, 0 (of type int32) is pushed on the stack.
		/// </summary>
		ceq,
		/// <summary>
		/// Jumps to a given instruction if the two values on top of the stack are equal
		/// </summary>
		beq,
		bge,
		bge_un,
		bgt,
		bgt_un,
		ble,
		ble_un,
		blt,
		blt_s,
		blt_un,
		bne_un,
		br,
		br_s,
		Break,
		brfalse,
		brfalse_s,
		brtrue,
		cgt,
		cgt_un,
		clt,
		clt_un,
		jmp,
		leave,
		nop,
		Switch,
		isinst,
		box,
		unbox,
		unboxany,
		castclass,
		/// <summary>
		/// Convert to int8, pushing int32 on stack
		/// </summary>
		conv_i1,
		conv_i2,
		conv_i4,
		conv_i8,
		/// <summary>
		/// Convert to unsigned int8, pushing int32 on stack
		/// </summary>
		conv_u1,
		conv_u2,
		conv_u4,
		conv_u8,
		conv_r4,
		conv_r8,
		conv_i,
		conv_u,
		conv_r_un,
		conv_ovf_i1,
		conv_ovf_i2,
		conv_ovf_i4,
		conv_ovf_i8,
		conv_ovf_u1,
		conv_ovf_u2,
		conv_ovf_u4,
		conv_ovf_u8,
		conv_ovf_r4,
		conv_ovf_r8,
		conv_ovf_i,
		conv_ovf_u,
		conv_ovf_i1_un,
		conv_ovf_i2_un,
		conv_ovf_i4_un,
		conv_ovf_i8_un,
		conv_ovf_u1_un,
		conv_ovf_u2_un,
		conv_ovf_u4_un,
		conv_ovf_u8_un,
		conv_ovf_r4_un,
		conv_ovf_r8_un,
		conv_ovf_i_un,
		conv_ovf_u_un,
		call,
		calli,
		callvirt,
		endfilter,
		endfinally,
		rethrow,
		Throw,
		cpblk,
		cpobj,
		dup,
		initblk,
		initobj,
		localloc,
		pop,
		newarr,
		newobj,
		Volatile
	}
}
