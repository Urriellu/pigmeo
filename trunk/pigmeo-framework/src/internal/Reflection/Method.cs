using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Method
	/// </summary>
	public class Method {
		/// <summary>
		/// This Method, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.MethodDefinition OriginalMethod;

		/// <summary>
		/// The Methods's parent type. That's the Type this Method is contained in
		/// </summary>
		public Type ParentType;

		public InstructionCollection Instructions {
			get {
				if(_Instructions == null) {
					ShowExternalInfo.InfoDebug("Retrieving instruction of method {0} (Mono.Cecil->P.I.Reflection)", Name);
					_Instructions = new InstructionCollection(OriginalMethod.Body.Instructions.Count);
					foreach(Mono.Cecil.Cil.Instruction Inst in OriginalMethod.Body.Instructions) {
						_Instructions.Add(Instruction.GetFromCecilInstruction(this, Inst));
					}
				}
				return _Instructions;
			}
		}
		protected InstructionCollection _Instructions;

		public Method(Type ParentType, Mono.Cecil.MethodDefinition OriginalMethod) {
			this.ParentType = ParentType;
			this.OriginalMethod = OriginalMethod;
		}

		public string Name {
			get {
				return OriginalMethod.Name;
			}
		}

		public bool IsAbstract {
			get {
				return OriginalMethod.IsAbstract;
			}
		}

		public bool IsPublic {
			get {
				return OriginalMethod.IsPublic;
			}
		}

		public bool IsPrivate {
			get {
				return OriginalMethod.IsPrivate;
			}
		}

		public bool IsStatic {
			get {
				return OriginalMethod.IsStatic;
			}
		}

		public bool HasBody {
			get {
				return OriginalMethod.HasBody;
			}
		}

		public bool IsEntryPoint {
			get {
				/*MethodDefinition entry = method.DeclaringType.Module.Assembly.EntryPoint;
				if(this.Name == entry.Name && this.DeclaringType.FullName == entry.DeclaringType.FullName) return true;
				else return false;*/
				if(OriginalMethod == OriginalMethod.DeclaringType.Module.Assembly.EntryPoint) return true;
				else return false;
			}
		}

		public override string ToString() {
			string Output = "";
			if(IsEntryPoint) Output += "EntryPoint ";
			if(IsPublic) Output += "public ";
			if(IsStatic) Output += "static ";
			if(IsAbstract) Output += "abstract ";
			Output += Name + "(";
			//parameters here
			Output += ")";
			if(HasBody) {
				Output += " {\n";
				foreach(Instruction inst in Instructions) Output += "\t" + inst.ToString() + "\n";
				Output += "}\n";
			} else Output += ";\n";
			return Output;
		}
	}
}
