using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the bit of a Parameter
	/// </summary>
	public class ParameterBitOperand:ParameterOperand {
		public byte Bit;

		public ParameterBitOperand(Parameter ReferencedParameter, byte Bit)
			: base(ReferencedParameter) {
			this.Bit = Bit;
		}

		public override string ToString() {
			return string.Format("[ParameterBit]{0}<bit {1}>", TheParameter.ToString(), Bit);
		}
	}
}
