using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents a Program for Microchip PIC Microcontrollers
	/// </summary>
	public class Program:PIR.Program {
		public Program() {
			Optimize = new ProgramOptimizations(this);
		}

		/// <summary>
		/// Generates a PIR of a Program from a Reflected assembly
		/// </summary>
		public Program(PRefl.Assembly ReflectedAssembly) {
			ShowInfo.InfoDebug("Converting the reflected assembly {0} to PIR. Entrypoint: {1}", ReflectedAssembly.Name, ReflectedAssembly.EntryPoint.FullName);
			TargetArch = ReflectedAssembly.TargetArch;
			TargetFamily = ReflectedAssembly.TargetFamily;
			TargetBranch = ReflectedAssembly.TargetBranch;
			ParseMethod(ReflectedAssembly.EntryPoint);
		}

		/// <summary>
		/// If the given method doesn't exist, the method and all of its dependencies are converted to PIR and added to this Program
		/// </summary>
		// Note for developers: don't change the order of the operations in ParseMethod() or Pigmeo.Compiler won't work
		protected void ParseMethod(PRefl.Method MethodBeingParsed) {
			ShowInfo.InfoDebug("If the Method {0} doesn't exist it will be converted to PIR and added to the PIR Program", MethodBeingParsed.FullNameWithAssembly);
			if(!Types.Contains(MethodBeingParsed.ParentType.FullName) || !Types[MethodBeingParsed.ParentType.FullName].Methods.Contains(MethodBeingParsed.Name)) {
				ShowInfo.InfoDebug("The Method {0} must be parsed", MethodBeingParsed.FullNameWithAssembly);

				//first we parse its dependencies (parent type, return type and referenced fields)
				ParseType(MethodBeingParsed.ParentType);
				ParseType(MethodBeingParsed.ReturnType);

				foreach(PRefl.Field RefField in MethodBeingParsed.ReferencedFields) {
					ParseField(RefField);
				}

				//now the method is created
				Method NewMethod = new Method(this, MethodBeingParsed);
				NewMethod.ParentType.Methods.Add(NewMethod);

				//parse other methods this method references
				foreach(PRefl.Method RefMethod in MethodBeingParsed.ReferencedMethods) {
					ParseMethod(RefMethod);
				}

				//foreach(PRefl.LocalVariable RefLocalVar in MethodBeingParsed.ReferencedLocalVars) {
					throw new NotImplementedException();
				//}

				//finally convert its original (reflected) instructions to PIR operations
				foreach(PRefl.Instruction Instr in MethodBeingParsed.Instructions) {
					NewMethod.Operations.Add(Operation.GetFromPRefl(Instr, NewMethod));
				}
			}
		}

		/// <summary>
		/// If the given Field doesn't exist, the Field and all of its dependencies (its declaring type and the Field's type) are converted to PIR (if needed) and added to this Program
		/// </summary>
		protected void ParseField(PRefl.Field FieldBeingParsed) {
			ShowInfo.InfoDebug("If the Field {0} doesn't exist it will be converted to PIR and added to the PIR Program", FieldBeingParsed.FullNameWithAssembly);
			//if this Field's parent type doesn't exist, or this Field doesn't exist...
			if(!Types.Contains(FieldBeingParsed.ParentType.FullName) || !Types[FieldBeingParsed.ParentType.FullName].Fields.Contains(FieldBeingParsed.Name)) {
				ShowInfo.InfoDebug("The Field {0} must be parsed", FieldBeingParsed.FullNameWithAssembly);
				
				//first we parse its dependencies (parent type and its own type)
				ParseType(FieldBeingParsed.ParentType);
				ParseType(FieldBeingParsed.FieldType);

				Field NewField = new Field(this, FieldBeingParsed);
				NewField.ParentType.Fields.Add(NewField);
			}
		}

		/// <summary>
		/// If the given type doesn't exist, the type and all of its dependencies are converted to PIR and added to this Program
		/// </summary>
		/// <returns>
		/// The given method conterted to PIR
		/// </returns>
		protected Type ParseType(PRefl.Type TypeBeingParsed) {
			ShowInfo.InfoDebug("Retrieving the type {0}. We don't know if it exists or it must be created", TypeBeingParsed.FullNameWithAssembly);
			if(Types.Contains(TypeBeingParsed.FullName)) return Types[TypeBeingParsed.FullName];
			else {
				ShowInfo.InfoDebug("The type {0} hasn't been converted to PIR yet", TypeBeingParsed.FullNameWithAssembly);
				Type NewType = null;
				if(TypeBeingParsed.IsClass) NewType = new Class(TypeBeingParsed, false);
				else if(TypeBeingParsed.IsEnum) NewType = new Enum(TypeBeingParsed, false);
				else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Type of PRefl.Type " + TypeBeingParsed.FullNameWithAssembly + " unknown");
				if(TypeBeingParsed.BaseType != null) NewType.BaseType = ParseType(TypeBeingParsed.BaseType);
				Types.Add(NewType);
				return NewType;
			}
		}
	}
}
