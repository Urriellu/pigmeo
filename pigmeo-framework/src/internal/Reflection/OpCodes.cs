using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public enum OpCodes {
		/// <summary>
		/// Executes the addition arithmetic operation on the two topmost variables on the stack, and pushes the result on top of the stack
		/// </summary>
		add,
		add_ovf,
		add_ovf_un,
		conv_i,
		conv_i1,
		conv_i2,
		conv_i4,
		conv_i8,
		conv_r4,
		conv_r8,
		conv_r_un,
		conv_u,
		/// <summary>
		/// Convert to unsigned int8, pushing int32 on stack
		/// </summary>
		conv_u1,
		conv_u2,
		conv_u4,
		conv_u8,
		ldc_i4,
		/// <summary>
		/// Loads the constant value of 0 and puts it on top of stack as int32
		/// </summary>
		ldc_i4_0,
		ldc_i4_1,
		ldc_i4_2,
		ldc_i4_3,
		ldc_i4_4,
		ldc_i4_5,
		ldc_i4_6,
		ldc_i4_7,
		ldc_i4_8,
		ldc_i4_m1,
		/// <summary>
		/// Pushes the value of a static field on the stack
		/// </summary>
		ldsfld,
		/// <summary>
		/// Return from the current method
		/// </summary>
		ret,
		/// <summary>
		/// Replaces the value of a static field with a value from the stack
		/// </summary>
		stsfld
	}
}
