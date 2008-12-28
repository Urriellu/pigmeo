using System;
using System.Text;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// List of operands shared between multiple PIR Operations. For example TopOfSoftwareStack, working registers...
	/// </summary>
	public class GlobalOperands {
		/// <summary>
		/// Top Of Software Stack
		/// </summary>
		public static readonly RegisterOperand TOSS = new RegisterOperand("TOSS");

		/// <summary>
		/// Nowhere is used when the result of some operation must be ignored (in CIL this is done by doing something and then pop'ing the TOSS)
		/// </summary>
		public static readonly RegisterOperand Nowhere = new RegisterOperand("Nowhere");
	}
}
