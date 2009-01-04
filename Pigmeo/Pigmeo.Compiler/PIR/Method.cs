using System;
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
		/// Methods marked as InLine MUST BE INLINED by the Frontend. Don't expect the backend to inline them on-the-fly when compiling it to assembly language
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

		/// <summary>
		/// Removes dumb temporal variables. That is, LocalVariables or Parameters  that have a value assigned to them, that value never changes, and the original source doesn't change either, so we can avoid assigning that value to the "dumb" variable and replace references to the dumb variable by references to the original source or value
		/// </summary>
		/// <returns>True if there was at least one dumb variable and was removed</returns>
		public bool RemoveDumbTempVars() {
			bool Modified = false;
			foreach(LocalVariable LV in LocalVariables) {
				Operation OptnModifier = null; //the operation that sets the value to the local variable
				Operation LastUser = null; //the last operation using this dumb variable
				Operand LastUserArg = null; //the las argument using this dumb variable
				Operand Source = null;

				UInt16 ModTimes = 0; //amount of times this LV is modifies
				for(int i = 0 ; i < Operations.Count ; i++) {
					Operation CurrOp = Operations[i];
					if(CurrOp.PotentiallyModifies(LV)) {
						ModTimes++;
						OptnModifier = CurrOp;
					} else if(CurrOp.Uses(LV) > 0) {
						LastUser = CurrOp;
					}
				}
				if(ModTimes > 1) continue; //this LV is not dumb

				if(LastUser == null) continue; //this LV is never used after being set


				if(OptnModifier is Copy) {
					Source = OptnModifier.Arguments[0];
					ShowInfo.InfoDebug("Source is " + Source);
				} else {
					//we don't know the source of its value
					continue;
				}

				//is the source is a static volatile field, it's not dumb
				if((Source is FieldValueOperand || Source is FieldBitOperand) && ((FieldOperand)Source).TheField.IsStatic && ((FieldOperand)Source).TheField.IsVolatile) continue;

				bool SourceIsConstant = true;
				for(int OptnIndex = OptnModifier.Index ; OptnIndex <= LastUser.Index ; OptnIndex++) {
					Operation CurrOp = Operations[OptnIndex];
					if(Source is LocalVariableOperand && CurrOp.PotentiallyModifies(((LocalVariableOperand)Source).TheLV)) SourceIsConstant = false;
					else if(Source is ParameterOperand && CurrOp.PotentiallyModifies(((ParameterOperand)Source).TheParameter)) SourceIsConstant = false;
					else if(Source is FieldOperand && CurrOp.PotentiallyModifies(((FieldOperand)Source).TheField)) SourceIsConstant = false;
				}
				if(!SourceIsConstant) continue; //if the source variable is not a constant value, the LV is not dumb

				ShowInfo.InfoDebugDecompile("Method with dumb variable: \"" + LV + "\" in...", this);

				//now we can finally replace references to the dumb variable by references to the source
				for(int OptnIndex = OptnModifier.Index ; OptnIndex <= LastUser.Index ; OptnIndex++) {
					Operation CurrOp = Operations[OptnIndex];
					if(CurrOp.Arguments != null) {
						for(int ArgIndex = 0 ; ArgIndex < CurrOp.Arguments.Length ; ArgIndex++) {
							Operand Opnd = CurrOp.Arguments[ArgIndex];
							if(Opnd is LocalVariableOperand && ((LocalVariableOperand)Opnd).TheLV == LV) CurrOp.Arguments[ArgIndex] = Source;
						}
					}
				}
				Operations.Remove(OptnModifier);

				ShowInfo.InfoDebugDecompile("Method after removing dumb variable", this);
			}
			return Modified;
		}

		/// <summary>
		/// Gets an available name for a Local Variable
		/// </summary>
		public string GetAvailLvName(string NamePrefix) {
			if(!LocalVariables.Contains(NamePrefix)) return NamePrefix;
			else {
				UInt16 i = 0;
				while(LocalVariables.Contains(NamePrefix + i.ToString())) i++;
				return NamePrefix + i.ToString();
			}
		}

		/// <summary>
		/// Replaces references to a Parameter by a reference to a LocalVariable
		/// </summary>
		public void ReplaceRef(Parameter P, LocalVariable LV) {
			if(P == null) throw new ArgumentNullException("P");
			if(LV == null) throw new ArgumentNullException("LV");
			foreach(Operation Optn in Operations) {
				if(Optn.Result != null && Optn.Result is ParameterOperand && (Optn.Result as ParameterOperand).TheParameter == P) Optn.Result = LocalVariableOperand.GetSameRef(Optn.Result as ParameterOperand, LV);
				if(Optn.Arguments != null) {
					for(int i = 0 ; i < Optn.Arguments.Length ; i++) {
						if(Optn.Arguments[i] is ParameterOperand && (Optn.Arguments[i] as ParameterOperand).TheParameter == P) {
							Optn.Arguments[i] = LocalVariableOperand.GetSameRef(Optn.Arguments[i] as ParameterOperand, LV);
						}
					}
				}
			}
		}

		/// <summary>
		/// Replaces references to a LocalVariable by a reference to another LocalVariable
		/// </summary>
		public void ReplaceRef(LocalVariable OriginalLV, LocalVariable NewLV) {
			if(OriginalLV == null) throw new ArgumentNullException("OriginalLV");
			if(NewLV == null) throw new ArgumentNullException("NewLV");
			foreach(Operation Optn in Operations) {
				if(Optn.Result != null && Optn.Result is LocalVariableOperand && (Optn.Result as LocalVariableOperand).TheLV == OriginalLV) Optn.Result = LocalVariableOperand.GetSameRef(Optn.Result as LocalVariableOperand, NewLV);
				if(Optn.Arguments != null) {
					for(int i = 0 ; i < Optn.Arguments.Length ; i++) {
						if(Optn.Arguments[i] is LocalVariableOperand && (Optn.Arguments[i] as LocalVariableOperand).TheLV == OriginalLV) {
							Optn.Arguments[i] = LocalVariableOperand.GetSameRef(Optn.Arguments[i] as LocalVariableOperand, NewLV);
						}
					}
				}
			}
		}
	}
}
