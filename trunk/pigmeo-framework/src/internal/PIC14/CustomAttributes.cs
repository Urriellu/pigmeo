using System;

namespace Pigmeo.Internal.PIC14 {
	//NOTE: attributes used internally by PIC14 devices, not by users nor other architectures or branches

	[AttributeUsage(AttributeTargets.Field)]
	public class Location:Attribute {
		public readonly RegisterAddress address;

		public Location(byte bank, byte address) {
			this.address = new RegisterAddress(bank, address);
		}
	}
}
