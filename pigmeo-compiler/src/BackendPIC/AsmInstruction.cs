using Pigmeo;
using Pigmeo.Compiler;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Specifies if the result of the operation of some byte oriented instructions will be stored in W or in a file/register
	/// </summary>
	public enum Destination:byte { W=0, F=1 } //this should be one bit

	/// <summary>
	/// Available instruction types, such as Directive, Byte Orientes Instruction, just a label, a Control Instruction...
	/// </summary>
	/// <remarks>
	/// It also specifies the parameters it can handle
	/// </remarks>
	public enum InstructionType:byte {
		Custom, Control, Label,
		BitOriented_fb, ByteOriented_none, ByteOriented_f, ByteOriented_fd,
		Literal_address, Literal_number,
		Directive_str_str, Directive_str, Directive_str_sep_str, Directive_str_dir_str, Directive_lbl_dir_str, Directive_none
	}

	/// <summary>
	/// Available directive names, such as DEFINE, INCLUDE, EQU, ORG...
	/// </summary>
	public enum Directive:byte {
		DEFINE,
		INCLUDE,
		IFDEF,
		IFNDEF,
		CBLOCK,
		PROCESSOR,
		__CONFIG,
		SET,
		EQU,
		DE,
		ORG,
		DB,
		DT,
		END,
		ELSE,
		ENDIF,
		ENDW,
		ENDC,
		CONSTANT,
		VARIABLE,
		IF,
		WHILE,
		UNDEFINE
	}

	/// <summary>
	/// Available instruction names, such as ADDWF, ANDWF, NOP...
	/// </summary>
	public enum OpCode:byte {
		ADDWF,
		ANDWF,
		CLRF,
		CLRW,
		COMF,
		DECF,
		DECFSZ,
		INCF,
		INCFSZ,
		IORWF,
		MOVF,
		MOVWF,
		NOP,
		RLF,
		RRF,
		SUBWF,
		SWAPF,
		XORWF,
		BCF,
		BSF,
		BTFSC,
		BTFSS,
		ADDLW,
		ANDLW,
		CALL,
		CLRWDT,
		GOTO,
		IORLW,
		MOVLW,
		RETFIE,
		RETLW,
		RETURN,
		SLEEP,
		SUBLW,
		XORLW
	}

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
		/// When reading or writting a bit, this specifies the bit position within the byte specified in "file"
		/// </summary>
		public UInt3 b_DestinationBit;

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

		public override string ToString() {
			string returned = label + "\t";
			switch(type) {
				case InstructionType.Custom:
					returned = CustomString;
					break;
				case InstructionType.BitOriented_fb:
					returned += OP.ToString() + "\t" + file + ", " + ((byte)b_DestinationBit).ToAsmString();
					break;
				case InstructionType.ByteOriented_none:
					returned += OP.ToString();
					break;
				case InstructionType.ByteOriented_f:
					returned += OP.ToString() + " " + file;
					break;
				case InstructionType.ByteOriented_fd:
					returned += OP.ToString() + " " + file + "," + (byte)DestinationWF;
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
					returned=label;
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
			if((config.Internal.AddCommentsToAsm || type == InstructionType.Label) && comment != null && comment != "") returned += "\t;" + comment;
			return returned;
		}
	}

}
