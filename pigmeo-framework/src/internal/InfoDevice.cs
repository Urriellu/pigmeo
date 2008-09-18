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

	public class InfoPIC14:InfoDevice {
		public string IncludeFile;

		/// <summary>
		/// RAM/data memory banks. Each index in the array represents a bank
		/// </summary>
		public DataMemoryBankPIC[] DataMemory;

		/// <summary>
		/// Max amount of words/instructions stored in the program memory
		/// </summary>
		public UInt16 MaxWords;

		public InfoPIC14() { }

		/// <summary>
		/// Total amount of RAM available for General Purpose Registers
		/// </summary>
		public UInt16 GprSize {
			get {
				UInt16 total = 0;
				foreach(DataMemoryBankPIC bank in DataMemory) {
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
				foreach(DataMemoryBankPIC bank in DataMemory) {
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
	}
}
