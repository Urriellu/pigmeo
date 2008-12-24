using System;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a PIR Method Parameter
	/// </summary>
	public class Parameter {
		protected readonly PRefl.Parameter OriginalParameter;

		/// <summary>
		/// Instantiates a new Parameter
		/// </summary>
		/// <param name="ParentMethod">Method this parameter belongs to</param>
		/// <param name="ReflectedParameter">The reflected parameter</param>
		public Parameter(Method ParentMethod, PRefl.Parameter ReflectedParameter) {
			this.ParentMethod = ParentMethod;
			this.OriginalParameter = ReflectedParameter;
			Name = ReflectedParameter.Name;
			Index = ReflectedParameter.Index;
			ParamType = ParentProgram.Types[ReflectedParameter.ParamType.FullName];
		}

		/// <summary>
		/// Type of this parameters
		/// </summary>
		public Type ParamType;

		/// <summary>
		/// PIR Program this Parameter is contained in
		/// </summary>
		public Program ParentProgram {
			get {
				return ParentMethod.ParentProgram;
			}
		}

		/// <summary>
		/// The Field's parent Method. That's the Method this Field is contained in
		/// </summary>
		public Method ParentMethod;

		/// <summary>
		/// Name of this Parameter
		/// </summary>
		public string Name;

		/// <summary>
		/// Index of this Parameter in the list of its parent method parameters
		/// </summary>
		public UInt16 Index;

		public override string ToString() {
			return ParamType.Name + " " + Name;
		}
	}
}
