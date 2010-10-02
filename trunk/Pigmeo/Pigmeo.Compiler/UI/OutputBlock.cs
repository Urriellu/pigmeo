using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// Blocks in which messages are grouped when storing debug/verbose output messages
	/// </summary>
	public class OutputBlock {
		public string Name = "Unnamed";
	
		public OutputOrigin Origin = OutputOrigin.Miscellaneous;

		public string Title {
			get {
				switch(Origin) {
					case OutputOrigin.HighLevelCompiler:
						return "HL: " + Name;
					case OutputOrigin.Frontend:
						return "Fe: " + Name;
					case OutputOrigin.Backend:
						return "Be: " + Name;
					case OutputOrigin.Assembler:
						return "asblr: " + Name;
					case OutputOrigin.Miscellaneous:
						return "Miscellaneous";
					default:
						throw new NotImplementedException(Origin.ToString());
				}
			}
		}

		/// <summary>
		/// List of messages.
		/// First string: title of message (can be empty)
		/// Second string: the message
		/// </summary>
		public Dictionary<string, string> Messages = new Dictionary<string, string>(5);
	}

	public enum OutputOrigin {
		Miscellaneous,
		HighLevelCompiler,
		Frontend,
		Backend,
		Assembler
	}
}
