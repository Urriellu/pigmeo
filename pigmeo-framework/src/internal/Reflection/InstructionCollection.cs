using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a collection of CIL Instructions
	/// </summary>
	public class InstructionCollection:List<Instruction> {
		/// <summary>
		/// Creates a new collection of methods with the given default capacity
		/// </summary>
		/// <param name="Capacity">Default capacity. This collection will automatically resize itself when needed</param>
		public InstructionCollection(int Capacity) : base(Capacity) { }

		/// <summary>
		/// Indicates if any of the instructions in this collection has a given OpCode
		/// </summary>
		public bool ContainsOpCode(OpCodes OpCode) {
			ShowExternalInfo.InfoDebug("Checking if there is any instruction in this InstructionCollection with OpCode {0}", OpCode.ToString());
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].OpCode == OpCode) return true;
			}
			return false;
		}
	}
}
