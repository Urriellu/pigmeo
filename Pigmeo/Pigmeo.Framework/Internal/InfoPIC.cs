using System;
using System.Collections.Generic;
using Pigmeo.Internal.PIC;

namespace Pigmeo.Internal {
	/// <summary>
	/// Contains all the required information about a Microchip PIC
	/// </summary>
	public class InfoPIC:InfoDevice {
		/// <summary>
		/// Assembly-language header file used for assembling to generate machine code for this microcontroller
		/// </summary>
		public string IncludeFile;

		/// <summary>
		/// RAM/data memory banks. Each index in the array represents a bank
		/// </summary>
		public DataMemoryBank[] DataMemory;

		/// <summary>
		/// Max amount of words/instructions stored in the program memory
		/// </summary>
		public UInt16 MaxWords;

		/// <summary>
		/// Number of Configuration Words (where the Configuration Bits are stored)
		/// </summary>
		public byte ConfigWords = 1;

		/// <summary>
		/// Total amount of RAM available for General Purpose Registers, in bytes
		/// </summary>
		public UInt16 GprSize {
			get {
				UInt16 total = 0;
				foreach(DataMemoryBank bank in DataMemory) {
					total += bank.GprSize;
				}
				return total;
			}
		}

		/// <summary>
		/// Total amount of RAM reserved for Special Function Registers
		/// </summary>
		public UInt16 SfrSize {
			get {
				UInt16 total = 0;
				foreach(DataMemoryBank bank in DataMemory) {
					total += bank.SfrSize;
				}
				return total;
			}
		}

		/// <summary>
		/// Total amount of RAM available in this device
		/// </summary>
		public UInt16 TotalRAM {
			get {
				return (UInt16)(GprSize + SfrSize);
			}
		}

		public override byte PointerSize {
			get {
				return 1;
			}
		}

		public override byte NativeIntSize {
			get {
				return 1;
			}
		}
	}
}
