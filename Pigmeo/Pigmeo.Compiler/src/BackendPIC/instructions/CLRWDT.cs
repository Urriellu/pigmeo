namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Resets the Watchdog Timer. It also resets the prescaler of the WDT. Status bits TO and PD are set
	/// </summary>
	public class CLRWDT:AsmInstruction {
		/// <summary>
		/// Resets the Watchdog Timer. It also resets the prescaler of the WDT. Status bits TO and PD are set
		/// </summary>
		public CLRWDT(string label, string comment) {
			OP = OpCode.CLRWDT;
			type = InstructionType.Control;

			this.label = label;
			this.comment = comment;
		}
	}
}
