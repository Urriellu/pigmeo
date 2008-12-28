using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Pigmeo.Internal {
	/// <summary>
	/// Gets a list of things that require work on them. They has got the PigmeoToDo custom attribute
	/// </summary>
	public class FindPigmeoToDos {
		protected readonly AssemblyDefinition ass;

		public List<MethodDefinition> Methods = new List<MethodDefinition>();

		/// <summary>
		/// Instantiates a FinPigmeoToDos object
		/// </summary>
		/// <param name="AssemblyPath">Path to the assembly being examined</param>
		public FindPigmeoToDos(string AssemblyPath) {
			ass = AssemblyFactory.GetAssembly(AssemblyPath);
		}

		/// <summary>
		/// Finds all the methods containing the attribute PigmeoToDo
		/// </summary>
		protected void GetListToDoMethods() {
			Methods.Clear();
			foreach(ModuleDefinition module in ass.Modules) {
				foreach(TypeDefinition type in module.Types) {
					foreach(MethodDefinition method in type.Methods) {
						foreach(CustomAttribute cattr in method.CustomAttributes) {
							if(cattr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.PigmeoToDo") Methods.Add(method);
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the reason the method is marked as PigmeoToDo
		/// </summary>
		protected string GetMethodToDoReason(MethodDefinition method) {
			string reason = "";
			foreach(CustomAttribute cattr in method.CustomAttributes) {
				if(cattr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.PigmeoToDo") reason = cattr.ConstructorParameters[0] as string;
			}
			return reason;
		}

		/// <summary>
		/// Writes the list of ToDo methods to console
		/// </summary>
		/// <param name="style">The style for print them</param>
		/// <param name="prefix">A prefix being added to each line (useful if you want to add horizontal tabs)</param>
		public void WriteToDoMethodsToConsole(PigmeoToDoPrintStyle style, string prefix) {
			GetListToDoMethods();
			switch(style) {
				case PigmeoToDoPrintStyle.OneMethodPerLine:
					foreach(MethodDefinition method in Methods) Console.WriteLine("{0}{1}", prefix, method.GetFullName().Replace("Pigmeo.Compiler.", ""));
					break;
				case PigmeoToDoPrintStyle.OneMethodAndReasonPerLine:
					foreach(MethodDefinition method in Methods) {
						Console.WriteLine("{0}{1}: {2}", prefix, method.GetFullName().Replace("Pigmeo.Compiler.", ""), GetMethodToDoReason(method));
					}
					break;
				default:
					throw new Exception("Style not supported yet");
			}
		}

		/// <summary>
		/// Writes the list of ToDo methods to console
		/// </summary>
		public void WriteToDoMethodsToConsole(PigmeoToDoPrintStyle style) {
			WriteToDoMethodsToConsole(style, "");
		}
	}

	public enum PigmeoToDoPrintStyle {
		OneMethodPerLine,
		OneMethodAndReasonPerLine,
		AllMethodsOnSingleLine,
		AllMethodsAndReasonsOnSingleLine
	}
}
