using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Reflection;
using Pigmeo.Physics;

[assembly: DeviceLibrary(Architecture.PIC14, Branch.PIC16F59)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC8bit GetInfo() {
			InfoPIC8bit device = new InfoPIC8bit();

			device.arch = Architecture.PIC14;
			device.branch = Branch.PIC16F59;
			device.DataMemory = new DataMemoryBankPIC[8];
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
