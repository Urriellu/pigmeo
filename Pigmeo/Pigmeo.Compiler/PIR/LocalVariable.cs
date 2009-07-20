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

		protected LocalVariable(Method ParentMethod, PRefl.LocalVariable RefldLocalVar) {
			this.ParentMethod = ParentMethod;
			this.LocalVarType = ParentProgram.Types[RefldLocalVar.VariableType.FullName];
			Name = RefldLocalVar.Name;
		}

		protected LocalVariable(Method ParentMethod, Type LocalVarType, string Name) {
			this.ParentMethod = ParentMethod;
			this.LocalVarType = LocalVarType;
			this.Name = Name;
		}

		public static LocalVariable NewByArch(Method ParentMethod, PRefl.LocalVariable RefldLocalVar) {
			if(ParentMethod == null) throw new ArgumentNullException("ParentMethod");
			if(RefldLocalVar == null) throw new ArgumentNullException("RefldLocalVar");
			ShowInfo.InfoDebug("Converting reflected LocalVariable {0} (in method {1}) to PIR", RefldLocalVar.ToString(), RefldLocalVar.ParentMethod.FullNameWithAssembly);
			LocalVariable NewLV = null;
			switch(ParentMethod.ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					NewLV = new PIC.LocalVariable(ParentMethod, RefldLocalVar);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					break; ;
			}
			return NewLV;
		}

		public static LocalVariable NewByArch(Method ParentMethod, Type LocalVarType, string Name) {
			if(ParentMethod == null) throw new ArgumentNullException("ParentMethod");
			if(LocalVarType == null) throw new ArgumentNullException("LocalVarType");
			if(string.IsNullOrEmpty(Name)) throw new ArgumentNullException("Name");
			ShowInfo.InfoDebug("Creating LocalVariable {0} of Type {1} in method {2}", Name, LocalVarType.Name, ParentMethod.ToStringRetTypeFullNameArgs());
			LocalVariable NewLV = null;
			switch(ParentMethod.ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					NewLV = new PIC.LocalVariable(ParentMethod, LocalVarType, Name);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					break; ;
			}
			return NewLV;
		}

		public override string ToString() {
			return string.Concat("[", Index.ToString(), "] ", LocalVarType.Name, " ", Name);
		}
	}
}
