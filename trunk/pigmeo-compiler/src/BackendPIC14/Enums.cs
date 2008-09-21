namespace Pigmeo.Compiler.BackendPIC14 {
	/// <summary>
	/// Specifies if the result of the operation of some byte oriented instructions will be stored in W or in a file/register
	/// </summary>
	public enum Destination:byte { W = 0, F = 1 } //this should be one bit

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
}
