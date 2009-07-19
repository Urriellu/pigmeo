using System;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	public abstract class Type {
		public Program ParentProgram;

		/// <summary>
		/// The Type's name. Note that in PIR there is no distinction between Name and FullName, because the Namespace is now part of its name
		/// </summary>
		public string Name;

		/// <summary>
		/// Type this one derives from
		/// </summary>
		public Type BaseType;

		public MethodCollection Methods = new MethodCollection();
		public FieldCollection Fields = new FieldCollection();

		public bool IsPublic;

		/// <summary>
		/// Indicates if this objects represents a .NET native type (UInt8, Float32...)
		/// </summary>
		public bool IsBaseType {
			get {
				if(BaseType == null) return _IsBaseType;
				else return BaseType.IsBaseType || _IsBaseType;
			}
			set {
				_IsBaseType = value;
			}
		}
		protected bool _IsBaseType = false;

		/// <summary>
		/// Base Type (Bool, Byte, UInt32...) this class represents
		/// </summary>
		public BaseType ReprBaseType {
			get {
				if(BaseType == null || _ReprBaseType.HasValue) return _ReprBaseType.Value;
				else return BaseType.ReprBaseType;
			}
			set {
				_ReprBaseType = value;
			}
		}
		protected BaseType? _ReprBaseType = null;

		/// <summary>
		/// Clones this object
		/// </summary>
		public abstract Type Clone();

		protected Type(Program ParentProgram) {
			this.ParentProgram = ParentProgram;
		}

		/// <summary>
		/// Generates a PIR of a Type from a reflected type
		/// </summary>
		protected Type(Program ParentProgram, PRefl.Type ReflectedType, bool IncludeMembers) {
			this.ParentProgram = ParentProgram;
			Name = ReflectedType.FullName;
			IsPublic = ReflectedType.IsPublic;
		}

		public abstract UInt32 Size { get; }

		public override string ToString() {
			string Output = "";
			if(IsPublic) Output += "public ";
			if(this is Enum) Output += "enum ";
			else if(this is Struct) Output += "struct ";
			else if(this is Class) {
				Output += "class ";
				if((this as Class).IsAbstract) Output += "abstract ";
				if((this as Class).IsSealed) Output += "sealed ";
			} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			Output += Name;
			if(BaseType == null) Output += ":WithoutBaseType";
			else Output += ":" + BaseType.Name;
			Output += " {\n";
			foreach(Field f in Fields) {
				foreach(string line in f.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "\n";
			foreach(Method m in Methods) {
				foreach(string line in m.ToString().Split('\n')) {
					Output += "\t" + line + "\n";
				}
			}
			Output += "}\n";
			return Output;
		}
	}
}
