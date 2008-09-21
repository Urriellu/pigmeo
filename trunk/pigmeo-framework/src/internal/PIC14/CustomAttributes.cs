using System;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.PIC14 {
	//NOTE: attributes used internally by PIC14 devices, not by users nor other architectures or branches

	[AttributeUsage(AttributeTargets.Field)]
	public class Location:Attribute {
		public readonly RegisterAddress Address = new RegisterAddress();
		public readonly bool DefinedInHeader;

		public Location(byte Bank, byte Address) {
			this.Address.Bank = Bank;
			this.Address.Address = Address;
			DefinedInHeader = false;
		}

		public Location(byte Bank, byte Address, byte Bit) {
			this.Address.Bank = Bank;
			this.Address.Address = Address;
			this.Address.Bit = Bit;
			DefinedInHeader = false;
		}

		public Location(bool DefinedInHeader) {
			this.DefinedInHeader = DefinedInHeader;
		}
	}
}
