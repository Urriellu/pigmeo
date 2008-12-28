using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET method parameter
	/// </summary>
	public class ThisParameter:Parameter {
		/// <summary>
		/// Instantiates a new Parameter which is a "this" pointer. The first parameter of a Instance Method is always the "this" pointer, which points to the object instance
		/// </summary>
		/// <param name="ParentMethod">Method this parameter belongs to</param>
		public ThisParameter(Method ParentMethod) {
			this.ParentMethod = ParentMethod;
			Name = "this";
			Index = 0;
			ParamType = ParentMethod.ParentType;
			ShowExternalInfo.InfoDebug("New This Parameter of type {0} in method {1}", ParamType.FullNameWithAssembly, ParentMethod.FullNameWithAssembly);
		}
	}
}