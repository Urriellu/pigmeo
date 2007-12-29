namespace Pigmeo.Compiler.BackendPIC8bit {
	public class NOP:AsmInstruction {
		/// <summary>
		/// No operation. Useful for wasting a cycle doing nothing
		/// </summary>
		public NOP(string label, string comment) {
			OP = OpCode.NOP;
			type = InstructionType.Control;

			this.label = label;
			this.comment = comment;
		}
	}
}
