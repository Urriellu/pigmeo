using System;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// List of operands shared between multiple PIR Operations. For example TopOfSoftwareStack, working registers...
	/// </summary>
	public class GlobalOperands:PIR.GlobalOperands {
		/// <summary>
		/// W, the PIC Working Register
		/// </summary>
		public static readonly RegisterOperand W = new RegisterOperand("W");
	}
}
