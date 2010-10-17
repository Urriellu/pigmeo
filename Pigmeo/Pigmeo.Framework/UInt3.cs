using System;
using Pigmeo.Extensions;

namespace Pigmeo {
	/// <summary>
	/// 3-bit unsigned integer. Range: 0-7.
	/// </summary>
	public struct UInt3 {
		/// <summary>
		/// Largest possible value of UInt3
		/// </summary>
		public const byte MaxValue = 7;

		/// <summary>
		/// Smallest possible value of UInt3
		/// </summary>
		public const byte MinValue = 0;

		/// <summary>
		/// Bit 0 (LSB)
		/// </summary>
		public bool Bit0;

		/// <summary>
		/// Bit 1
		/// </summary>
		public bool Bit1;

		/// <summary>
		/// Bit 2 (MSB)
		/// </summary>
		public bool Bit2;

		public UInt3(bool Bit2, bool Bit1, bool Bit0) {
			this.Bit0 = Bit0;
			this.Bit1 = Bit1;
			this.Bit2 = Bit2;
		}

		public UInt3(byte b) {
			this = (UInt3)b;
		}

		public string ToBinaryString() {
			return string.Format("{0}:X", Bit2) + string.Format("{0}:X", Bit1) + string.Format("{0}:X", Bit0);
		}

		#region operator overloading
		public static UInt3 operator +(UInt3 a, UInt3 b) {
			return (UInt3)((byte)a + (byte)b);
		}

		public static UInt3 operator ++(UInt3 a) {
			return (UInt3)(((byte)a)+1);
		}
		#endregion

		#region conversions
		public static implicit operator byte(UInt3 n) {
			byte v = 0;
			if(n.Bit0) v += 1;
			if(n.Bit1) v += 2;
			if(n.Bit2) v += 4;
			return v;
		}

		public static explicit operator UInt3(byte n) {
			if(n > 7) throw new OverflowException("Value too high");
			return new UInt3(n.GetBit(2), n.GetBit(1), n.GetBit(0));
		}
		#endregion
	}
}
