using Pigmeo;
using Pigmeo.Internal;

[assembly: DeviceLibrary(Architecture.PIC, Family.PIC14, Branch.PIC16F887)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC GetInfo() {
			InfoPIC device = new InfoPIC();

			device.arch = Architecture.PIC;
			device.family = Family.PIC14;
			device.branch = Branch.PIC16F887;
			device.DataMemory = new DataMemoryBankPIC[4];
			device.DataMemory[0].FirstSFR = 0x00;
			device.DataMemory[0].LastSFR = 0x1F;
			device.DataMemory[0].FirstGPR = 0x20;
			device.DataMemory[0].LastGPR = 0x7F;
			device.DataMemory[1].FirstSFR = 0x00;
			device.DataMemory[1].LastSFR = 0x1F;
			device.DataMemory[1].FirstGPR = 0x20;
			device.DataMemory[1].LastGPR = 0x3F;
			device.DataMemory[2].FirstSFR = 0x00;
			device.DataMemory[2].LastSFR = 0x0F;
			device.MaxWords = 8192;
			device.IncludeFile = "p16f887.inc";

			return device;
		}
	}
}