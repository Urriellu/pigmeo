using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET local variable (a Field which belongs to a Method)
	/// </summary>
	public class LocalVariable {
		/// <summary>
		/// This Local Variable, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.Cil.VariableDefinition OriginalVariable;

		/// <summary>
		/// Type of this variable
		/// </summary>
		public readonly Type VariableType;

		/// <summary>
		/// .NET Assembly this variable is contained in
		/// </summary>
		public Assembly ParentAssembly {
			get {
				return ParentMethod.ParentAssembly;
			}
		}

		/// <summary>
		/// The Field's parent Method. That's the Method this Field is contained in
		/// </summary>
		public readonly Method ParentMethod;

		/// <summary>
		/// Instantiates a new local variable
		/// </summary>
		/// <param name="ParentMethod">Method this variable is contained in</param>
		/// <param name="OriginalVariable">This local variable, as represented by Mono.Cecil</param>
		public LocalVariable(Method ParentMethod, Mono.Cecil.Cil.VariableDefinition OriginalVariable) {
			this.ParentMethod = ParentMethod;
			this.OriginalVariable = OriginalVariable;
			VariableType = ParentAssembly.GetOwnerOfType(OriginalVariable.VariableType.FullName).Types[OriginalVariable.VariableType.FullName];
			ShowExternalInfo.InfoDebug("New local variable {0} of type {1} in method {2} at index {3}", Name, VariableType.FullNameWithAssembly, ParentMethod.FullNameWithAssembly, Index);
		}

		/// <summary>
		/// Name of this local variable
		/// </summary>
		public string Name {
			get {
				return OriginalVariable.Name;
			}
		}

		/// <summary>
		/// Index of this local variable in the list of its parent method local variables
		/// </summary>
		public UInt16 Index {
			get {
				return (UInt16)OriginalVariable.Index;
			}
		}

		public override string ToString() {
			return string.Concat("[", Index.ToString(), "] ", VariableType.FullNameWithAssembly, " ", Name);
		}
	}
}