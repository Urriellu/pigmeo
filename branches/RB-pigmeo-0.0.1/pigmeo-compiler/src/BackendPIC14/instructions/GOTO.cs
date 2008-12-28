namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// GOTO is an unconditional branch. The eleven-bit immediate value is loaded into PC bits 10:0. The upper bits of PC are loaded from PCLATH[4:3]. GOTO is a two-cycle instruction
	/// </summary>
	public class GOTO:AsmInstruction {
		/// <summary>
		/// GOTO is an unconditional branch. The eleven-bit immediate value is loaded into PC bits 10:0. The upper bits of PC are loaded from PCLATH[4:3]. GOTO is a two-cycle instruction
		/// </summary>
		public GOTO(string label, string k, string comment) {
			OP = OpCode.GOTO;
			type = InstructionType.Literal_address;

			this.LiteralAddr = k;
			this.label = label;
			this.comment = comment;
		}
	}
}
