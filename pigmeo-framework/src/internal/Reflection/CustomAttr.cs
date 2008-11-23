using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Metadata;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Custom Attribute
	/// </summary>
	public class CustomAttr {
		/// <summary>
		/// This Custom Attribute, as represented by Mono.Cecil
		/// </summary>
		protected readonly Mono.Cecil.CustomAttribute OriginalCAttr;

		/// <summary>
		/// Type of this Custom Attribute
		/// </summary>
		public Type CAttrType {
			get {
				if(_CAttrType == null) {
					_CAttrType = ParentAssembly.GetOwnerOfType(OriginalCAttr.Constructor.DeclaringType.FullName).Types[OriginalCAttr.Constructor.DeclaringType.FullName];
				}
				return _CAttrType;
			}
		}
		protected Type _CAttrType;

		/// <summary>
		/// .NET Assembly this Custom Attribute is contained in
		/// </summary>
		public readonly Assembly ParentAssembly;

		/// <summary>
		/// P.I.Reflection object this Custom Attributed is assigned to
		/// </summary>
		public readonly IAttributable AssignedTo;

		public List<CustomAttrParam> Parameters {
			get {
				if(_Parameters == null) {
					_Parameters = new List<CustomAttrParam>(OriginalCAttr.ConstructorParameters.Count);
					for(int i = 0 ; i < OriginalCAttr.ConstructorParameters.Count ; i++) {
						object param = OriginalCAttr.ConstructorParameters[i];
						string ParamTypeFullName = param.GetType().FullName;
						Type ParamType = ParentAssembly.GetOwnerOfType(ParamTypeFullName).Types[ParamTypeFullName];
						_Parameters.Add(new CustomAttrParam(ParamType, param));
						ShowExternalInfo.InfoDebug("Reflected parameter: type {0}, value {1}", ParamType.FullNameWithAssembly, param);
					}
				}
				return _Parameters;
			}
		}
		protected List<CustomAttrParam> _Parameters;

		/// <summary>
		/// Instantiates a new Custom Attribute
		/// </summary>
		public CustomAttr(Assembly ParentAssembly, IAttributable AssignedTo, Mono.Cecil.CustomAttribute OriginalCAttr) {
			this.ParentAssembly = ParentAssembly;
			this.AssignedTo = AssignedTo;
			this.OriginalCAttr = OriginalCAttr;
		}

		public override string ToString() {
			string ret = CAttrType.FullNameWithAssembly + "(";
			for(int i=0;i<Parameters.Count;i++) {
				CustomAttrParam param = Parameters[i];
				ret += param.Type.FullNameWithAssembly + " ";
				if(param.Type.FullName == "System.String") ret += "\"";
				ret += param.Value.ToString();
				if(param.Type.FullName == "System.String") ret += "\"";
				if(i != Parameters.Count - 1) ret += ", ";
			}
			ret = ret.Substring(0, ret.Length - 2);
			ret += ")";
			return ret;
		}
	}
}