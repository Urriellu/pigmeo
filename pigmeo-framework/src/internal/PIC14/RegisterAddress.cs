namespace Pigmeo.Internal.PIC14 {
	public class RegisterAddress {
		public bool undefined;
		public byte bank;
		public byte Address;

		public RegisterAddress() {
			undefined = true;
		}

		public RegisterAddress(byte bank, byte Address) {
			this.bank = bank;
			this.Address = Address;
		}
	}
}
