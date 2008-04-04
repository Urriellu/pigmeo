namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// It is used to give values to named constants
	/// </summary>
	/// <param name="FirstValue">Starting value</param>
	public class CBLOCK:AsmInstruction {
		/// <summary>
		/// It is used to give values to named constants
		/// </summary>
		/// <param name="FirstValue">Starting value</param>
		public CBLOCK(string FirstValue, string comment) {
			directive = Directive.CBLOCK;
			type = InstructionType.Directive_str;

			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
