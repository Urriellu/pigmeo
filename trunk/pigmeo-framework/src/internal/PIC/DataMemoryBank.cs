namespace Pigmeo.Internal.PIC {
	/// <summary>
	/// Represents ONE bank of data (RAM) memory
	/// </summary>
	public struct DataMemoryBank {
		/// <summary>
		/// Position of the first Special Function Register, the part of the RAM where internal registers (such as OPTION_REG, PORTA, STATUC, INTCON...) are stored. Usually 0x00
		/// </summary>
		public byte FirstSFR;

		/// <summary>
		/// Position of the last Special Function Register. Usually 0x1F
		/// </summary>
		public byte LastSFR;

		/// <summary>
		/// Position of the first General Purpose Register, the part of the RAM where variables defined by the user are stored. Usually 0x20
		/// </summary>
		public byte FirstGPR;

		/// <summary>
		/// Position of the first General Purpose Register
		/// </summary>
		public byte LastGPR;

		/*/// <summary>
		/// Creates a new instance of DataMemoryBankPIC struct
		/// </summary>
		/// <param name="FirstSFR">Position of the first Special Function Register, the part of the RAM where internal registers (such as OPTION_REG, PORTA, STATUC, INTCON...) are stored. Usually 0x00</param>
		/// <param name="LastSFR">Position of the last Special Function Register. Usually 0x1F</param>
		/// <param name="FirstGPR">Position of the first General Purpose Register, the part of the RAM where variables defined by the user are stored. Usually 0x20</param>
		/// <param name="LastGPR">Position of the first General Purpose Register</param>
		public DataMemoryBankPIC(byte FirstSFR, byte LastSFR, byte FirstGPR, byte LastGPR) {
			this.FirstSFR = FirstSFR;
			this.LastSFR = LastSFR;
			this.FirstGPR = FirstGPR;
			this.LastGPR = LastGPR;
		}*/

		/// <summary>
		/// Amount of RAM available for General Purpose Registers
		/// </summary>
		public byte GprSize {
			get {
				if(LastGPR == FirstGPR) return 0;
				return (byte)(LastGPR - FirstGPR + 1);
			}
		}

		/// <summary>
		/// Amount of RAM reserved for Special Function Registers
		/// </summary>
		public byte SfrSize {
			get {
				if(LastSFR == FirstSFR) return 0;
				return (byte)(LastSFR - FirstSFR + 1);
			}
		}

		/// <summary>
		/// Total amount of memory available in this bank
		/// </summary>
		public byte Size {
			get {
				return (byte)(GprSize + SfrSize);
			}
		}
	}
}
