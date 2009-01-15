using Pigmeo;
using Pigmeo.Compiler;
using Pigmeo.Extensions;
using System;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Represents ONE instruction written in assembly language
	/// </summary>
	public class AsmInstruction {
		public InstructionType type;

		/// <summary>
		/// Label of the line
		/// </summary>
		public string label;

		/// <summary>
		/// Name of the directive
		/// </summary>
		public Directive directive;

		/// <summary>
		/// Prefix added to some directives
		/// </summary>
		public string Prefix = "";

		/// <summary>
		/// Name of the instruction
		/// </summary>
		public OpCode OP;

		/// <summary>
		/// Position in the RAM of the byte being read or written
		/// </summary>
		public string file;

		/// <summary>
		/// The first string-type parameter of a directive
		/// </summary>
		public string FirstValue;

		/// <summary>
		/// The second string-type parameter of a directive
		/// </summary>
		public string SecondValue;

		/// <summary>
		/// Separator char or string between FirstValue and SecondValue used in some directives
		/// </summary>
		public string separator;

		/// <summary>
		/// Specifies if the value will be written to W or F
		/// </summary>
		public Destination DestinationWF;

		/// <summary>
		/// When reading or writting a bit, this specifies the bit position within the byte specified in "file". Integer form
		/// </summary>
		public UInt3 b_DestinationBit;

		/// <summary>
		/// When reading or writting a bit, this specifies the bit position within the byte specified in "file". String form
		/// </summary>
		/// <remarks>
		/// If this is not set, b_DestinationBit will be used instead
		/// </remarks>
		public string b_DestinationBitStr;

		/// <summary>
		/// Value of the number passed as parameter to some instructions
		/// </summary>
		public byte LiteralNumber;

		/// <summary>
		/// Label of the address in the program memory passed as parameter to a literal-oriented instruction
		/// </summary>
		public string LiteralAddr;

		/// <summary>
		/// Comment at the end of the line
		/// </summary>
		public string comment;

		/// <summary>
		/// Code for special instructions or directives
		/// </summary>
		public string CustomString;

		protected AsmInstruction() { }

		public bool IsBitOriented {
			get {
				if(type == InstructionType.BitOriented_fb) return true;
				else return false;
			}
		}

		public bool IsByteOriented {
			get {
				if(type == InstructionType.ByteOriented_f || type == InstructionType.ByteOriented_fd || type == InstructionType.ByteOriented_none) return true;
				else return false;
			}
		}

		public bool IsDirective {
			get {
				if(type == InstructionType.Directive_lbl_dir_str || type == InstructionType.Directive_none || type == InstructionType.Directive_str || type == InstructionType.Directive_str_dir_str || type == InstructionType.Directive_str_sep_str || type == InstructionType.Directive_str_str) return true;
				else return false;
			}
		}

		public bool IsComment {
			get {
				if(type == InstructionType.Label && string.IsNullOrEmpty(label) && comment.Length > 0) return true;
				else return false;
			}
		}

		/// <summary>
		/// Indicates if this is an actually executing instruction placed in the program memory (excluding comments, directives, labels...)
		/// </summary>
		public bool IsExecutingInstr {
			get {
				if(IsBitOriented || IsByteOriented || type == InstructionType.Literal_address || type == InstructionType.Literal_number || type == InstructionType.Custom) return true;
				else return false;
			}
		}

		public static AsmInstruction SelectRamBank(string label, PIR.PIC.Field Field) {
			ShowInfo.InfoDebug("Selecting RAM Bank for field " + Field.ToStringTypeAndName());
			AsmInstruction NewInstr = null;

			if(Field.IsStatic) {
				NewInstr = new BANKSEL(label, Field.AsmName, "");
			} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", false, "Select RAM banks of non-static fields");
			return NewInstr;
		}

		public override string ToString() {
			string returned = label;
			if(string.IsNullOrEmpty(label)) returned += "\t\t\t\t"; //put all opcodes in the same column
			returned += "\t";
			switch(type) {
				case InstructionType.Custom:
					returned = CustomString;
					break;
				case InstructionType.BitOriented_fb:
					if(string.IsNullOrEmpty(b_DestinationBitStr)) returned += OP.ToString() + "\t" + file + ", " + ((byte)b_DestinationBit).ToAsmString(Architecture.PIC);
					else returned += OP.ToString() + "\t" + file + ", " + b_DestinationBitStr;
					break;
				case InstructionType.ByteOriented_none:
					returned += OP.ToString();
					break;
				case InstructionType.ByteOriented_f:
					returned += OP.ToString() + " " + file;
					break;
				case InstructionType.ByteOriented_fd:
					returned += OP.ToString() + " " + file + "," + DestinationWF;
					break;
				case InstructionType.Literal_address:
					returned += OP.ToString() + " " + LiteralAddr;
					break;
				case InstructionType.Literal_number:
					returned += OP.ToString() + " 0x" + string.Format("{0:X}", LiteralNumber);
					break;
				case InstructionType.Control:
					returned += OP.ToString();
					break;
				case InstructionType.Label:
					returned = label;
					break;
				case InstructionType.Directive_lbl_dir_str:
					returned += directive.ToString() + " " + FirstValue;
					break;
				case InstructionType.Directive_none:
					returned = directive.ToString();
					break;
				case InstructionType.Directive_str:
					returned = Prefix + directive.ToString() + " " + FirstValue;
					break;
				case InstructionType.Directive_str_dir_str:
					returned = FirstValue + " " + directive.ToString() + " " + SecondValue;
					break;
				case InstructionType.Directive_str_sep_str:
					returned = directive.ToString() + " " + FirstValue + separator + SecondValue;
					break;
				case InstructionType.Directive_str_str:
					returned = Prefix + directive.ToString() + " " + FirstValue + " " + SecondValue;
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Convert to string an instruction of type " + type.ToString());
					break;
			}
			// Print comments if there are any and AddCommentsToAsm==true. If it is a label print its comment anyway
			if((config.Internal.AddCommentsToAsm || type == InstructionType.Label) && comment != null && comment != "") {
				if(type == InstructionType.Label && label == "") returned = "; " + comment;
				else returned += "\t; " + comment;
			}
			return returned;
		}
	}

}
