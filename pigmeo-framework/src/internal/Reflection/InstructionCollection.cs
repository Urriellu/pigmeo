using System;
using System.Collections.Generic;

namespace Pigmeo.Internal.Reflection {
	public class InstructionCollection:List<Instruction> {
		public InstructionCollection(int Capacity) : base(Capacity) { }

		public bool ContainsOpCode(OpCodes OpCode) {
			ShowExternalInfo.InfoDebug("Checking if there is any instruction in this InstructionCollection with OpCode {0}", OpCode.ToString());
			for(int i = 0 ; i < this.Count ; i++) {
				if(this[i].OpCode == OpCode) return true;
			}
			return false;
		}
	}
}
