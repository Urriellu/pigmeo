using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a software program/application
	/// </summary>
	// Note for developers: write properties and methods for work with strings rather than objects, and found the associated object dinamically. It's much easier to modify a PIR Program if we work with strings instead of object references
	public abstract class Program {
		public string Name;
		public TypeCollection Types = new TypeCollection();

		/// <summary>
		/// Generates a PIR of a Program from a .NET executable file
		/// </summary>
		public static Program GetFromFile(string File) {
			return GetFromCIL(PRefl.Assembly.GetFromFile(File));
		}

		#region properties
		/// <summary>
		/// All the information about the target device. The microcontroller this app is being compiled for
		/// </summary>
		public InfoDevice Target {
			get {
				return _Target;
			}
		}
		protected InfoDevice _Target;

		/// <summary>
		/// Gets a reference to the object that represents the Entry Point of this program. Returns null if there is no EntryPoint assigned
		/// </summary>
		public Method EntryPoint {
			get {
				foreach(Type t in Types) {
					foreach(Method m in t.Methods) {
						if(m.IsEntryPoint) return m;
					}
				}
				return null;
			}
		}
		#endregion

		#region PIRefl->PIR
		/// <summary>
		/// Generates a PIR of a Program from a Reflected assembly
		/// </summary>
		public static Program GetFromCIL(PRefl.Assembly ReflectedAssembly) {
			ShowInfo.InfoDebug("Converting the reflected assembly {0} to PIR. Entrypoint: {1}", ReflectedAssembly.Name, ReflectedAssembly.EntryPoint.FullName);
			Program NewProg = null;
			switch(ReflectedAssembly.Target.Architecture) {
				case Architecture.PIC:
					NewProg = new PIC.Program();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0008", true, ReflectedAssembly.Target.Architecture);
					break;
			}
			NewProg.Name = ReflectedAssembly.Name;
			//NewProg.Target.Architecture = ReflectedAssembly.TargetArch;
			//NewProg.Target.Family = ReflectedAssembly.TargetFamily;
			//NewProg.Target.Branch = ReflectedAssembly.TargetBranch;
			NewProg._Target = ReflectedAssembly.Target;
			NewProg.ParseMethod(ReflectedAssembly.EntryPoint);
			return NewProg;
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
				Method NewMethod = Method.NewByArch(this, MethodBeingParsed); //new Method(this, MethodBeingParsed);
				NewMethod.ParentType.Methods.Add(NewMethod);

				//parse other methods this method references
				foreach(PRefl.Method RefMethod in MethodBeingParsed.ReferencedMethods) {
					ParseMethod(RefMethod);
				}

				//parse its (reflected) local variables
				foreach(PRefl.LocalVariable LocalVar in MethodBeingParsed.LocalVariables.Values) {
					ParseType(LocalVar.VariableType);
					LocalVariable NewLocalVar = LocalVariable.NewByArch(NewMethod, LocalVar); //new LocalVariable(NewMethod, LocalVar);
					NewMethod.LocalVariables.Add(NewLocalVar);
				}

				//finally convert its original (reflected) instructions to PIR operations
				foreach(PRefl.Instruction Instr in MethodBeingParsed.Instructions) {
					Operation NewPirOperation = Operation.GetFromPRefl(Instr, NewMethod);
					if(NewPirOperation != null) NewMethod.Operations.Add(NewPirOperation);
					else ShowInfo.InfoDebug("CIL instruction {0} is not converted into PIR", Instr);
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

				Field NewField = Field.NewByArch(this, FieldBeingParsed); //new Field(this, FieldBeingParsed);
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
				if(TypeBeingParsed.IsClass) NewType = Class.NewByArch(this, TypeBeingParsed, false); //new Class(TypeBeingParsed, false);
				else if(TypeBeingParsed.IsEnum) NewType = Enum.NewByArch(this, TypeBeingParsed, false); //new Enum(TypeBeingParsed, false);
				else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Type of PRefl.Type " + TypeBeingParsed.FullNameWithAssembly + " unknown");
				if(TypeBeingParsed.BaseType != null) NewType.BaseType = ParseType(TypeBeingParsed.BaseType);
				Types.Add(NewType);
				return NewType;
			}
		}
		#endregion

		/// <summary>
		/// Returns an exact copy of this Program and all of its members (types, methods, fields...)
		/// </summary>
		/// <returns></returns>
		[PigmeoToDo("Not implemented")]
		public Program Clone() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}

		/// <summary>
		/// Avoid copying values back and forth to the TOSS, as .NET does. Make operation work with operands directly instead of working always with the TOSS
		/// </summary>
		/// <returns>True if something was modified</returns>
		public bool AvoidTOSS() {
			bool mod = false;
			foreach(Type SomeType in Types) {
				foreach(Method SomeMethod in SomeType.Methods) {
					if(SomeMethod.AvoidTOSS()) mod = true;
				}
			}
			return mod;
		}

		/// <summary>
		/// Removes unused classes, methods, fields... so the resulting Program contains only the members that are really going to be executed
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void RemoveUnused() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Find methods so short that is more efficient inlinizing than calling them, and set them the Inline property
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void FindShortInlinizableMethods() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			/* As seen in http://blogs.msdn.com/vancem/archive/2008/08/19/to-inline-or-not-to-inline-that-is-the-question.aspx
			 * 
			 * 1.     Estimate the size of the call site if the method were not inlined.
			 * 2.     Estimate the size of the call site if it were inlined (this is an estimate based on the IL, we employ a simple state machine (Markov Model), created using lots of real data to form this estimator logic)
			 * 3.     Compute a multiplier.   By default it is 1 
			 * 4.     Increase the multiplier if the code is in a loop (the current heuristic bumps it to 5 in a loop)
			 * 5.     Increase the multiplier if it looks like struct optimizations will kick in. 
			 * 6.     If InlineSize  <= NonInlineSize * Multiplier do the inlining. 
			 */
		}

		/// <summary>
		/// Find methods that are called from only one place, so it's more efficient to replace the call by its code
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void FindSingleCallInlinizable() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Find objects that are always in the heap (never Garbage Collected) and convert their fields and staticalize them
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void Deobjectize() {
		}

		/// <summary>
		/// Bundles a bunch of bools in a single registers. It's much more memory-efficient but usually requires more instruction cycles to access them
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void PackBools() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Pack bools");
		}

		/// <summary>
		/// All required type initilizations are executed before running the application. It's usually more efficient since it doesn't need to check again and again if the type initializer has been already called each time an object is instantiated or a static member is referenced
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void CallStaticConstructorsBeforeEntryPoint() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "CallStaticConstructorsBeforeEntryPoint");
		}

		/*/// <summary>
		/// Removes the class hierarchy for static fields and methods, so they are all placed in the same class and it's easier to convert to not-object-oriented assembly languages
		/// </summary>
		public void RemoveClassHierarchy() {
			BundleStaticFields(config.Internal.GlobalStaticThings);
			BundleStaticMethods(config.Internal.GlobalStaticThings);
		}

		/// <summary>
		/// Moves all static fields from any class to a single class
		/// </summary>
		/// <param name="DestClass">
		/// Class where all static fields are being moved to
		/// </param>
		public void BundleStaticFields(string DestClassName) {
			Class DestClass = null;
			if(Types.Contains(DestClassName)) {
				DestClass = Types[DestClassName];
			} else {
				DestClass = Class.NewByArch(this);
				DestClass.Name = DestClassName;
				Types.Add(DestClass);
			}

			foreach(Type t in Types) {

			}

			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Moves all static methods from any class to a single class
		/// </summary>
		/// <param name="DestClass">
		/// Class where all static methods are being moved to
		/// </param>
		[PigmeoToDo("Not implemented")]
		public void BundleStaticMethods(string DestClass) {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}*/

		/// <summary>
		/// Methods whose arguments are all constant and NONE of their operations read or write to non-local variables can be replaced entirely by the value they return
		/// </summary>
		/// <example>
		/// int a = Math.Cos(0); //can be replaced by...
		/// int a = 1;
		/// </example>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeFullMethods() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Methods whose arguments are all constant, none of their operations read to non-local variables and some of their operations write to non-local variables can be replaced by simple assignations of constants to non-local variables
		/// </summary>
		/// <remarks>
		/// This is useful for example when calling Pigmeo.MCU.TMR0.Configure(...) (found in most PIC device libraries). The Configure() method usually takes constant parameters, do a bunch of arithmetic operations and then write the results to some registers. So all those operations can be done at compile-time and the resulting program should contain just the assignment of constant values
		/// </remarks>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeMethodsWConstArgs() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Converts all local members of the EntryPoint to static fields
		/// </summary>
		/// <remarks>
		/// The EntryPoint should never be called from within the program, and in standalone applications it's never called from the outside, so it's safe to to this
		/// </remarks>
		public void StaticalizeEntryPointFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Converts all local members of all methods to static fields. Resulting methods are faster but cannot be re-entered
		/// </summary>
		public void StaticalizeAllLocalFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Find variables that are assigned only once and mark them as contastant
		/// </summary>
		/// <remarks>
		/// Fields should be constantized BEFORE constantizing methods
		/// </remarks>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Converts all operations with enums to arithmetic operations using their base type
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void SimplifyEnums() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		public override string ToString() {
			string Output = "";
			Output += "Target architecture: " + Target.Architecture.ToString() + "\n";
			Output += "Target family: " + Target.Family.ToString() + "\n";
			Output += "Target branch: " + Target.Branch.ToString() + "\n";
			Output += "Entry point: " + ((EntryPoint == null) ? "NULL" : EntryPoint.FullName) + "\n\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output.TrimEnd('\n');
		}
	}
}
