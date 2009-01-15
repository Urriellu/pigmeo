using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Available directive names, such as DEFINE, INCLUDE, EQU, ORG...
	/// </summary>
	public enum Directive:byte {
		Undefined,
		DEFINE,
		ERRORLEVEL,
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
}
