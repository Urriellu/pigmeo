using System;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Operand of a PIR Operation which is a Software or hardware Register (TopOfSoftwareStack, working registers...)
	/// </summary>
	public class RegisterOperand:Operand {
		public readonly string Name;

		public RegisterOperand(string Name) {
			this.Name = Name;
		}

		public override string ToString() {
			return string.Format("[Register]{0}", Name);
		}
	}
}
