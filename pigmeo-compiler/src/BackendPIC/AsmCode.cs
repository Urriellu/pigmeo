using System.Collections.Generic;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Represents source code written in assembly language for Microchip PIC
	/// </summary>
	public class AsmCode {
		#region properties
		/// <summary>
		/// Source code in assembly language. Each value of this array represents a line
		/// </summary>
		public string[] Code {
			get {
				string[] code = new string[Instructions.Count];
				for(int i=0;i<Instructions.Count;i++){
					Code[i]=Instructions[i].ToString();
				}
				return code;
			}
		}

		public AsmInstructionCollection Instructions = new AsmInstructionCollection();
		#endregion


		#region methods
		public override string ToString() {
			return ToString(config.Internal.EndOfLine);
		}

		public string ToString(string EndOfLine) {
			string code = "";
			foreach(AsmInstruction inst in Instructions) {
				code += inst.ToString() + EndOfLine;
			}
			return code;
		}
		#endregion
	}
}
