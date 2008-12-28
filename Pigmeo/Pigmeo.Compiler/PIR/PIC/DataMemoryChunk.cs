using System;
using Pigmeo.Internal.PIC;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents a portion of memory. This is a collection of consecutive registers
	/// </summary>
	public class DataMemoryChunk {
		public Location FirstRegister;
		public Location LastRegister;

		public DataMemoryChunk(Location FirstRegister, Location LastRegister) {
			if(FirstRegister == null || LastRegister == null) throw new ArgumentNullException();
			if(FirstRegister.Address.Bank != LastRegister.Address.Bank) throw new ArgumentOutOfRangeException("Both registers must belong to the same bank");

			this.FirstRegister = FirstRegister;
			this.LastRegister = LastRegister;
		}

		public UInt16 Size {
			get {
				return (UInt16)(LastRegister.Address.Address - FirstRegister.Address.Address + 1);
			}
		}

		/// <summary>
		/// Indicates if the given Location is contained in thie chunk
		/// </summary>
		public bool Contains(Location Location) {
			if(FirstRegister.Address.Bank != Location.Address.Bank) return false;
			if(Location.Address.Address < FirstRegister.Address.Address) return false;
			if(Location.Address.Address > LastRegister.Address.Address) return false;
			return true;
		}
	}
}
