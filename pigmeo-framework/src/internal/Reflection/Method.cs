using System;
using System.Collections.Generic;
using Mono.Cecil;
using Pigmeo.Extensions;

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

		public Type ReturnType {
			get {
				if(_ReturnType == null) {
					_ReturnType = ParentAssembly.GetAType(OriginalMethod.ReturnType.ReturnType.FullName);
				}
				return _ReturnType;
			}
		}
		protected Type _ReturnType;

		/// <summary>
		/// List of local variables in this Method
		/// </summary>
		public LocalVariableCollection LocalVariables {
			get {
				if(_LocalVariables == null) {
					ShowExternalInfo.InfoDebug("Retrieving local variables of method {0} (Mono.Cecil->P.I.Reflection)", FullNameWithAssembly);
					_LocalVariables = new LocalVariableCollection(OriginalMethod.Body.Variables.Count);
					for(UInt16 i = 0 ; i < OriginalMethod.Body.Variables.Count ; i++) _LocalVariables.Add(i, new LocalVariable(this, OriginalMethod.Body.Variables[i]));
				}
				return _LocalVariables;
			}
		}
		protected LocalVariableCollection _LocalVariables;

		public ParameterCollection Parameters {
			get {
				if(_Parameters == null) {
					if(IsStatic) {
						ShowExternalInfo.InfoDebug("Retrieving the {0} parameters of method {1} (Mono.Cecil->P.I.Reflection)", OriginalMethod.Parameters.Count, FullNameWithAssembly);
						_Parameters = new ParameterCollection(OriginalMethod.Parameters.Count);
						for(UInt16 i = 0 ; i < OriginalMethod.Parameters.Count ; i++) {
							ShowExternalInfo.InfoDebug("New parameter: " + OriginalMethod.Parameters[i].Name);
							_Parameters.Add(i, new CommonParameter(this, OriginalMethod.Parameters[i]));
						}
					} else {
						ShowExternalInfo.InfoDebug("Retrieving the {0} parameters of method {1} (Mono.Cecil->P.I.Reflection)", OriginalMethod.Parameters.Count + 1, FullNameWithAssembly);
						_Parameters = new ParameterCollection(OriginalMethod.Parameters.Count + 1);
						_Parameters.Add(0, new ThisParameter(this));
						for(UInt16 i = 0 ; i < OriginalMethod.Parameters.Count ; i++) {
							ShowExternalInfo.InfoDebug("New parameter: " + OriginalMethod.Parameters[i].Name);
							_Parameters.Add((UInt16)(i + 1), new CommonParameter(this, OriginalMethod.Parameters[i]));
						}
					}
				}
				return _Parameters;
			}
		}
		protected ParameterCollection _Parameters;

		/// <summary>
		/// List of CIL instruction in this Method
		/// </summary>
		public InstructionCollection Instructions {
			get {
				if(_Instructions == null) {
					ShowExternalInfo.InfoDebug("Retrieving instructions of method {0} (Mono.Cecil->P.I.Reflection)", FullNameWithAssembly);
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
		/// List of Methods referenced by the instructions of this Method
		/// </summary>
		public Method[] ReferencedMethods {
			get {
				if(_ReferencedMethods == null) {
					List<Method> Refs = new List<Method>(Instructions.Count);
					foreach(Instruction inst in Instructions) {
						if(inst is Reflection.Instructions.MethodOperand) Refs.Add((inst as Reflection.Instructions.MethodOperand).ReferencedMethod);
					}
					_ReferencedMethods = Refs.ToArray();
				}
				return _ReferencedMethods;
			}
		}
		protected Method[] _ReferencedMethods;

		/// <summary>
		/// List of Fields referenced by the instructions of this Method
		/// </summary>
		public Field[] ReferencedFields {
			get {
				if(_ReferencedFields == null) {
					List<Field> Refs = new List<Field>(Instructions.Count);
					foreach(Instruction inst in Instructions) {
						if(inst is Reflection.Instructions.FieldOperand) Refs.Add((inst as Reflection.Instructions.FieldOperand).ReferencedField);
					}
					_ReferencedFields = Refs.ToArray();
				}
				return _ReferencedFields;
			}
		}
		protected Field[] _ReferencedFields;

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
				return string.Concat(ParentType.FullName, "::", Name);
			}
		}

		/// <summary>
		/// Method's full name, including assembly this type belongs to, namespaces, parent type and its own name. For example "[mscorlib]System.More.Namespaces.ClassName::ThisMethod"
		/// </summary>
		public string FullNameWithAssembly {
			get {
				return string.Concat(ParentType.FullNameWithAssembly, "::", Name);
			}
		}

		/// <summary>
		/// Method's full name, including assembly this type belongs to, namespaces, parent type, its own name and its parameters. For example "[mscorlib]System.More.Namespaces.ClassName::ThisMethod([mscorlib]System.Byte MyVariable)"
		/// </summary>
		public string FullNameWAssParams {
			get {
				List<string> strs = new List<string>();
				strs.Add(FullNameWithAssembly);
				strs.Add("(");
				for(UInt16 i = 0 ; i < Parameters.Count ; i++) {
					strs.Add(Parameters[i].ToString());
					if(i != Parameters.Count - 1) strs.Add(", ");
				}
				strs.Add(")");
				return string.Concat(strs.ToArray());
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
			string[] ParamStrings = new string[Parameters.Count];
			for(UInt16 i = 0 ; i < (UInt16)Parameters.Count ; i++) ParamStrings[i] = Parameters[i].ToString();
			Output += string.Concat(Name, " (", ParamStrings.CommaSeparatedList(), ")");
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
