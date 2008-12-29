using System;
namespace Pigmeo.Internal.PIC {
	public class RegisterAddress {
		public bool Undefined;
		public byte Bank;
		public byte Address;
		public byte Bit;

		public RegisterAddress() {
			Undefined = true;
		}

		public RegisterAddress(byte Bank, byte Address) {
			this.Bank = Bank;
			this.Address = Address;
			this.Bit = 0;
		}

		public RegisterAddress(byte Bank, byte Address, byte Bit) {
			this.Bank = Bank;
			this.Address = Address;
			this.Bit = Bit;
		}

		/// <summary>
		/// The full address of this register. For example if OPTION_REG is at 0x01 on bank 1 (the second bank), its FullAddress is 0x81; if TMR0 is at 0x01 on bank 2 its FullAddress is 0x101
		/// </summary>
		public UInt16 FullAddress {
			get {
				//return (UInt16)(Address + ((UInt16)Bank) << 7);
				return (UInt16)(128 * Bank + Address);
			}
		}
	}
}
