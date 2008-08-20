using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Reflection;
using Pigmeo.Physics;

[assembly: AssemblyVersion("0.1")]
[assembly: DeviceLibrary(Architecture.PIC14, Branch.PIC16F59)]
[assembly: AssemblyKeyFile("pigmeo.key")]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC8bit GetInfo() {
			InfoPIC8bit device = new InfoPIC8bit();

			device.arch = Architecture.PIC14;
			device.branch = Branch.PIC16F59;
			device.DataMemory = new DataMemoryBankPIC[2];
			/*device.DataMemory[0].FirstSFR = 0x00;
			device.DataMemory[0].LastSFR = 0x1F;
			device.DataMemory[0].FirstGPR = 0x20;
			device.DataMemory[0].LastGPR = 0x7F;
			device.DataMemory[1].FirstSFR = 0x00;
			device.DataMemory[1].LastSFR = 0x1F;
			device.DataMemory[1].FirstGPR = 0x20;
			device.DataMemory[1].LastGPR = 0x3F;
			device.MaxWords = 2048;*/
			device.IncludeFile = "p16f59.inc";

			return device;
		}
	}

	public static class Registers {
		[AsmName("PORTA"), Location(0, 0x05)]
		public static byte PORTA = 0;
	}
}
