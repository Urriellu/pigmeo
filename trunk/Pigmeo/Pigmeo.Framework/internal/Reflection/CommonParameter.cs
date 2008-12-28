using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET method parameter
	/// </summary>
	public class CommonParameter:Parameter {
		/// <summary>
		/// This Parameter, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.ParameterDefinition OriginalParameter;

		/// <summary>
		/// Instantiates a new Parameter
		/// </summary>
		/// <param name="ParentMethod">Method this parameter belongs to</param>
		/// <param name="OriginalParameter">This Parameter, as represented by Mono.Cecil</param>
		public CommonParameter(Method ParentMethod, Mono.Cecil.ParameterDefinition OriginalParameter) {
			this.ParentMethod = ParentMethod;
			this.OriginalParameter = OriginalParameter;
			Name = OriginalParameter.Name;
			Index = (UInt16)OriginalParameter.Sequence;
			ParamType = ParentAssembly.GetOwnerOfType(OriginalParameter.ParameterType.FullName).Types[OriginalParameter.ParameterType.FullName];
			ShowExternalInfo.InfoDebug("New Common Parameter {0} of type {1} in method {2} at index {3}", Name, ParamType.FullNameWithAssembly, ParentMethod.FullNameWithAssembly, Index);
		}
	}
}