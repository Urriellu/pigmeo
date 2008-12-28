using System;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which references a Method Parameter
	/// </summary>
	/// <remarks>
	/// ParameterValueOperand, ParameterBitOperand, ParameterAddrOperand... they all derive from ParameterOperand because they all get "something" from a Parameter
	/// </remarks>
	public abstract class ParameterOperand:Operand {
		public Parameter TheParameter;

		public ParameterOperand(Parameter ReferencedParameter) {
			this.TheParameter = ReferencedParameter;
		}
	}
}
