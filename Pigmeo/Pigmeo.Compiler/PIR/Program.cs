using System;
using System.Collections.Generic;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;
using PRefl = Pigmeo.Internal.Reflection;

namespace Pigmeo.Compiler.PIR {
	/// <summary>
	/// Represents a software program/application
	/// </summary>
	// Note for developers: write properties and methods for work with strings rather than objects, and found the associated object dinamically. It's much easier to modify a PIR Program if we work with strings instead of object references
	public abstract class Program {
		public string Name;
		public TypeCollection Types = new TypeCollection();

		/// <summary>
		/// Generates a PIR of a Program from a .NET executable file
		/// </summary>
		public static Program GetFromFile(string File) {
			return GetFromCIL(PRefl.Assembly.GetFromFile(File));
		}

		#region properties
		/// <summary>
		/// All the information about the target device. The microcontroller this app is being compiled for
		/// </summary>
		public InfoDevice Target {
			get {
				return _Target;
			}
		}
		protected InfoDevice _Target;

		/// <summary>
		/// Gets a reference to the object that represents the Entry Point of this program. Returns null if there is no EntryPoint assigned
		/// </summary>
		public Method EntryPoint {
			get {
				foreach(Type t in Types) {
					foreach(Method m in t.Methods) {
						if(m.IsEntryPoint) return m;
					}
				}
				return null;
			}
		}

		public int ClassCount {
			get {
				int c = 0;
				foreach(Type T in Types) {
					if(T is Class) c++;
				}
				return c;
			}
		}

		public int StructCount {
			get {
				int c = 0;
				foreach(Type T in Types) {
					if(T is Struct) c++;
				}
				return c;
			}
		}

		public int MethodCount {
			get {
				int c = 0;
				foreach(Type T in Types) {
					c += T.Methods.Count;
				}
				return c;
			}
		}
		#endregion

		/// <summary>
		/// Instantiates a new PIR.PIC.Program
		/// </summary>
		/// <remarks>
		/// Almost everything is retrieved from the reflected assembly at PIR.Program.GetFromCIL(), not here
		/// </remarks>
		public Program(PRefl.Assembly ReflectedAssembly) {
			Name = ReflectedAssembly.Name;
			_Target = ReflectedAssembly.Target;
		}

		#region PIRefl->PIR
		/// <summary>
		/// Generates a PIR of a Program from a Reflected assembly
		/// </summary>
		public static Program GetFromCIL(PRefl.Assembly ReflectedAssembly) {
			ShowInfo.InfoDebug("Converting the reflected assembly {0} to PIR. Entrypoint: {1}", ReflectedAssembly.Name, ReflectedAssembly.EntryPoint.FullName);
			Program NewProg = null;
			switch(ReflectedAssembly.Target.Architecture) {
				case Architecture.PIC:
					NewProg = new PIC.Program(ReflectedAssembly);
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "FE0008", true, ReflectedAssembly.Target.Architecture);
					break;
			}
			NewProg.ParseMethod(ReflectedAssembly.EntryPoint);
			return NewProg;
		}

		/// <summary>
		/// If the given method doesn't exist, the method and all of its dependencies are converted to PIR and added to this Program
		/// </summary>
		// Note for developers: don't change the order of the operations in ParseMethod() or Pigmeo.Compiler won't work
		protected void ParseMethod(PRefl.Method MethodBeingParsed) {
			ShowInfo.InfoDebug("If the Method {0} doesn't exist it will be converted to PIR and added to the PIR Program", MethodBeingParsed.FullNameWithAssembly);
			if(!Types.Contains(MethodBeingParsed.ParentType.FullName) || !Types[MethodBeingParsed.ParentType.FullName].Methods.AnyDerivesFrom(MethodBeingParsed)) {
				ShowInfo.InfoDebug("The Method {0} must be parsed", MethodBeingParsed.FullNameWithAssembly);

				//first we parse its dependencies (parent type, return type and types of its parameters)
				ParseType(MethodBeingParsed.ParentType);
				ParseType(MethodBeingParsed.ReturnType);
				foreach(KeyValuePair<ushort, PRefl.Parameter> pair in MethodBeingParsed.Parameters) ParseType(pair.Value.ParamType);

				//now the method is created
				Method NewMethod = Method.NewByArch(this, MethodBeingParsed);
				NewMethod.ParentType.Methods.Add(NewMethod);

				if(!NewMethod.IsInternalImpl) {
					//parse the fields it references
					foreach(PRefl.Field RefField in MethodBeingParsed.ReferencedFields) {
						ParseField(RefField);
					}

					//parse other methods this method references
					foreach(PRefl.Method RefMethod in MethodBeingParsed.ReferencedMethods) {
						ParseMethod(RefMethod);
					}

					//parse its (reflected) local variables
					foreach(PRefl.LocalVariable LocalVar in MethodBeingParsed.LocalVariables.Values) {
						ParseType(LocalVar.VariableType);
						LocalVariable NewLocalVar = LocalVariable.NewByArch(NewMethod, LocalVar);
						NewMethod.LocalVariables.Add(NewLocalVar);
					}

					//finally convert its original (reflected) instructions to PIR operations
					foreach(PRefl.Instruction Instr in MethodBeingParsed.Instructions) {
						Operation NewPirOperation = Operation.GetFromPRefl(Instr, NewMethod);
						if(NewPirOperation != null) NewMethod.Operations.Add(NewPirOperation);
						else ShowInfo.InfoDebug("CIL instruction {0} is not converted into PIR", Instr);
					}
				}
			}
		}

