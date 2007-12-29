namespace Pigmeo.Compiler.BackendPIC8bit {
	public class CLRW:AsmInstruction {
		/// <summary>
		/// W register is cleared. Zero bit (Z) is set
		/// </summary>
		public CLRW(string label, string comment) {
			OP = OpCode.CLRW;
			type = InstructionType.Control;

			this.label = label;
			this.comment = comment;
		}
	}
}
