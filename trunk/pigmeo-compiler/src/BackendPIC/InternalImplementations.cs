using System;
using Pigmeo.Compiler.PIR.PIC;

namespace Pigmeo.Compiler.BackendPIC {
	public static class InternalImplementations {
		/// <summary>
		/// Gets the code to replace a call to an InLine internally-implemented method
		/// </summary>
		public static AsmCode GetInlinedInternalImplementation(PIR.Call CallToInlinedInternalImpl) {
			Method CalledMethod = (CallToInlinedInternalImpl.Arguments[0] as PIR.MethodOperand).TheMethod as Method;
			PIR.Operand[] CallArguments = new PIR.Operand[CallToInlinedInternalImpl.Arguments.Length - 1];
			for(int i = 0 ; i < CallArguments.Length ; i++) CallArguments[i] = CallToInlinedInternalImpl.Arguments[i + 1];

			if(!CalledMethod.IsInternalImpl) throw new ArgumentException("Called method is not an internal implementation");
			if(!CalledMethod.InLine) throw new ArgumentException("Called method is not InLine");

			//check if the method is properly called
			if(CallArguments.Length > UInt16.MaxValue || CallArguments.Length != CalledMethod.Parameters.Count) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", false, "Calling arguments do NOT correspond to callee parameters");

			if(CalledMethod.ParentType.Name == "Pigmeo.MCU.Processor" && CalledMethod.Name == "Nop" && CalledMethod.Parameters.Count == 1 && CalledMethod.Parameters[0].ParamType.Name == "System.Int32") {
				return Nop__Int32(CallArguments);
			} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0009", false, CalledMethod.ToStringRetTypeNameArgs());
			return null;
		}

		private static AsmCode Nop__Int32(PIR.Operand[] Operands) {
			AsmCode Code = new AsmCode();
			Code.Add(new NOP("", "")); Code.Add(new NOP("", "")); Code.Add(new NOP("", "")); Code.Add(new NOP("", "")); Code.Add(new NOP("", ""));
			return Code;
		}
	}
}
