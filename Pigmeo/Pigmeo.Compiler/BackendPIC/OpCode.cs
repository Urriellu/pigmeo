using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Available instruction names, such as ADDWF, ANDWF, NOP...
	/// </summary>
	public enum OpCode:byte {
		ADDWF,
		ANDWF,
		BANKSEL,
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
