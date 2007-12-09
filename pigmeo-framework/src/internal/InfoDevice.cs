using Mono.Cecil;
using System;
using Pigmeo;

namespace Pigmeo.Internal {
	/// <summary>
	/// Contains all the required information about one device, one branch from one architecture
	/// </summary>
	/// <remarks>
	/// This information is retrieved from the library of the specified branch. For example if you want information about the PIC16F716 a InfoDevice object is instantiated as 'new InfoDevice("PIC16F716")', the library PIC16F716.dll is loaded using reflection and the information is retrieved from that library.</remarks>
	public abstract class InfoDevice {
		/// <summary>
		/// The target architecture (PIC16, PIC18, dsPIC...)
		/// </summary>
		public Architecture arch;
		public Branch branch;
	}

	public class InfoPIC8bit:InfoDevice {
		/// <summary>
		/// RAM/data memory banks. Each index in the array represents a bank
		/// </summary>
		public DataMemoryBankPIC[] DataMemory;

		/// <summary>
		/// Max amount of words/instructions stored in the program memory
		/// </summary>
		public UInt16 MaxWords;

		public InfoPIC8bit() { }



		/// <summary>
		/// Amount of bytes available for being used as general purpose registers (8-bit variables)
		/// </summary>
		public UInt16 RamSize {
			get {
				UInt16 size = 0;
				foreach(DataMemoryBankPIC bank in DataMemory) {
					size += (UInt16)(bank.LastGPR - bank.FirstGPR + 1);
				}
				return size;
			}
		}
	}
}
