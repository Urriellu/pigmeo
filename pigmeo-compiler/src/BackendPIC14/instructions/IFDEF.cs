namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// If designation FirstValue was previously defined (most commonly by DEFINE directive), instructions which follow would be executed until ELSE or ENDIF directives would be reached
	/// </summary>
	public class IFDEF:AsmInstruction {
		/// <summary>
		/// If designation FirstValue was previously defined (most commonly by DEFINE directive), instructions which follow would be executed until ELSE or ENDIF directives would be reached
		/// </summary>
		public IFDEF(string FirstValue, string comment) {
			directive = Directive.IFDEF;
			type = InstructionType.Directive_str;

			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
