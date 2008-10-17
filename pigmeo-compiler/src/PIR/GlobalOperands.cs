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
	}
}
