using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public abstract class LocalVariable {
		public Program ParentProgram {
			get {
				return ParentMethod.ParentProgram;
			}
		}
		public Method ParentMethod;
		public string Name;
		public Type LocalVarType;

		public int Index {
			get {
				return ParentMethod.LocalVariables.IndexOf(this);
			}
		}

		/*public LocalVariable(Method ParentMethod, PRefl.LocalVariable RefldLocalVar) {
			ShowInfo.InfoDebug("Converting reflected LocalVariable {0} (in method {1}) to PIR", RefldLocalVar.ToString(), RefldLocalVar.ParentMethod.FullNameWithAssembly);
			this.ParentMethod = ParentMethod;
			this.LocalVarType = ParentProgram.Types[RefldLocalVar.VariableType.FullName];
			Name = RefldLocalVar.Name;
		}*/

		public static LocalVariable NewByArch(Method ParentMethod, PRefl.LocalVariable RefldLocalVar) {
			ShowInfo.InfoDebug("Converting reflected LocalVariable {0} (in method {1}) to PIR", RefldLocalVar.ToString(), RefldLocalVar.ParentMethod.FullNameWithAssembly);
			LocalVariable NewLV = null;
			switch(ParentMethod.ParentProgram.TargetArch) {
				case Architecture.PIC:
					NewLV = new PIC.LocalVariable();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					break; ;
			}
			NewLV.ParentMethod = ParentMethod;
			NewLV.LocalVarType = ParentMethod.ParentProgram.Types[RefldLocalVar.VariableType.FullName];
			NewLV.Name = RefldLocalVar.Name;
			return NewLV;
		}

		public override string ToString() {
			return string.Concat("[", Index.ToString(), "] ", LocalVarType.Name, " ", Name);
		}
	}
}
