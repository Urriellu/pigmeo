﻿using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC;

[assembly: DeviceLibrary(Architecture.PIC, Family.PIC14, Branch.PIC16F887)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC GetInfo() {
			InfoPIC device = new InfoPIC();

			device.Architecture = Architecture.PIC;
			device.Family = Family.PIC14;
			device.Branch = Branch.PIC16F887;
			device.DataMemory = new DataMemoryBank[4];
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
			device.DataMemory[3].FirstSFR = 0x00;
			device.DataMemory[3].LastSFR = 0x0D;
			device.MaxWords = 8192;
			device.IncludeFile = "p16f887.inc";

			return device;
		}
	}

	public static class Ports {
		public static PORTA A = new PORTA();
		public static PORTB B = new PORTB();
		public static PORTD D = new PORTD();
	}
}