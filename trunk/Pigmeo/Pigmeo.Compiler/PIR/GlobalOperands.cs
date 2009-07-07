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

		/// <summary>
		/// This register means that the origin or destination of a PIR Operation must be determined by the CLR itself. This is used for storing the address of an object before accesing one of its fields, and for the first parameter when calling a constructor (because that first parameter is the address of an object which has just been created by NewObject).
		/// </summary>
		public static readonly RegisterOperand CLR = new RegisterOperand("CLR");
	}
}
