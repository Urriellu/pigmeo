using System;

namespace Pigmeo.Internal {
	/// <summary>
	/// List of Base Types supported in CIL, PIR, .NET... (Bool, UInt8, Float32...)
	/// </summary>
	public enum BaseType:byte {
		/// <summary>
		/// Unicode character
		/// </summary>
		Char,
		
		/// <summary>
		/// Boolean value
		/// </summary>
		Bool,
		
		/// <summary>
		/// 8-bit unsigned integer
		/// </summary>
		UInt8,
		
		/// <summary>
		/// 8-bit signed integer
		/// </summary>
		Int8,
		
		/// <summary>
		/// 16-bit unsigned integer
		/// </summary>
		UInt16,
		
		/// <summary>
		/// 16-bit signed integer
		/// </summary>
		Int16,
		
		/// <summary>
		/// 32-bit unsigned integer
		/// </summary>
		UInt32,
		
		/// <summary>
		/// 32-bit signed integer
		/// </summary>
		Int32,
		
		/// <summary>
		/// Single-precision (32-bit) floating-point number
		/// </summary>
		Float32,

		/// <summary>
		/// 64-bit unsigned integer
		/// </summary>
		UInt64,

		/// <summary>
		/// 64-bit signed integer
		/// </summary>
		Int64,

		/// <summary>
		/// Double-precision (64-bit) floating-point number
		/// </summary>
		Float64,
		
		/// <summary>
		/// Signed integer, size depending on architecture
		/// </summary>
		NativeInt,
		
		/// <summary>
		/// Unsigned integer, size depending on architecture
		/// </summary>
		NativeUInt,
		
		/// <summary>
		/// Pointer to a given memory location
		/// </summary>
		NativePointer
	}

	/// <summary>
	/// Extensions to the BaseType enum
	/// </summary>
	public static class BaseTypeExtensions {
		/// <summary>
		/// Get the full name used in the Base Class Library
		/// </summary>
		/// <param name="bt">Current Base Type object</param>
		public static string GetBclName(this BaseType bt) {
			switch(bt) {
				case BaseType.Char:
					return "System.Char";
				case BaseType.Bool:
					return "System.Boolean";
				case BaseType.UInt8:
					return "System.Byte";
				case BaseType.UInt16:
					return "System.UInt16";
				case BaseType.UInt32:
					return "System.UInt32";
				case BaseType.UInt64:
					return "System.UInt64";
				case BaseType.Int8:
					return "System.SByte";
				case BaseType.Int16:
					return "System.Int16";
				case BaseType.Int32:
					return "System.Int32";
				case BaseType.Int64:
					return "System.Int64";
				default:
					throw new NotImplementedException("Unknown base type: " + bt.ToString());
			}
		}

		/// <summary>
		/// Get the full name used in CIL
		/// </summary>
		/// <param name="bt">Current Base Type Object</param>
		public static string GetCilName(this BaseType bt) {
			switch(bt) {
				case BaseType.UInt8:
					return "uint8";
				case BaseType.Int32:
					return "int32";
				case BaseType.Int64:
					return "int64";
				default:
					throw new NotImplementedException("Unknown base type: " + bt.ToString());
			}
		}

		/// <summary>
		/// Indicates if the size of this Base Type depends on the target architecture
		/// </summary>
		public static bool IsArchDepSize(this BaseType bt) {
			if(bt == BaseType.NativeInt || bt == BaseType.NativePointer || bt == BaseType.NativeUInt) return true;
			else return false;
		}

		/// <summary>
		/// Indicates if the size of this Base Type is standard (same size for all architectures)
		/// </summary>
		public static bool IsStandardSize(this BaseType bt) {
			return !bt.IsArchDepSize();
		}

		/// <summary>
		/// Determines if this Base Type takes more space in memory than another Base Type
		/// </summary>
		/// <param name="bt">This Base Type</param>
		/// <param name="OtherBT">Another Base Type</param>
		public static bool IsHeavierThan(this BaseType bt, BaseType OtherBT) {
			if(bt.IsArchDepSize() || OtherBT.IsArchDepSize()) throw new ArgumentException("Native sizes cannot be weighted");
			else return (byte)bt >= (byte)OtherBT;
		}
	}
}
