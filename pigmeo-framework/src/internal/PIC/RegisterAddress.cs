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
	}
}
