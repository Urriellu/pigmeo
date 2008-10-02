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
		public Architecture TargetArch = Architecture.Unknown;
		public Family TargetFamily = Family.Unknown;
		public Branch TargetBranch = Branch.Unknown;
		public TypeCollection Types = new TypeCollection();
		public ProgramOptimizations Optimize { get; protected set; }

		#region constructors
		/// <summary>
		/// Generates a PIR of a Program from a .NET executable file
		/// </summary>
		public static Program GetFromFile(string File) {
			return GetFromCIL(PRefl.Assembly.GetFromFile(File));
		}

		/// <summary>
		/// Generates a PIR of a Program from a Reflected assembly
		/// </summary>
		public static Program GetFromCIL(PRefl.Assembly ReflectedAssembly) {
			switch(ReflectedAssembly.TargetArch) {
				case Architecture.PIC:
					return new PIC.Program(ReflectedAssembly);
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0008", true, ReflectedAssembly.TargetArch.ToString());
					return null;
			}
		}
		#endregion

		#region properties
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

		/// <summary>
		/// Returns an exact copy of this Program and all of its members (types, methods, fields...)
		/// </summary>
		/// <returns></returns>
		[PigmeoToDo("Not implemented")]
		public Program Clone() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}

		public override string ToString() {
			string Output = "";
			Output += "Target architecture: " + TargetArch.ToString() + "\n";
			Output += "Target family: " + TargetFamily.ToString() + "\n";
			Output += "Target branch: " + TargetBranch.ToString() + "\n";
			Output += "Entry point: " + ((EntryPoint == null) ? "NULL" : EntryPoint.FullName) + "\n\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output.TrimEnd('\n');
		}
	}
}
