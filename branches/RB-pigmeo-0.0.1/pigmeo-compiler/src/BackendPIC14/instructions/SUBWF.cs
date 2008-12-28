namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Subtract (2’s complement method) W register from register "f"
	/// </summary>
	public class SUBWF:AsmInstruction {
		/// <summary>
		/// Subtract (2’s complement method) W register from register "f"
		/// </summary>
		public SUBWF(string label, string f, Destination d, string comment) {
			OP = OpCode.SUBWF;
			type = InstructionType.ByteOriented_fd;

			this.file = f;
			this.DestinationWF = d;
			this.label = label;
			this.comment = comment;
		}
	}
}
