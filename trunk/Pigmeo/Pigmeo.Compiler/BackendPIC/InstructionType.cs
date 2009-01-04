using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.Compiler.BackendPIC {
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
}
