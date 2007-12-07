namespace Pigmeo.Compiler.BackendPIC8bit {
	public class INCLUDE:AsmInstruction {
		/// <summary>
		/// An application of this directive has the effect as though the entire file was copied to a place where the "include" directive was found
		/// </summary>
		/// <param name="FirstValue">If the file name is in the square brackets, we are dealing with a system file, and if it is inside quotation marks, we are dealing with a user file</param>
		public INCLUDE(string FirstValue, string comment) {
			directive = Directive.INCLUDE;
			type = InstructionType.Directive_str;

			//this.Prefix = "#";
			this.FirstValue = FirstValue;
			this.comment = comment;
		}
	}
}
