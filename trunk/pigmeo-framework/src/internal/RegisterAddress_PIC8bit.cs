namespace Pigmeo.Internal {
	public class RegisterAddress_PIC8bit {
		public byte bank;
		public byte Address;

		public RegisterAddress_PIC8bit(byte bank, byte Address) {
			this.bank = bank;
			this.Address = Address;
		}
	}
}
