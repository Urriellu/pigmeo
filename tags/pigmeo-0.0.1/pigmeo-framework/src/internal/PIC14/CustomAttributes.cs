using System;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.PIC14 {
	//NOTE: attributes used internally by PIC14 devices, not by users nor other architectures or branches

	[AttributeUsage(AttributeTargets.Field)]
	public class Location:Attribute {
		public readonly RegisterAddress Address;

		public Location(byte Bank, byte Address) {
			this.Address = new RegisterAddress(Bank, Address);
		}

		public Location(byte Bank, byte Address, byte Bit) {
			this.Address = new RegisterAddress(Bank, Address, Bit);
		}
	}
}
