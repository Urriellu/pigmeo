namespace Pigmeo.Compiler.BackendPIC14 {
	public class __CONFIG:AsmInstruction {
		/// <summary>
		/// Setup the configuration bits (watchdog, oscillator type, code protection...)
		/// </summary>
		public __CONFIG(string FirstValue, string comment) {
			directive = Directive.__CONFIG;
			type = InstructionType.Directive_str;

			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
