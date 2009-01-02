using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is the address of a Parameter
	/// </summary>
	public class ParameterAddrOperand:ParameterOperand {
		public ParameterAddrOperand(Parameter ReferencedParam)
			: base(ReferencedParam) {
		}

		public override string ToString() {
			return string.Format("[ParameterAddress]{0}", TheParameter.ToString());
		}
	}
}
