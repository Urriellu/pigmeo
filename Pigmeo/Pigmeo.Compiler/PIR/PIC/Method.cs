using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR.PIC {
	public class Method:PIR.Method {
		/// <summary>
		/// Make operations use the PIC Working Register (W)
		/// </summary>
		public bool MakeOperationsUseW() {
			bool MethodModified = false;
			bool CurrOpModified;

			do {
				CurrOpModified = false;

				foreach(Operation CurrOp in Operations) {
					#region convert "8bitField:=operand1+operand2", being both operands 8-bit variables or constants
					if(CurrOp is Add && CurrOp.Result is FieldValueOperand && (CurrOp.Result as FieldValueOperand).TheField.Size == 1 && ((CurrOp.Arguments[0] is FieldValueOperand && (CurrOp.Arguments[0] as FieldValueOperand).TheField.Size == 1) || CurrOp.Arguments[0] is ConstantInt32Operand) && ((CurrOp.Arguments[1] is FieldValueOperand && (CurrOp.Arguments[1] as FieldValueOperand).TheField.Size == 1) || CurrOp.Arguments[1] is ConstantInt32Operand)) {
						//avoid doing it if it's a "Field++;"
						if(CurrOp.Result == CurrOp.Arguments[0] && CurrOp.Arguments[1] is ConstantInt32Operand && (CurrOp.Arguments[1] as ConstantInt32Operand).Value == 1) continue;

						ShowInfo.InfoDebug("Converting \"{0}\" to W:=operand1 ; W:=W+operand2 ; Destination:=W", CurrOp);
						Operation FirstOp = new Copy(this, CurrOp.Arguments[0], GlobalOperands.W);
						Operation SecondOp = new Add(this, GlobalOperands.W, GlobalOperands.W, CurrOp.Arguments[1]);
						Operation ThirdOp = new Copy(this, GlobalOperands.W, CurrOp.Result);
						Operations[Operations.IndexOf(CurrOp)] = FirstOp;
						Operations.InsertAfter(FirstOp, SecondOp);
						Operations.InsertAfter(SecondOp, ThirdOp);

						MethodModified = CurrOpModified = true;
						ShowInfo.InfoDebug("Converted to {0} followed by {1} and then by {2}", FirstOp, SecondOp, ThirdOp);
						break;
					}
					#endregion

					#region convert "[Field]SomeField := something" (except "[Field]SomeField := [RegisterOperand]W") to "[RegisterOperand]W := something" plus "[Field]SomeField := [RegisterOperand]W"
					if(CurrOp.Result is FieldValueOperand && !(CurrOp is Copy && CurrOp.Arguments[0] == GlobalOperands.W) && (CurrOp.Result as FieldValueOperand).TheField.Size == 1) {
						ShowInfo.InfoDebug("Converting \"{0}\" to \"[RegisterOperand]W := something\" plus \"[Field]SomeField := [RegisterOperand]W\"", CurrOp);
						FieldValueOperand DestinationField = CurrOp.Result as FieldValueOperand;
						CurrOp.Result = GlobalOperands.W;

						Operation MoveWtoField = new Copy(this, GlobalOperands.W, DestinationField);
						Operations.InsertAfter(CurrOp, MoveWtoField);

						MethodModified = CurrOpModified = true;
						ShowInfo.InfoDebug("Converted to {0} followed by {1}", CurrOp, MoveWtoField);
						break;
					}
					#endregion
				}
			} while(CurrOpModified);

			return MethodModified;
		}
	}
}
