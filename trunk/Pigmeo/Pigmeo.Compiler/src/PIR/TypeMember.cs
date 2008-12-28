using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.PIR {
	public abstract class TypeMember {
		public Program ParentProgram;

		/// <summary>
		/// Type (enum, class...) this TypeMember (field, method...) belongs to
		/// </summary>
		public Type ParentType;

		public string Name;

		public string FullName {
			get {
				return ParentType.Name + "::" + Name;
			}
		}

		public string AsmName {
			get {
				if(string.IsNullOrEmpty(_AsmName)) {
					//Normalize the name for the target architecture (it depends on the characters supported in labels by the target-arch asm language)
					switch(ParentProgram.Target.Architecture) {
						case Architecture.PIC:
							_AsmName = ParentType.Name.Replace('.', '_') + "_" + Name;
							break;
						default:
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
							break;
					}
				}
				return _AsmName;
			}
			set {
				_AsmName = value;
			}
		}
		protected string _AsmName;
	}
}
