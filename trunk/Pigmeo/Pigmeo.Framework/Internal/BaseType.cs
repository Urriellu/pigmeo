using System;

namespace Pigmeo.Internal {
	/// <summary>
	/// List of Base Types supported in CIL, PIR, .NET... (Bool, UInt8, Float32...)
	/// </summary>
	public enum BaseType:byte {
		Char, Bool, UInt8, Int8, UInt16, Int16, UInt32, Int32, Float32, UInt64, Int64, Float64, NativeInt, NativeUInt, NativePointer
	}

	public static class BaseTypeExtensions {
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

		public static bool IsHeavierThan(this BaseType bt, BaseType OtherBT) {
			if(bt.IsArchDepSize() || OtherBT.IsArchDepSize()) throw new ArgumentException("Native sizes cannot be weighted");
			else return (byte)bt >= (byte)OtherBT;
		}
	}
}
