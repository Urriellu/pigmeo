using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public class Method:TypeMember {
		public Type ReturnType;
		public OperationCollection Operations = new OperationCollection();

		public Method(Program ParentProgram, PRefl.Method ReflectedMethod) {
			ShowInfo.InfoDebug("Converting reflected method {0} to PIR", ReflectedMethod.FullNameWithAssembly);
			this.ParentProgram = ParentProgram;
			ParentType = ParentProgram.Types[ReflectedMethod.ParentType.FullName];
			ReturnType = ParentProgram.Types[ReflectedMethod.ReturnType.FullName];
			Name = ReflectedMethod.Name;
			IsEntryPoint = ReflectedMethod.IsEntryPoint;
			IsStatic = ReflectedMethod.IsStatic;
			IsPublic = ReflectedMethod.IsPublic;
			IsAbstract = ReflectedMethod.IsAbstract;
		}

		/// <summary>
		/// Specifies if this method should be inlined instead of called. It is, all calls to this method will be replaced by the operations executed by the method
		/// </summary>
		/// <remarks>
		/// Methods marked as InLine MUST BE INLINED by the Frontend. Don't expect the backend to inlinize then on-the-fly when compiling it to assembly language
		/// </remarks>
		public bool InLine = false;

		public bool IsEntryPoint = false;
		public bool IsPublic;
		public bool IsStatic;
		public bool IsAbstract;

		/// <summary>
		/// Indicates if this method is reentrant. It is, this method calls itself or one of its called methods call it
		/// </summary>
		public bool IsReentrant {
			[PigmeoToDo("Not implemented")]
			get {
				ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
				return false;
			}
		}

		/// <summary>
		/// Estimates the size of a method compiled to assembly language 
		/// </summary>
		/// <param name="TargetArch">Architecture it would be compiled for</param>
		/// <returns>Estimated amount of instructions generated</returns>
		[PigmeoToDo("Not implemented. Note: if the backend can compile methods independently, we can calculate its exact size and avoid estimating it")]
		public UInt32 EstimateSize(Architecture TargetArch) {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return 0;
		}

		public override string ToString() {
			string Output = "";
			if(IsEntryPoint) Output += "EntryPoint ";
			if(IsPublic) Output += "public ";
			if(IsStatic) Output += "static ";
			if(IsAbstract) Output += "abstract ";
			Output += ReturnType.Name + " ";
			Output += Name + "(";
			//parameters here
			Output += ") {\n";
			foreach(Operation Op in Operations) Output += "\t" + Op.ToString() + "\n";
			Output += "}\n";
			return Output;
		}
	}
}
