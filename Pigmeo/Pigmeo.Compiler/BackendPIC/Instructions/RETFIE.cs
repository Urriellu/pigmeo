namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Return from Interrupt. Stack is POPed and Top-of-Stack (TOS) is loaded in the PC. Interrupts are enabled by setting Global Interrupt Enable bit, GIE (INTCON[7]). This is a two-cycle instruction
	/// </summary>
	public class RETFIE:AsmInstruction {
		/// <summary>
		/// Return from Interrupt. Stack is POPed and Top-of-Stack (TOS) is loaded in the PC. Interrupts are enabled by setting Global Interrupt Enable bit, GIE (INTCON[7]). This is a two-cycle instruction
		/// </summary>
		public RETFIE(string label, string comment) {
			OP = OpCode.RETFIE;
			type = InstructionType.Control;

			this.label = label;
			this.comment = comment;
		}
	}
}
