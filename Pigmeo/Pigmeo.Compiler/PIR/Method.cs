﻿using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using PRefl = Pigmeo.Internal.Reflection;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler.PIR {
	public abstract class Method:TypeMember {
		public PRefl.Method OriginalMethod;
		public Type ReturnType;
		public ParameterCollection Parameters;
		public LocalVariableCollection LocalVariables = new LocalVariableCollection();
		public OperationCollection Operations = new OperationCollection();

		public static Method NewByArch(Program ParentProgram, PRefl.Method ReflectedMethod) {
			ShowInfo.InfoDebug("Converting reflected method {0} to PIR", ReflectedMethod.FullNameWithAssembly);
			Method NewMethod = null;
			switch(ParentProgram.Target.Architecture) {
				case Architecture.PIC:
					NewMethod = new PIC.Method();
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "PC0001", true);
					break;
			}
			NewMethod.ParentProgram = ParentProgram;
			NewMethod.ParentType = ParentProgram.Types[ReflectedMethod.ParentType.FullName];
			NewMethod.ReturnType = ParentProgram.Types[ReflectedMethod.ReturnType.FullName];
			NewMethod.Name = ReflectedMethod.Name;
			NewMethod.IsEntryPoint = ReflectedMethod.IsEntryPoint;
			NewMethod.IsStatic = ReflectedMethod.IsStatic;
			NewMethod.IsPublic = ReflectedMethod.IsPublic;
			NewMethod.IsAbstract = ReflectedMethod.IsAbstract;
			NewMethod.OriginalMethod = ReflectedMethod;

			// reflect parameters
			NewMethod.Parameters = new ParameterCollection(ReflectedMethod.Parameters.Count);
			for(UInt16 i = 0 ; i < (UInt16)ReflectedMethod.Parameters.Count ; i++) {
				NewMethod.Parameters.Add(i, new Parameter(NewMethod, ReflectedMethod.Parameters[i]));
			}

			//look for InternalImplementation Custom Attribute
			foreach(PRefl.CustomAttr cattr in ReflectedMethod.CustomAttributes) {
				if(cattr.CAttrType.FullName == "Pigmeo.Internal.InternalImplementation" && cattr.Parameters.Count == 0) NewMethod.IsInternalImpl = true;
			}

			//look for InLine Custom Attribute
			foreach(PRefl.CustomAttr cattr in ReflectedMethod.CustomAttributes) {
				if(cattr.CAttrType.FullName == "Pigmeo.InLine" && cattr.Parameters.Count == 0) NewMethod.InLine = true;
			}

			return NewMethod;
		}

		/// <summary>
		/// Specifies if this method should be inlined instead of called. It is, all calls to this method will be replaced by the operations executed by the method
		/// </summary>
		/// <remarks>
		/// Methods marked as InLine MUST BE INLINED by the Frontend. Don't expect the backend to inlinize them on-the-fly when compiling it to assembly language
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
		/// If true, this method is not implemented in managed code, it is implemented by Pigmeo Compiler on compilation time
		/// </summary>
		public bool IsInternalImpl = false;

		/// <summary>
		/// Array of PIR Methods referenced/used by this one
		/// </summary>
		public Method[] ReferencedMethods {
			get {
				List<Method> RefM = new List<Method>();
				if(Operations != null) {
					foreach(Operation Opn in Operations) {
						if(Opn.Arguments != null) {
							foreach(Operand Opd in Opn.Arguments) {
								if(Opd is MethodOperand) RefM.Add((Opd as MethodOperand).TheMethod);
							}
						}
					}
				}
				return RefM.ToArray();
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

		/// <summary>
		/// Replaces all calls to this method by its operations
		/// </summary>
		public void Inlinize() {
			//inlinize methods that should be implemented internally but haven't been implemented yet. These methods retain calls to them, but the method reference is removed from the list of methods on its parent type
			if(IsInternalImpl) ParentType.Methods.Remove(this);
			else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false, "Inlinize non-internally implemented method");
		}

		public override string ToString() {
			string Output = "";
			if(IsEntryPoint) Output += "EntryPoint ";
			if(IsPublic) Output += "public ";
			if(IsStatic) Output += "static ";
			if(IsAbstract) Output += "abstract ";
			Output += ReturnType.Name + " ";
			Output += Name + "(";
			Output += Parameters.ToString();
			Output += ") {\n";
			foreach(LocalVariable LocalVar in LocalVariables) Output += "\t" + LocalVar.ToString() + "\n";
			if(LocalVariables.Count > 0) Output += "\n";
			foreach(Operation Op in Operations) Output += "\t" + Op.ToString() + "\n";
			Output += "}\n";
			return Output;
		}

		/// <summary>
		/// Returns the strings that represents this Method, including its return type, name and arguments
		/// </summary>
		public string ToStringRetTypeNameArgs() {
			return ReturnType.Name + " " + Name + "(" + Parameters.ToString() + ")";
		}

		/// <summary>
		/// Returns the strings that represents this Method, including its return type, full name and arguments
		/// </summary>
		public string ToStringRetTypeFullNameArgs() {
			return ReturnType.Name + " " + FullName + "(" + Parameters.ToString() + ")";
		}

		/// <summary>
		/// Avoid copying values back and forth to the TOSS, as .NET does. Make operation work with operands directly instead of working always with the TOSS
		/// </summary>
		/// <returns>True if something was modified</returns>
		public bool AvoidTOSS() {
			bool MethodModified = false;
			bool CurrOpModified;

			do {
				CurrOpModified = false;
				foreach(Operation CurrOp in Operations) {
					if(CurrOp is Copy) {
						Copy CurrCopyOp = CurrOp as Copy;

						#region [Register]TOSS := something
						if(CurrOp.Arguments[0] != GlobalOperands.TOSS && CurrOp.Result == GlobalOperands.TOSS) {
							ShowInfo.InfoDebugDecompile(string.Format("Method {0} BEFORE avoiding the TOSS at Operation {1}", this.FullName, CurrCopyOp), this);

							for(int i = CurrOp.Index + 1 ; i < Operations.Count && !CurrOpModified ; i++) { //find the operation that uses this operand
								Operation OperUsingTossAsArg = Operations[i];
								//foreach(Operand CurrArg in Operations[i].Arguments) {
								for(int j = 0 ; j < OperUsingTossAsArg.Arguments.Length ; j++) {
									Operand CurrArg = OperUsingTossAsArg.Arguments[j];
									if(CurrArg == GlobalOperands.TOSS) {
										ShowInfo.InfoDebug("Moving argument {0} from Operation {1} to argument #{2} and in Operation {3}, and removing the old Copy Operation", CurrCopyOp.Arguments[0], CurrCopyOp, j, Operations[i]);
										OperUsingTossAsArg.Arguments[j] = CurrCopyOp.Arguments[0];
										Operations.Remove(CurrOp);
										CurrOpModified = MethodModified = true;
										break;
									}
								}
							}

							ShowInfo.InfoDebugDecompile(string.Format("Method {0} AFTER avoiding the TOSS", this.FullName), this);
						}
						#endregion
						if(CurrOpModified) break; //make the foreach loop to start again, because this.Operations was modified
					}

					#region The result of an operation is placed on the TOSS and the following Operation copies the TOSS to some operand
					if(Operations.IndexOf(CurrOp) == Operations.Count - 1) break; //this is the last Operation. Ignore
					Operation NextOp = Operations[Operations.IndexOf(CurrOp) + 1];
					if(CurrOp.Result == GlobalOperands.TOSS && NextOp != null && NextOp is Copy && NextOp.Arguments[0] == GlobalOperands.TOSS && NextOp.Result != GlobalOperands.TOSS) {
						ShowInfo.InfoDebugDecompile(string.Format("Method {0} BEFORE avoiding the TOSS at Operations {1} and {2}", this.FullName, CurrOp, NextOp), this);
						CurrOp.Result = NextOp.Result;
						Operations.Remove(NextOp);
						CurrOpModified = MethodModified = true;
						ShowInfo.InfoDebugDecompile(string.Format("Method {0} AFTER avoiding the TOSS", this.FullName), this);
						break;
					}
					#endregion
				}
			} while(CurrOpModified);

			return MethodModified;
		}

		/// <summary>
		/// Implements internally a PIR Method when possible. These are Methods not implemented in managed code or methods intended to be reimplemented in PIR or in assembly language (performance or portability issues). The Implement() method does nothing when the current PIR Method has no internal implementation in PIR
		/// </summary>
		public bool Implement() {
			bool implemented = true;
			if(false) { //NONE IMPLEMENTED YET
			} else {
				implemented = false;
				ShowInfo.InfoDebug("PIR Method \"{0}\" is not implemented internally in PIR", this.ToStringRetTypeFullNameArgs());
			}
			if(implemented) ShowInfo.InfoDebugDecompile("PIR Method \"" + ToStringRetTypeFullNameArgs() + "\" internally implemend in PIR", this);
			return implemented;
		}
	}
}