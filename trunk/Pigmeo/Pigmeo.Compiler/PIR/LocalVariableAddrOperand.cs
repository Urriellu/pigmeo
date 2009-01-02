using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the address of a Local Variable
	/// </summary>
	public class LocalVariableAddrOperand:LocalVariableOperand {
		public LocalVariableAddrOperand(LocalVariable ReferencedLV)
			: base(ReferencedLV) {
		}

		public override string ToString() {
			return string.Format("[LocalVariableAddress]{0}", TheLV.ToString());
		}
	}
}
