using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC;

[assembly: DeviceLibrary(Architecture.PIC, Family.PIC14, Branch.PIC16F59)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		/// <summary>
		/// Gets all the information about this PIC
		/// </summary>
		public static InfoPIC GetInfo() {
			InfoPIC device = new InfoPIC();

			device.Architecture = Architecture.PIC;
			device.Family = Family.PIC14;
			device.Branch = Branch.PIC16F59;
			device.DataMemory = new DataMemoryBank[8];
			device.DataMemory[0].FirstSFR = 0x00;
			device.DataMemory[0].LastSFR = 0x09;
			device.DataMemory[0].FirstGPR = 0x0A;
			device.DataMemory[0].LastGPR = 0x1F;
			device.DataMemory[1].FirstGPR = 0x10;
			device.DataMemory[1].LastGPR = 0x1F;
			device.DataMemory[2].FirstGPR = 0x10;
			device.DataMemory[2].LastGPR = 0x1F;
			device.DataMemory[3].FirstGPR = 0x10;
			device.DataMemory[3].LastGPR = 0x1F;
			device.DataMemory[4].FirstGPR = 0x10;
			device.DataMemory[4].LastGPR = 0x1F;
			device.DataMemory[5].FirstGPR = 0x10;
			device.DataMemory[5].LastGPR = 0x1F;
			device.DataMemory[6].FirstGPR = 0x10;
			device.DataMemory[6].LastGPR = 0x1F;
			device.DataMemory[7].FirstGPR = 0x10;
			device.DataMemory[7].LastGPR = 0x1F;
			device.MaxWords = 2048;
			device.IncludeFile = "p16f59.inc";

			return device;
		}
	}
}
