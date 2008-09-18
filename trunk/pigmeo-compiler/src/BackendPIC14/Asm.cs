using System.Collections.Generic;

namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Objects instantiated from this class contains a full or partial application written in assembly language for 8-bit PICs
	/// </summary>
	public class Asm {
		#region properties
		/// <summary>
		/// Source code in assembly language. Each value of this collection represents a line
		/// </summary>
		public List<string> AsmCode {
			get {
				List<string> code = new List<string>(Instructions.Count);
				foreach(AsmInstruction inst in Instructions) {
					code.Add(inst.ToString());
				}
				return code;
			}
		}

		public List<AsmInstruction> Instructions;
		#endregion


		#region constructors
		/// <summary>
		/// Creates a new instance of Asm
		/// </summary>
		public Asm() {
			Instructions = new List<AsmInstruction>();
		}

		/// <summary>
		/// Creates a new instance of Asm which contains the same assembly language instructions as the original object
		/// </summary>
		/// <param name="original">
		/// Original object being cloned
		/// </param>
		public Asm(Asm original) {
			Instructions = new List<AsmInstruction>(original.Instructions.Count);
			Instructions.AddRange(original.Instructions);
		}
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
