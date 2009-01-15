using System;
using Pigmeo.Compiler.PIR;
using System.Collections.Generic;
using Pigmeo.Internal.PIC;

namespace Pigmeo.Compiler.PIR.PIC {
	public abstract class DataMemoryType {
		public PIC.Program ParentProgram;

		/// <summary>
		/// Amount of registers assigned to this type of memory. Null if automatic
		/// </summary>
		public UInt32? AssignedRegisters = null;

		public UInt32 Size {
			get {
				UInt32 s = 0;
				foreach(DataMemoryChunk chunk in Chunks) {
					s += chunk.Size;
				}
				return s;
			}
		}

		/// <summary>
		/// The size of this type of memory respect the full amount of GPRs
		/// </summary>
		public float Percent {
			get {
				return (float)Size / (float)ParentProgram.Target.GprSize * 100;
			}
		}

		public float UsedPercent {
			get {
				if(!AssignedRegisters.HasValue) return 100f;
				return (float)AssignedRegisters.Value / (float)Size;
			}
		}

		public float FreePercent {
			get {
				return 100 - UsedPercent;
			}
		}


		/// <summary>
		/// Assign all General Purpose Registers in the PIC Data Memory to this type of data memory
		/// </summary>
		public void AssignAllGpr() {
			Chunks.Clear();
			for(int i = 0 ; i < ParentProgram.Target.DataMemory.Length ; i++) {
				Internal.PIC.DataMemoryBank CurrentBank = ParentProgram.Target.DataMemory[i];
				if(CurrentBank.FirstGPR != CurrentBank.LastGPR) {
					Location FirstGprInBank = new Location((byte)i, CurrentBank.FirstGPR);
					Location LastGprInBank = new Location((byte)i, CurrentBank.LastGPR);
					DataMemoryChunk ThisChunk = new DataMemoryChunk(FirstGprInBank, LastGprInBank);
					Chunks.Add(ThisChunk);
				} //else there are no GPR
			}
			AssignedRegisters = Size;
		}

		/// <summary>
		/// Stores the pairs of addresses that represent the begin and end of a RAM portion assigned to Static Memory. For example
		/// </summary>
		public List<DataMemoryChunk> Chunks = new List<DataMemoryChunk>(4);

		public DataMemoryType(PIC.Program ParentProgram) {
			this.ParentProgram = ParentProgram;
		}
	}
}
