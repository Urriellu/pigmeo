﻿using System;
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
		public readonly Mono.Cecil.MethodDefinition OriginalMethod;

		/// <summary>
		/// .NET Assembly this Method is contained in
		/// </summary>
		public Assembly ParentAssembly {
			get {
				return ParentType.ParentAssembly;
			}
		}

		/// <summary>
		/// The Methods's parent type. That's the Type this Method is contained in
		/// </summary>
		public Type ParentType;

		/// <summary>
		/// List of local variables in this Method
		/// </summary>
		public LocalVariableCollection LocalVariables {
			get {
				if(_LocalVariables == null) {
					ShowExternalInfo.InfoDebug("Retrieving local variables of method {0} (Mono.Cecil->P.I.Reflection)", Name);
					_LocalVariables = new LocalVariableCollection(OriginalMethod.Body.Variables.Count);
					for(UInt16 i = 0 ; i < OriginalMethod.Body.Variables.Count ; i++) _LocalVariables.Add(i, new LocalVariable(this, OriginalMethod.Body.Variables[i]));
					/*foreach(Mono.Cecil.Cil.VariableDefinition CclVar in OriginalMethod.Body.Variables) {
						_LocalVariables.Add(new LocalVariable(this, CclVar));
					}*/
				}
				return _LocalVariables;
			}
		}
		protected LocalVariableCollection _LocalVariables;

		/// <summary>
		/// List of CIL instruction in this Method
		/// </summary>
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

		/// <summary>
		/// Creates a new object that represents a Method
		/// </summary>
		/// <param name="ParentType">Type (class, interface...) this Method belongs to</param>
		/// <param name="OriginalMethod">This Method, as represented by Mono.Cecil</param>
		public Method(Type ParentType, Mono.Cecil.MethodDefinition OriginalMethod) {
			this.ParentType = ParentType;
			this.OriginalMethod = OriginalMethod;
		}

		/// <summary>
		/// Name of this Method
		/// </summary>
		public string Name {
			get {
				return OriginalMethod.Name;
			}
		}

		/// <summary>
		/// Method's full name, including namespaces, parent type and its own name. For example "System.Some.More.Namespaces.ParentClass::ThisMethod"
		/// </summary>
		public string FullName {
			get {
				return ParentType.FullName + "::" + Name;
			}
		}

		/// <summary>
		/// Method's full name, including assembly this type belongs to, namespaces, parent type and its own name. For example "[mscorlib]System.More.Namespaces.ClassName::ThisMethod"
		/// </summary>
		public string FullNameWithAssembly {
			get {
				return string.Concat(ParentType.FullNameWithAssembly, FullName);
			}
		}

		/// <summary>
		/// Specifies that an implementation of the method is not provided but shall be provided by a derived class
		/// </summary>
		public bool IsAbstract {
			get {
				return OriginalMethod.IsAbstract;
			}
		}

		/// <summary>
		/// The method is public
		/// </summary>
		public bool IsPublic {
			get {
				return OriginalMethod.IsPublic;
			}
		}

		/// <summary>
		/// The method is private
		/// </summary>
		public bool IsPrivate {
			get {
				return OriginalMethod.IsPrivate;
			}
		}

		/// <summary>
		/// Static methods are methods that are associated with a type, not with its instances
		/// </summary>
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

		/// <summary>
		/// Specifies if this method is the entrypoint of the application
		/// </summary>
		public bool IsEntryPoint {
			get {
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
				//foreach(LocalVariable var in LocalVariables) Output += "\t" + var.ToString() + "\n";
				for(UInt16 i = 0 ; i < (UInt16)LocalVariables.Count ; i++) Output += "\t" + LocalVariables[i].ToString() + "\n";
				if(LocalVariables.Count > 0) Output += "\n";
				foreach(Instruction inst in Instructions) Output += "\t" + inst.ToString() + "\n";
				Output += "}\n";
			} else Output += ";\n";
			return Output;
		}
	}
}