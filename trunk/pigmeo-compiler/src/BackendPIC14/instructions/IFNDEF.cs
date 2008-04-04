namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// If designation FirstValue was not previously defined, or if its definition was erased with directive UNDEFINE, instructions which follow would be executed until ELSE or ENDIF directives would be reached
	/// </summary>
	public class IFNDEF:AsmInstruction {
		/// <summary>
		/// If designation FirstValue was not previously defined, or if its definition was erased with directive UNDEFINE, instructions which follow would be executed until ELSE or ENDIF directives would be reached
		/// </summary>
		public IFNDEF(string FirstValue, string comment) {
			directive = Directive.IFNDEF;
			type = InstructionType.Directive_str;

			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
