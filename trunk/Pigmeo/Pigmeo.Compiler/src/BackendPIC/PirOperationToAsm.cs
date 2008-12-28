using Pigmeo.Compiler.PIR.PIC;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Methods that convert PIR Operations to PIC Assembly Language
	/// </summary>
	public static class PirOperationToAsm {
		public static AsmCode GetCodeFromOperation(PIR.Operation O) {
			ShowInfo.InfoDebug("Converting the PIR Operation \"{0}\" to PIC assembly language source code", O);
			AsmCode Code = new AsmCode();

			if(O is PIR.Copy) {
				// W:=constant
				if(O.Arguments[0] is PIR.ConstantInt32Operand && O.Result == GlobalOperands.W) Code.Add(new MOVLW(O.AsmLabel, (byte)((O.Arguments[0] as PIR.ConstantInt32Operand).Value), ""));

				// W:=8bitField
				if(O.Arguments[0] is PIR.FieldOperand && (O.Arguments[0] as PIR.FieldOperand).TheField.Size == 1 && O.Result == GlobalOperands.W) Code.Add(new MOVF(O.AsmLabel, (O.Arguments[0] as PIR.FieldOperand).TheField.AsmName, Destination.W, ""));

				// 8bitField:=W
				if(O.Arguments[0] == GlobalOperands.W && O.Result is PIR.FieldOperand && (O.Result as PIR.FieldOperand).TheField.Size == 1) Code.Add(new MOVWF(O.AsmLabel, (O.Result as PIR.FieldOperand).TheField.AsmName, ""));
			} else if(O is PIR.Add) {
				if(O.Arity != 2) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false, "Invalid addition arity: " + O.Arity);

				// W:=W+8bitField
				if(O.Arguments[0] == GlobalOperands.W && O.Result == GlobalOperands.W && O.Arguments[1] is PIR.FieldOperand && (O.Arguments[1] as PIR.FieldOperand).TheField.Size == 1) Code.Add(new ADDWF(O.AsmLabel, (O.Arguments[1] as PIR.FieldOperand).TheField.AsmName, Destination.W, ""));

				// W:=W+constant
				if(O.Arguments[0] == GlobalOperands.W && O.Result == GlobalOperands.W && O.Arguments[1] is PIR.ConstantInt32Operand) Code.Add(new ADDLW(O.AsmLabel, (byte)((O.Arguments[1] as PIR.ConstantInt32Operand).Value), ""));
			}else if(O is PIR.Jump){
				Code.Add(new GOTO(O.AsmLabel, (O.Arguments[0] as PIR.OperationOperand).TheOperation.AsmLabel, ""));
			} else if(O is PIR.Return) {
				if(O.ParentMethod.IsEntryPoint) Code.Add(new GOTO(O.AsmLabel, "EndOfApp", ""));
			}

			if(Code.Instructions.Count == 0) {
				Code.Add(new Label(O.AsmLabel, O.ToString() + "    NOT IMPLEMENTED!!!"));
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false, "Convert \"" + O.ToString() + "\" to PIC assembly language");
			}

			ShowInfo.InfoDebugDecompile("PIR Operation: \"" + O.ToString() + "\"", Code);
			return Code;
		}
	}
}