		/// <summary>
		/// If the given Field doesn't exist, the Field and all of its dependencies (its declaring type and the Field's type) are converted to PIR (if needed) and added to this Program
		/// </summary>
		protected void ParseField(PRefl.Field FieldBeingParsed) {
			ShowInfo.InfoDebug("If the Field {0} doesn't exist it will be converted to PIR and added to the PIR Program", FieldBeingParsed.FullNameWithAssembly);
			//if this Field's parent type doesn't exist, or this Field doesn't exist...
			if(!Types.Contains(FieldBeingParsed.ParentType.FullName) || !Types[FieldBeingParsed.ParentType.FullName].Fields.Contains(FieldBeingParsed.Name)) {
				ShowInfo.InfoDebug("The Field {0} must be parsed", FieldBeingParsed.FullNameWithAssembly);

				//first we parse its dependencies (parent type and its own type)
				ParseType(FieldBeingParsed.ParentType);
				ParseType(FieldBeingParsed.FieldType);
				
				Field NewField = Field.NewByArch(this, FieldBeingParsed); //new Field(this, FieldBeingParsed);
				NewField.ParentType.Fields.Add(NewField);
			}
		}

		/// <summary>
		/// If the given type doesn't exist, the type and all of its dependencies are converted to PIR and added to this Program
		/// </summary>
		/// <returns>
		/// The given method conterted to PIR
		/// </returns>
		protected Type ParseType(PRefl.Type TypeBeingParsed) {
			ShowInfo.InfoDebug("Retrieving the type {0}. We don't know if it exists or it must be created", TypeBeingParsed.FullNameWithAssembly);
			if(Types.Contains(TypeBeingParsed.FullName)) return Types[TypeBeingParsed.FullName];
			else {
				ShowInfo.InfoDebug("The type {0} hasn't been converted to PIR yet", TypeBeingParsed.FullNameWithAssembly);
				Type NewType = null;
				if(TypeBeingParsed.IsValueType) {
					if(TypeBeingParsed.IsEnum) {
						NewType = Enum.NewByArch(this, TypeBeingParsed, false);
					} else if(TypeBeingParsed.FullName == "System.Byte") {
						NewType = VT_UInt8.NewByArch(this, TypeBeingParsed, false);
					} else if(TypeBeingParsed.FullName == "System.SByte") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "SByte struct");
					} else if(TypeBeingParsed.FullName == "System.UInt16") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "UInt16 struct");
					} else if(TypeBeingParsed.FullName == "System.Int16") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Int16 struct");
					} else if(TypeBeingParsed.FullName == "System.UInt32") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "UInt32 struct");
					} else if(TypeBeingParsed.FullName == "System.Int32") {
						NewType = VT_Int32.NewByArch(this, TypeBeingParsed, false);
					} else if(TypeBeingParsed.FullName == "System.UInt64") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "UInt64 struct");
					} else if(TypeBeingParsed.FullName == "System.Int64") {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Int64 struct");
					} else if(TypeBeingParsed.FullName == "System.Boolean") {
						NewType = VT_Bool.NewByArch(this, TypeBeingParsed, false);
					} else {
						NewType = Struct.NewByArch(this, TypeBeingParsed, false);
					}
				} else {
					if(TypeBeingParsed.IsInterface) {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Interfaces");
					} else if(TypeBeingParsed.IsClass) {
						NewType = Class.NewByArch(this, TypeBeingParsed, false);
					}
				}
				if(NewType == null) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Type of PRefl.Type " + TypeBeingParsed.FullNameWithAssembly + " unknown");
				if(TypeBeingParsed.BaseType != null) NewType.BaseType = ParseType(TypeBeingParsed.BaseType);
				Types.Add(NewType);
				return NewType;
			}
		}
		#endregion

		/// <summary>
		/// Returns an exact copy of this Program and all of its members (types, methods, fields...)
		/// </summary>
		/// <returns></returns>
		[PigmeoToDo("Not implemented")]
		public Program Clone() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
			return null;
		}

		/// <summary>
		/// Avoid copying values back and forth to the TOSS, as .NET does. Make operation work with operands directly instead of working always with the TOSS
		/// </summary>
		/// <returns>True if something was modified</returns>
		public bool AvoidTOSS() {
			bool mod = false;
			foreach(Type SomeType in Types) {
				foreach(Method SomeMethod in SomeType.Methods) {
					if(SomeMethod.AvoidTOSS()) mod = true;
				}
			}
			return mod;
		}

		/// <summary>
		/// Removes unused classes, methods, fields... so the resulting Program contains only the members that are really going to be executed
		/// </summary>
		/// NOTE FOR DEVELOPERS: When Pigmeo Compiler generates a PIR Program from a reflected assembly, only used members are added to the Program. This method is called because after generating the PIR Program it's heavily modified and optimized, and some members may not be used anymore
		public bool RemoveUnused() {
			bool Modified = false;
			Stack<Method> NotParsed = new Stack<Method>();
			List<Method> UsedMethods = new List<Method>();
			NotParsed.Push(EntryPoint);
			UsedMethods.Add(EntryPoint);

			//create the list of used methods
			while(NotParsed.Count > 0) {
				Method CurrentMethod = NotParsed.Pop();
				foreach(Method M in CurrentMethod.ReferencedMethods) {
					if(!UsedMethods.Contains(M)) {
						UsedMethods.Add(M);
						NotParsed.Push(M);
					}
				}
			}

			//remove unused methods
			foreach(Type T in Types) {
				List<Method> Rem = new List<Method>(); //collection of methods being removed from this Type
				foreach(Method M in T.Methods) {
					if(!UsedMethods.Contains(M)) {
						Rem.Add(M);
					}
				}
				foreach(Method M in Rem) {
					T.Methods.Remove(M);
				}
			}

			return Modified;
		}

		/// <summary>
		/// Remove InLine Methods that should be implemented internally but haven't been implemented yet. These methods retain calls to them, but the method reference is removed from the list of methods on its parent type
		/// </summary>
		/// <remarks>
		/// We only remove its definition, not the call. That call will be replaced by the internal implementation later in the compilation process</remarks>
		public bool RemoveInlineInternalImpl() {
			bool Modified = false;
			foreach(Type T in Types) {
				List<Method> Rem = new List<Method>(); //collection of methods being removed from this Type
				foreach(Method M in T.Methods) {
					if(M.InLine && M.IsInternalImpl) {
						Rem.Add(M);
					}
				}
				foreach(Method M in Rem) {
					T.Methods.Remove(M);
					Modified = true;
				}
			}
			return Modified;
		}

		/// <summary>
		/// Find methods so short that is more efficient inlining than calling them, and set them the Inline property
		/// </summary>
		[PigmeoToDo("Should be reimplemented more efficiently")]
		public void FindShortInlinizableMethods() {
			#region innefficient implementation
			foreach(Type T in Types) {
				if(T.Methods != null) {
					foreach(Method M in T.Methods) {
						if(M.Operations != null && M.Operations.Count < 3) {
							M.InLine = true;
						}
					}
				}
			}
			#endregion


			/* More efficient implementation:
			 * 
			 * As seen in http://blogs.msdn.com/vancem/archive/2008/08/19/to-inline-or-not-to-inline-that-is-the-question.aspx
			 * 
			 * 1.     Estimate the size of the call site if the method were not inlined.
			 * 2.     Estimate the size of the call site if it were inlined (this is an estimate based on the IL, we employ a simple state machine (Markov Model), created using lots of real data to form this estimator logic)
			 * 3.     Compute a multiplier.   By default it is 1 
			 * 4.     Increase the multiplier if the code is in a loop (the current heuristic bumps it to 5 in a loop)
			 * 5.     Increase the multiplier if it looks like struct optimizations will kick in. 
			 * 6.     If InlineSize  <= NonInlineSize * Multiplier do the inlining. 
			 */
		}

		/// <summary>
		/// Find methods that are called from only one place, so it's more efficient to replace the call by its code
		/// </summary>
		public void FindSingleCallInlinizable() {
			Dictionary<Method, UInt32> MethodCalls = new Dictionary<Method, uint>(); ;

			#region get the amount of calls to each method
			foreach(Type T in Types) {
				if(T.Methods != null) {
					foreach(Method M in T.Methods) {
						if(M.Operations != null) {
							foreach(Operation Opn in M.Operations) {
								if(Opn.Arguments != null) {
									foreach(Operand Opd in Opn.Arguments) {
										if(Opd is MethodOperand) {
											MethodOperand MOpd = (MethodOperand)Opd;
											if(!MethodCalls.ContainsKey(MOpd.TheMethod)) MethodCalls.Add(MOpd.TheMethod, 1);
											else MethodCalls[MOpd.TheMethod]++;
										}
									}
								}
							}
						}
					}
				}
			}
			#endregion

			foreach(KeyValuePair<Method, UInt32> pair in MethodCalls) {
				if(pair.Value == 1) pair.Key.InLine = true;
			}
		}

		/// <summary>
		/// Find objects that are always in the heap (never Garbage Collected) and convert their fields and staticalize them
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void Deobjectize() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Deobjectize");
		}

		/// <summary>
		/// Bundles a bunch of bools in a single register. It's much more memory-efficient but usually requires more instruction cycles to access them
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void PackBools() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "Pack bools");
		}

		/// <summary>
		/// All required type initilizations are executed before running the application. It's usually more efficient since it doesn't need to check again and again if the type initializer has been already called each time an object is instantiated or a static member is referenced
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void CallStaticConstructorsBeforeEntryPoint() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true, "CallStaticConstructorsBeforeEntryPoint");
		}

		/// <summary>
		/// Methods whose arguments are all constant and NONE of their operations read or write to non-local variables can be replaced entirely by the value they return
		/// </summary>
		/// <example>
		/// int a = Math.Cos(0); //can be replaced by...
		/// int a = 1;
		/// </example>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeFullMethods() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Methods whose arguments are all constant, none of their operations read to non-local variables and some of their operations write to non-local variables can be replaced by simple assignations of constants to non-local variables
		/// </summary>
		/// <remarks>
		/// This is useful for example when calling Pigmeo.MCU.TMR0.Configure(...) (found in most PIC device libraries). The Configure() method usually takes constant parameters, do a bunch of arithmetic operations and then write the results to some registers. So all those operations can be done at compile-time and the resulting program should contain just the assignment of constant values
		/// </remarks>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeMethodsWConstArgs() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Finds all methods marked as InLine and replaces all the calls to them by their instructions/operations
		/// </summary>
		/// <returns>
		/// True if at least one method was inlined. False is none was changed
		/// </returns>
		public bool InLineAll() {
			bool Modified = false;

			if(RemoveInlineInternalImpl()) Modified = true;

			foreach(Type T in Types) {
				if(T.Methods != null) {
					foreach(Method M in T.Methods) {
						if(M.Operations != null) {
							foreach(Operation Opn in M.Operations) {
								if(Opn is Call) {
									Call OCall = (Call)Opn;
									if(OCall.CalledMethod.InLine && !OCall.CalledMethod.IsInternalImpl) {
										OCall.InLine();
										return true; //we can't keep inlining because all TypeCollections and MethodCollections may have changed. More inlinizations will be done the next time InLineAll() is called
									}
								}
							}
						}
					}
				}
			}

			return Modified;
		}


		/// <summary>
		/// Implements (in PIR) internally implemented methods (when possible)
		/// </summary>
		/// <returns>
		/// True if at least one method was implemented internally. False is none was changed
		/// </returns>
		/// NOTE FOR DEVELOPERS: PIR internal implementations are called when optimizing the PIR Program instead of when generating the method from Reflection because we need to AvoidTOSS() before implementing some of these methods
		public bool ImplementInternally() {
			bool Modified = false;
			foreach(Type T in Types) {
				foreach(Method M in T.Methods) {
					//methods entirely implemented in PIR
					if(M.IsInternalImpl) {
						if(M.Implement()) Modified = true;
					}

					//Calls to Methods that are implemented in PIR (the entire call is replaced, not just the called method)
					for(int OpIndex = 0 ; OpIndex < M.Operations.Count ; OpIndex++) {
						Operation O = M.Operations[OpIndex];
						#region HARDCODED INTERNAL IMPLEMENTATIONS. These internal implementations can't be marked as [InternalImplementation] because they are not always internally implemented. For example, they may be internally implemented only when they are called with constant parameters, and use the managed implementation everywhere else
						#region call to System.Byte Pigmeo.Extensions.uint8Extensions::SetBit(System.Byte b, System.Byte bit, System.Boolean value)
						if(O is Call) {
							Call OCall = O as Call;
							Method CalledMethod = OCall.CalledMethod;
							if(CalledMethod.ParentType.Name == "Pigmeo.Extensions.uint8Extensions" && CalledMethod.Name == "SetBit" && CalledMethod.Parameters[0].ParamType.Name == "System.Byte" && CalledMethod.Parameters[0].Name == "b" && CalledMethod.Parameters[1].ParamType.Name == "System.Byte" && CalledMethod.Parameters[1].Name == "bit" && CalledMethod.Parameters[2].ParamType.Name == "System.Boolean" && CalledMethod.Parameters[2].Name == "value" && OCall.Arguments[2] is ConstantInt32Operand && OCall.Result == OCall.Arguments[1]) {
								ShowInfo.InfoDebugDecompile("Implementing internally the following operation", O);
								Operand OriginOperand = OCall.Arguments[3];
								Operand Result = null;
								byte bit = (byte)(OCall.Arguments[2] as ConstantInt32Operand).Value;
								if(OCall.Arguments[1] is FieldValueOperand) Result = new FieldBitOperand((OCall.Arguments[1] as FieldValueOperand).TheField, bit);
								else if(OCall.Arguments[1] is ParameterValueOperand) Result = new ParameterBitOperand((OCall.Arguments[1] as ParameterValueOperand).TheParameter, bit);
								if(Result != null) {
									Modified = true;
									Operation NewOp = new Copy(O.ParentMethod, OriginOperand, Result);
									M.Operations[OpIndex] = NewOp;
									ShowInfo.InfoDebugDecompile("Implemented internally as...", M.Operations[OpIndex]);
								} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", true, "Trying to set the value of a bit, but it's not a Field or a Parameter, so I don't know how to do it");
							}
						}
						#endregion
						#endregion
					}
				}
			}
			return Modified;
		}

		/// <summary>
		/// Removes dumb temporal variables. That is, LocalVariables, Parameters or Fields that have a value assigned to them, that value never changes, and the original source doesn't change either, so we can avoid assigning that value to the "dumb" variable and replace references to the dumb variable by references to the original source or value
		/// </summary>
		/// <returns>True if at least one method had dumb vars and were removed</returns>
		public bool RemoveDumbTempVars() {
			bool Modified = false;
			foreach(Type T in Types) {
				foreach(Method M in T.Methods) {
					if(M.RemoveDumbTempVars()) Modified = true;
				}
			}
			return Modified;
		}

		/// <summary>
		/// Removes Local Variables never used
		/// </summary>
		/// <returns>True if at least one method had dead Local Variables and were removed</returns>
		public bool RemoveDeadLV() {
			bool Modified = false;
			foreach(Type T in Types) {
				foreach(Method M in T.Methods) {
					if(M.RemoveDeadLV()) Modified = true;
				}
			}
			return Modified;
		}

		/// <summary>
		/// Converts all local members of the EntryPoint to static fields
		/// </summary>
		/// <remarks>
		/// The EntryPoint should never be called from within the program, and in standalone applications it's never called from the outside, so it's safe to to this
		/// </remarks>
		public void StaticalizeEntryPointFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Converts all local members of all methods to static fields. Resulting methods are faster but cannot be re-entered
		/// </summary>
		public void StaticalizeAllLocalFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Find variables that are assigned only once and mark them as contastant
		/// </summary>
		/// <remarks>
		/// Fields should be constantized BEFORE constantizing methods
		/// </remarks>
		[PigmeoToDo("Not implemented")]
		public void ConstantizeFields() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		/// <summary>
		/// Converts all operations with enums to arithmetic operations using their base type
		/// </summary>
		[PigmeoToDo("Not implemented")]
		public void SimplifyEnums() {
			ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", true);
		}

		public override string ToString() {
			string Output = "";
			Output += "Target architecture: " + Target.Architecture.ToString() + "\n";
			Output += "Target family: " + Target.Family.ToString() + "\n";
			Output += "Target branch: " + Target.Branch.ToString() + "\n";
			Output += "Entry point: " + ((EntryPoint == null) ? "NULL" : EntryPoint.FullName) + "\n\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output.TrimEnd('\n');
		}
	}
}
