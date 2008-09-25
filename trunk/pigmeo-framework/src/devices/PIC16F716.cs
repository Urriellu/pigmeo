using Pigmeo;
using Pigmeo.Internal;

[assembly: DeviceLibrary(Architecture.PIC, Family.PIC14, Branch.PIC16F716)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC GetInfo() {
			InfoPIC device = new InfoPIC();

			device.arch = Architecture.PIC;
			device.family = Family.PIC14;
			device.branch = Branch.PIC16F716;
			device.DataMemory = new DataMemoryBankPIC[2];
			device.DataMemory[0].FirstSFR = 0x00;
			device.DataMemory[0].LastSFR = 0x1F;
			device.DataMemory[0].FirstGPR = 0x20;
			device.DataMemory[0].LastGPR = 0x7F;
			device.DataMemory[1].FirstSFR = 0x00;
			device.DataMemory[1].LastSFR = 0x1F;
			device.DataMemory[1].FirstGPR = 0x20;
			device.DataMemory[1].LastGPR = 0x3F;
			device.MaxWords = 2048;
			device.IncludeFile = "p16f716.inc";

			return device;
		}
	}

	public static class Ports {
		public static PORTA A = new PORTA();
		public static PORTB B = new PORTB();
	}

	public static class Timers {
		public static TMR0 Timer0 = new TMR0();
	}
}
