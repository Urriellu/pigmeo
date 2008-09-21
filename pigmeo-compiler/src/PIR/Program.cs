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
	public partial class Program {
		public Architecture TargetArch = Architecture.Unknown;
		public Branch TargetBranch = Branch.Unknown;
		public TypeCollection Types = new TypeCollection();
		public readonly Optimizations Optimize;

		public Program() {
			Optimize = new Optimizations(this);
		}

		#region static members
		/// <summary>
		/// Generates a PIR of a Program from a .NET executable file
		/// </summary>
		public static Program GetFromFile(string File) {
			//PRefl.Assembly ReflectedAssembly = new PRefl.Assembly(File);
			PRefl.Assembly ReflectedAssembly = PRefl.Assembly.GetFromFile(File);
			ShowInfo.InfoDebugDecompile("Compiling the following assembly (output from Pigmeo.Reflection)", ReflectedAssembly);
			return GetFromCIL(ReflectedAssembly);
		}

		/// <summary>
		/// Generates a PIR of a Program from a Reflected assembly
		/// </summary>
		/// <param name="ReflectedAssembly"></param>
		/// <returns></returns>
		[PigmeoToDo("Class fields. Enums")]
		public static Program GetFromCIL(PRefl.Assembly ReflectedAssembly) {
			Program NewProgram = new Program();
			NewProgram.TargetArch = ReflectedAssembly.TargetArch;
			NewProgram.TargetBranch = ReflectedAssembly.TargetBranch;
			foreach(PRefl.Type OrigType in ReflectedAssembly.Types) {
				if(OrigType.IsClass) {
					Class NewClass = new Class();
					NewClass.Name = OrigType.FullName;
					/*foreach(Field OrigField in NewClass.Fields) {
					}*/
					foreach(PRefl.Method OrigMethod in OrigType.Methods) {
						Method NewMethod = new Method();
						NewMethod.ParentType = NewClass;
						NewMethod.Name = OrigMethod.Name;
						NewMethod.IsEntryPoint = OrigMethod.IsEntryPoint;
						NewMethod.IsPublic = OrigMethod.IsPublic;
						NewClass.Methods.Add(NewMethod);
					}
					NewProgram.Types.Add(NewClass);
				} else if(OrigType.IsEnum) {
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "enums");
				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, OrigType.FullName);
			}
			return NewProgram;
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
		/// Adds and empty class to the Types collection
		/// </summary>
		/// <param name="FullName"></param>
		public void AddClass(string FullName) {
			Class NewClass = new Class();
			Types.Add(NewClass);
		}

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
			Output += "Target branch: " + TargetBranch.ToString() + "\n";
			Output += "Entry point: " + ((EntryPoint == null) ? "NULL" : EntryPoint.FullName) + "\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output;
		}
	}
}
