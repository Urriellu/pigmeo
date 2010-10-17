using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.UI {
	/// <summary>
	/// Blocks in which messages are grouped when storing debug/verbose output messages
	/// </summary>
	public class OutputBlock {
		/// <summary>
		/// Name of the output-message block
		/// </summary>
		public string Name;

		/// <summary>
		/// Compiler stage from which this output message block was generated
		/// </summary>
		public CompilerStage Stage;

		/// <summary>
		/// Block's title (based on stage and name)
		/// </summary>
		public string Title {
			get {
				string r = "";
				switch(Stage) {
					case CompilerStage.Initialization:
						r += "Init";
						break;
					case CompilerStage.Intermediate:
						r += "Intrm";
						break;
					case CompilerStage.HighLevelCompiler:
						r += "HL";
						break;
					case CompilerStage.Frontend:
						r += "Fe";
						break;
					case CompilerStage.Backend:
						r += "Be";
						break;
					case CompilerStage.Assembler:
						r += "Asblr";
						break;
					default:
						throw new NotImplementedException(Stage.ToString());
				}
				if(!string.IsNullOrEmpty(Name)) r += ": " + Name;
				return r;
			}
		}

		public OutputBlock() {
			Stage = GlobalShares.Stage;
			Messages = new List<KeyValuePair<string, string>>(5);
		}

		/// <summary>
		/// Add a new message to this block
		/// </summary>
		/// <param name="Title">Message title (can be empy)</param>
		/// <param name="Message">Message to show</param>
		public void AddNewMsg(string Title, string Message) {
			Messages.Add(new KeyValuePair<string, string>(Title, Message));
		}

		/// <summary>
		/// List of messages.
		/// First string: title of message (can be empty)
		/// Second string: the message
		/// </summary>
		public List<KeyValuePair<string, string>> Messages;
	}
}
