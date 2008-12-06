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
	}
}