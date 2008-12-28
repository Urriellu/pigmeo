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
				AsmCode Code = new AsmCode();
				Code.Add(new Label(CallToInlinedInternalImpl.AsmLabel, "Delaying " + (CallToInlinedInternalImpl.Arguments[1] as PIR.ConstantInt32Operand).Value + " instructions"));
				Code.Add(Nop__Int32(CallToInlinedInternalImpl, CalledMethod, CallArguments));
				return Code;
			} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0009", false, CalledMethod.ToStringRetTypeNameArgs());
			return null;
		}


		private static void CheckConstantOperands(Method CalledMethod, PIR.Operand[] Operands) {
			foreach(PIR.Operand Operand in Operands) {
				bool valid = false;

				if(Operand is PIR.ConstantInt32Operand) valid = true;

				if(!valid) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0010", false, CalledMethod.ToStringRetTypeNameArgs());
			}
		}

		private static AsmCode Nop__Int32(PIR.Call CallOperation, Method CalledMethod, PIR.Operand[] Operands) {
			CheckConstantOperands(CalledMethod, Operands);
			int NopCount = (Operands[0] as PIR.ConstantInt32Operand).Value;
			if(NopCount <= 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0011", false, CalledMethod.ToStringRetTypeNameArgs());
			return GenerateNops(CallOperation.AsmLabel + "_", (Int64)NopCount);
		}

		private static AsmCode GenerateNops(string LabelsPrefix, Int64 Count) {
			AsmCode Code = new AsmCode();

			if(Count == 1) Code.Add(new NOP("", ""));
			else if(Count == 2) Code.Add(new GOTO("", "$+1", ""));
			else if(Count > 2 && Count <= 10) {
				Int64 NopCount;
				Int64 GotoNextCount = Math.DivRem(Count, 2, out NopCount);
				for(int i = 0 ; i < GotoNextCount ; i++) Code.Add(new GOTO("", "$+1", ""));
				if(NopCount == 1) Code.Add(new NOP("", ""));
			} else if(Count > 10 && (Count-1)/6 <= 255) {
				//Count=Loops*6+1 -> Loops=(Count-1)/6. Max Count == 1531
				Code.Add(new MOVLW("", (byte)((Count-1)/6), "Load amount of loops to do"));
				Code.Add(new ADDLW(LabelsPrefix + "loop01", 255, "decrement W"));
				Code.Add(new GOTO("", "$+1", ""));
				Code.Add(new BTFSS("", "STATUS", "Z", ""));
				Code.Add(new GOTO("", LabelsPrefix + "loop01", ""));
			} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0011", false, "Too many NOPs");

			return Code;
		}
	}
}
