using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Reflection;
using Pigmeo.Physics;

[assembly: DeviceLibrary(Architecture.PIC14, Branch.PIC16F887)]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC14 GetInfo() {
			InfoPIC14 device = new InfoPIC14();

			device.arch = Architecture.PIC14;
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