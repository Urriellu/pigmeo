namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// It is used for defining EEPROM memory byte. Even though it was first intended only for EEPROM memory, it could be used for any other location in any memory
	/// </summary>
	public class DE:AsmInstruction {
		/// <summary>
		/// It is used for defining EEPROM memory byte. Even though it was first intended only for EEPROM memory, it could be used for any other location in any memory
		/// </summary>
		public DE(string FirstValue, string SecondValue, string comment) {
			directive = Directive.DE;
			type = InstructionType.Directive_str_dir_str;

			this.FirstValue = FirstValue;
			this.SecondValue = SecondValue;
			this.comment = comment;
		}
	}
}
