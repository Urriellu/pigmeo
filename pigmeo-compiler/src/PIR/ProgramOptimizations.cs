using System;
using System.Collections.Generic;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// List of available optimizations that can be done to a Program
	/// </summary>
	public abstract class ProgramOptimizations {
		/// <summary>
		/// The Program being optimized
		/// </summary>
		protected readonly Program Program;

		public ProgramOptimizations(Program ProgramToOptimize) {
			this.Program = ProgramToOptimize;
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
		public void CallStaticConstructorsBeforeEntryPoint() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "CallStaticConstructorsBeforeEntryPoint");
		}

		/// <summary>
		/// Removes the class hierarchy, so the resulting Porgram has only one class which contains ALL variables and methods, so it's easier to convert to not-object-oriented assembly language
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void RemoveClassHierarchy() {
			BundleStaticMethods(config.Internal.GlobalStaticThings);
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Moves all static fields from any class to a single class
		/// </summary>
		/// <param name="DestClass"></param>
		[PigmeoToDo("Not implemented")]
		public void BundleStaticFields(string DestClass) {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Moves all static methods from any class to a single class
		/// </summary>
		/// <param name="DestClass"></param>
		[PigmeoToDo("Not implemented")]
		public void BundleStaticMethods(string DestClass) {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

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
	}
}
