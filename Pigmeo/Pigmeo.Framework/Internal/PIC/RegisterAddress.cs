using System;
namespace Pigmeo.Internal.PIC {
	/// <summary>
	/// Represents the address of a register stored in the microcontroller's RAM
	/// </summary>
	public class RegisterAddress {
		/// <summary>
		/// The address in undefined
		/// </summary>
		public bool Undefined;

		/// <summary>
		/// Bank memory where it's stored
		/// </summary>
		public byte Bank;

		/// <summary>
		/// Address relative to the memory bank in which it is stored
		/// </summary>
		public byte Address;

		/// <summary>
		/// If this is the address of a single bit, this indicates the position of that bit in the given register
		/// </summary>
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
				return (UInt16)(128 * Bank + Address);
			}
		}
	}
}
