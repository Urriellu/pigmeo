using Pigmeo.Internal.PIC;
using System.Collections.Generic;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents the static memory of a PIC. This is, the portion of its Data Memory (RAM) used by static variables/fields
	/// </summary>
	public class StaticMemory:DataMemoryType {
		public StaticMemory(Program ParentProgram)
			: base(ParentProgram) {
		}

		/// <summary>
		/// Generates a used memory map. Each index in the collection represents a memory chunk. Each chunk has a bool array that represents the state of each of its locations. True=occupied/used, False=empty/free
		/// </summary>
		/// <remarks>
		/// We need to generate this map on each call because the location of fields in ParentProgram can change. Make sure you store this map on a local variable if you are accessing it multiple times
		/// </remarks>
		public List<bool[]> UsedMemoryMap {
			get {
				//initialize the map as completely free
				List<bool[]> Map = new List<bool[]>(Chunks.Count);
				for(int i = 0 ; i < Chunks.Count ; i++) {
					Map.Add(new bool[Chunks[i].Size]);
					//for(int j = 0 ; j < Chunks[i].Size ; j++) Map[i][j] = false;
				}

				//find used memory
				foreach(Type T in ParentProgram.Types) {
					foreach(Field F in T.Fields) {
						if(F.IsStatic && !F.Location.DefinedInHeader && !F.Location.Address.Undefined) {
							int? ChunkBelongs = null; //chunk this field belongs to
							for(int i = 0 ; i < Chunks.Count ; i++) {
								if(Chunks[i].Contains(F.Location)) ChunkBelongs = i;
							}
							if(!ChunkBelongs.HasValue) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", false, string.Format("Cannot find the chunk (in Static Memory) the field {0} belongs to", F.ToStringTypeAndName()));

							//set as occupied
							for(int j = 0 ; j < F.Size ; j++) Map[ChunkBelongs.Value][j + F.Location.Address.Address - Chunks[ChunkBelongs.Value].FirstRegister.Address.Address] = true;
						}
					}
				}
				return Map;
			}
		}

		/// <summary>
		/// Gets a Location reference to a portion of free Static Memory of the given size
		/// </summary>
		/// <param name="size">Amount of bytes required</param>
		/// <returns>Reference to the first GPR allocated</returns>
		public Location Allocate(byte size) {
			Location AllocatedMem = null;

			List<bool[]> UsedRegisters = UsedMemoryMap;

			foreach(string line in ToStringUsedMemoryMap(UsedRegisters)) ShowInfo.InfoDebug(line);

			for(int CurrentChunkId = 0 ; CurrentChunkId < Chunks.Count && AllocatedMem == null ; CurrentChunkId++) {
				DataMemoryChunk CurrentChunk = Chunks[CurrentChunkId];
				bool[] CurrentChunkUsedMemoryMap = UsedRegisters[CurrentChunkId];
				int FirstFreeLocation = 0;
				while(FirstFreeLocation < CurrentChunkUsedMemoryMap.Length && CurrentChunkUsedMemoryMap[FirstFreeLocation] == true) FirstFreeLocation++;
				if(FirstFreeLocation <= CurrentChunkUsedMemoryMap.Length - size) { 
					//there is enough memory
					AllocatedMem = new Location(CurrentChunk.FirstRegister.Address.Bank, (byte)(CurrentChunk.FirstRegister.Address.Address + FirstFreeLocation));
				}
			}
			if(AllocatedMem == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0008", false, string.Format("Cannot allocate {0} bytes in the Static Memory of Size {1}", size, Size));
			return AllocatedMem;
		}

		public string[] ToStringUsedMemoryMap(List<bool[]> UsedMemoryMap) {
			string[] output = new string[UsedMemoryMap.Count];
			for(int i = 0 ; i < UsedMemoryMap.Count ; i++) {
				output[i] = "Chunk #" + i + ": ";
				foreach(bool b in UsedMemoryMap[i]) {
					output[i] += (b) ? "1" : "0";
				}
			}
			return output;
		}
	}
}
