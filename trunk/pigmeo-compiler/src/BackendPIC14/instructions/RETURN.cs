namespace Pigmeo.Compiler.BackendPIC14 {
	public class RETURN:AsmInstruction {
		/// <summary>
		/// Return from subroutine. The stack is POPed and the top of the stack (TOS) is loaded into the program counter. This is a two-cycle instruction
		/// </summary>
		public RETURN(string label, string comment) {
			OP = OpCode.RETURN;
			type = InstructionType.Control;

			this.label = label;
			this.comment = comment;
		}
	}
}
