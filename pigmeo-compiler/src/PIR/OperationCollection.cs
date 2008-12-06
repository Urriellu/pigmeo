using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public class OperationCollection:List<Operation> {
		public void InsertBefore(Operation NextOperation, Operation Item) {
			if(!Contains(NextOperation)) throw new ArgumentException("NextOperation couldn't be found in this collection");
			Insert(IndexOf(NextOperation), Item);
		}

		public void InsertAfter(Operation PreviousOperation, Operation Item) {
			if(!Contains(PreviousOperation)) throw new ArgumentException("PreviousOperation couldn't be found in this collection");
			Insert(IndexOf(PreviousOperation) + 1, Item);
		}

		public new void Insert(int Index, Operation Item) {
			base.Insert(Index, Item);

			//update arguments that points to an operation that has just changed its index
			foreach(Operation O in this) {
				foreach(Operand Op in O.Arguments) {
					if(Op is OperationOperand) {
						OperationOperand OpOp = Op as OperationOperand;
						if(OpOp.OperationIndex >= Index) OpOp.OperationIndex++;
					}
				}
			}
		}

		public new void Remove(Operation Item) {
			int RemovedItemIndex = IndexOf(Item);
			base.Remove(Item);
			
			//update arguments that points to an operation that has just changed its index
			foreach(Operation O in this) {
				foreach(Operand Op in O.Arguments) {
					if(Op is OperationOperand) {
						OperationOperand OpOp = Op as OperationOperand;
						if(OpOp.OperationIndex > RemovedItemIndex) OpOp.OperationIndex--;
					}
				}
			}
		}
	}
}