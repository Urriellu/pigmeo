namespace Pigmeo.Compiler.BackendPIC8bit {
	public class CALL:AsmInstruction {
		/// <summary>
		/// Call Subroutine. First, return address (PC + 1) is pushed onto the stack. The eleven-bit immediate address is loaded into PC bits 10:0. The upper bits ofthe PC are loaded from PCLATH. CALL is a two-cycle instruction
		/// </summary>
		public CALL(string label, string k, string comment) {
			OP = OpCode.CALL;
			type = InstructionType.Literal_address;

			this.LiteralAddr = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
