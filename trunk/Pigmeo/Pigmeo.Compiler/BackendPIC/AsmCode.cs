using System;
using System.Collections.Generic;
using Pigmeo.Compiler.UI;
using Pigmeo.Compiler;
using Pigmeo.Internal;

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
				ShowInfo.InfoDebug("Converting the objects representing assembly code to actual source code. There are {0} instructions", Instructions.Count);
				string[] NewCode = new string[Instructions.Count];
				for(int i = 0 ; i < Instructions.Count ; i++) {
					NewCode[i] = Instructions[i].ToString();
				}
				return NewCode;
			}
		}

		public AsmInstructionCollection Instructions = new AsmInstructionCollection();
		#endregion


		#region methods
		/// <summary>
		/// Adds an assembly-language instruction to the end of this code
		/// </summary>
		/// <param name="Instruction">Instruction to add</param>
		public void Add(AsmInstruction Instruction) {
			Instructions.Add(Instruction);
		}

		/// <summary>
		/// Adds the given code to the end of this
		/// </summary>
		/// <param name="Code">Code to add</param>
		public void Add(AsmCode Code) {
			Instructions.AddRange(Code.Instructions);
		}

		/// <summary>
		/// Adds all the given codes to the end of this
		/// </summary>
		/// <param name="Codes">Codes to add</param>
		/// <param name="EmptyLines">Amount of empty lines to put between codes</param>
		public void AddRange(AsmCode[] Codes, UInt16 EmptyLines) {
			for(int i = 0 ; i < Codes.Length ; i++) {
				Instructions.AddRange(Codes[i].Instructions);
				if(i < Codes.Length - 1) Instructions.Add(new Label("", ""));
			}
		}

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

		[PigmeoToDo("Not implemented")]
		public void DelRedundantBanksels() {
		}
	}
}
