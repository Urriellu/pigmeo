using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the value of a Parameter
	/// </summary>
	/// <remarks>
	/// Operations that have this operand are working with the value contained in this Parameter. If you need to get a Parameter's address or the value of one of its bits, use ParameterBitOperand or ParameterAddrOperand instead
	/// </remarks>
	public class ParameterValueOperand:ParameterOperand {
		public ParameterValueOperand(Parameter ReferencedParameter)
			: base(ReferencedParameter) {
		}

		public override string ToString() {
			return string.Format("[ParameterValue]{0}", TheParameter.ToString());
		}
	}
}
