using System;
using System.Collections.Generic;
using Pigmeo.Compiler.UI;

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
				if(O.Arguments == null) continue;
				foreach(Operand Op in O.Arguments) {
					if(Op is OperationOperand) {
						OperationOperand OpOp = Op as OperationOperand;
						if(OpOp.OperationIndex >= Index) OpOp.OperationIndex++;
					}
				}
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific Operation from this collection
		/// </summary>
		/// <param name="Item">Operation being removed</param>
		public new void Remove(Operation Item) {
			int RemovedItemIndex = IndexOf(Item);
			base.Remove(Item);

			//update arguments that points to an operation that has just changed its index
			foreach(Operation O in this) {
				if(O.Arguments == null) continue;
				for(int j = 0 ; j < O.Arguments.Length ; j++) {
					Operand Op = O.Arguments[j];
					if(Op is OperationOperand) {
						OperationOperand OpOp = Op as OperationOperand;
						if(OpOp.OperationIndex > RemovedItemIndex) {
							ShowInfo.InfoDebug("Argument #{0} in Operation with operator {1} at index {2} is a reference to operation at index {3} which has just changed its index", j, O.Operator, O.Label, OpOp.OperationIndex);
							OpOp.OperationIndex--;
						}
					}
				}
			}
		}

		/// <summary>
		/// Removes the first occurrence of each Operation in the given array
		/// </summary>
		public void Remove(Operation[] Operations) {
			foreach(Operation Optn in Operations) {
				Remove(Optn);
			}
		}
	}
}