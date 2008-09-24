using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.BackendPIC {
	public static partial class CompileToAsm {
		/// <summary>
		/// Represents a function/method already compiled into assembly language
		/// </summary>
		public class CompiledStaticFunction {
			/// <summary>
			/// The original MethodDefinition of this function
			/// </summary>
			public readonly MethodDefinition OriginalMethod;

			/// <summary>
			/// The current position when parsing the instructions of the method
			/// </summary>
			protected int pos {
				get {
					return _pos;
				}
				set {
					_pos = value;
					instr.Clear();
					for(int i = 0 ; i < OriginalMethod.Body.Instructions.Count - pos ; i++) {
						instr.Add(i, OriginalMethod.Body.Instructions[pos + i]);
					}
					ShowInfo.InfoDebug("Method {0} has {1} instructions. We are at instruction {2}. Now instr[] has {3} instructions", OriginalMethod.Name, OriginalMethod.Body.Instructions.Count, pos, instr.Count);
				}
			}
			protected int _pos;

			/// <summary>
			/// A collection of instructions containing from the current instruction to the end of the method's body. instr[0] is the current instruction, instr[1] is the next instruction, instr[2] follows instr[1] and so on
			/// </summary>
			protected Dictionary<int, Instruction> instr;

			/// <summary>
			/// Normalized name of the function that will be used to call it in assembly language
			/// </summary>
			public string AsmName {
				get {
					if(_AsmName == null) {
						if(GlobalShares.AssemblyToCompile.EntryPoint == OriginalMethod)
							_AsmName = "EntryPoint";
						else {
							_AsmName = OriginalMethod.Name.Replace('.', '_');
						}
					}
					return _AsmName;
				}
			}
			private string _AsmName;

			/// <summary>
			/// Gets the compiled code of this funcion
			/// </summary>
			public Asm AsmCode {
				get {
					return _AsmCode;
				}
			}
			private Asm _AsmCode;


			public CompiledStaticFunction(MethodDefinition method) {
				OriginalMethod = method;
				instr = new Dictionary<int, Instruction>(OriginalMethod.Body.Instructions.Count);
				Compile();
			}

			/// <summary>
			/// Compiles this method to assembly language
			/// </summary>
			protected void Compile() {
				ShowInfo.InfoDebug("Compiling static method {0}", OriginalMethod.Name);
				_AsmCode = new Asm();
				_AsmCode.Instructions.Add(new Label(AsmName, ""));
				for(pos = 0 ; instr.Count > 0 ; ) {
					List<AsmInstruction> NewInstrs = new List<AsmInstruction>();
					int UsedInstrs = 0;
					try {
						if(instr[0].IsLdc() && instr[1].OpCode == OpCodes.Stsfld) {
							#region constant to byte
							/* 
						 * ldc.*
						 * stsfld
						 */
							NewInstrs = StoreCnstInStatVar(instr[0], instr[1]);
							UsedInstrs = 2;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ret) {
							#region ret
							if(OriginalMethod.IsEntryPoint()) {
								ShowInfo.InfoDebug("Returning from the entrypoint");
								NewInstrs.Add(new GOTO("", "EndOfApp", "ret"));
								UsedInstrs = 1;
							} else {
								ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false, "Return from a static method");
								//pos += 1;
								UsedInstrs = 1;
							}
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ldsfld && instr[1].OpCode == OpCodes.Stsfld) {
							#region copy a register
							/* 
						 * ldsfld
						 * stsfld
						 */
							NewInstrs = CopyRegister(instr[0], instr[1]);
							UsedInstrs = 2;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ldsfld && (instr[0].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName && instr[1].IsLdc() && instr[2].OpCode == OpCodes.Add && instr[3].OpCode == OpCodes.Conv_U1 && instr[4].OpCode == OpCodes.Stsfld && (instr[4].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName) {
							#region increment an uint8 static variable
							/* 
						 * ldsfld uint8
						 * ldc.*
						 * add
						 * conv.u1
						 * stsfld uint8
						 */
							NewInstrs = IncrStatVar(instr[0], instr[1]);
							UsedInstrs = 5;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ldsfld && (instr[0].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName && instr[1].IsLdc() && instr[2].OpCode == OpCodes.Sub && instr[3].OpCode == OpCodes.Conv_U1 && instr[4].OpCode == OpCodes.Stsfld && (instr[4].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName) {
							#region decrement an uint8 static variable
							/* 
						 * ldsfld uint8
						 * ldc.*
						 * sub
						 * conv.u1
						 * stsfld uint8
						 */
							NewInstrs = DecrStatVar(instr[0], instr[1]);
							UsedInstrs = 5;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Br_S) {
							#region break/goto/jump
							string JumpTo = GetAsmLabel(instr[0].Operand as Instruction);
							ShowInfo.InfoDebug("Generating assembly code for jumping to label {0}", JumpTo);
							NewInstrs.Add(new GOTO("", JumpTo, "br.s"));
							UsedInstrs = 1;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ldsfld && (instr[0].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName && instr[1].IsLdc() && instr[2].OpCode == OpCodes.Add_Ovf && instr[3].OpCode == OpCodes.Conv_Ovf_U1 && instr[4].OpCode == OpCodes.Stsfld && (instr[4].Operand as FieldReference).FieldType.FullName == typeof(byte).FullName) {
							#region increment an uint8 static variable with overflow check
							/* 
						 * ldsfld uint8
						 * ldc.*
						 * add.ovf
						 * conv.ovf.u1
						 * stsfld uint8
						 */
							NewInstrs = IncrStatVarWOvrflwChck(instr[0], instr[1]);
							UsedInstrs = 5;
							#endregion
						} else if(instr[0].OpCode == OpCodes.Ldsfld && instr[1].IsLdc() && instr[2].OpCode == OpCodes.Bgt_S) {
							#region if(StaticField > number) jump
							/*
						 * ldsfld
						 * ldc
						 * bgt
						 */
							NewInstrs = JumpIfStaticVarBiggerThanNumber(instr[0], instr[1], instr[2]);
							UsedInstrs = 3;
							#endregion
						} else if(IsStaticFunctionCall(instr, out UsedInstrs)){
							#region call to static function
							NewInstrs = CallStatMethod(instr);
							//UsedInstrs was already assigned
							#endregion
						} else {
							string instrs = "";
							foreach(Instruction inst in instr.Values) {
								instrs += inst.OpCode.ToString() + ", ";
							}
							instrs = instrs.Substring(0, instrs.Length - 2);
							ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0003", false, instrs);
							UsedInstrs = 1;
						}
					} catch(Exception e) {
						if(ErrorsAndWarnings.TotalErrors > 0) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0008", false);
						else throw e;
					}

					NewInstrs[0].label = GetAsmLabel(instr[0]); //we only need labels on the first instruction of the block
					_AsmCode.Instructions.AddRange(NewInstrs);
					pos += UsedInstrs;
				}
			}

			/// <summary>
			/// Gets the label of an assembly language instruction based on the position of the first CIL instruction in the block of instruction from where it was generated
			/// </summary>
			/// <param name="instr">Original CIL instruction</param>
			protected string GetAsmLabel(Instruction instr) {
				return String.Format("{0}_I{1}", OriginalMethod.Name, OriginalMethod.Body.Instructions.IndexOf(instr));
			}


			protected bool IsStaticFunctionCall(Dictionary<int, Instruction> instrs, out int AmountUsefulInstrs) {
				ShowInfo.InfoDebug("Testing whether it is a static function call or not");
				int pos = 0;
				for( ; (pos < instrs.Count - 1)&&instrs[pos].PushesIntoStack() ; pos++);
				AmountUsefulInstrs = pos;
				if(instrs[pos].CallsStaticFunction()) return true;
				else return false;
			}

			/// <summary>
			/// A constant must be stored in a registers. It is a 'ldc' followed by a stsfld
			/// </summary>
			protected List<AsmInstruction> StoreCnstInStatVar(Instruction ldc, Instruction stsfld) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				FieldReference StsfldOperand = stsfld.Operand as FieldReference;
				ShowInfo.InfoDebug("Generating assembly code for storing a constant into static variable {0} ({1})", StsfldOperand.DeclaringType.FullName + "." + StsfldOperand.Name, StsfldOperand.FieldType.FullName);

				if(StsfldOperand.FieldType.FullName == typeof(byte).FullName) {
					#region constant to byte
					string VarName = StsfldOperand.Name;
					byte VarValue = 0;

					//get the constant value
					if(ldc.IsLdcI4()) VarValue = Convert.ToByte(ldc.GetLdcI4Value());
					else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0003", false, ldc.OpCode.Name);

					ShowInfo.InfoDebug("The constant value {0} is being stored as a uint8/System.Byte to \"{1}\"", VarValue, VarName);

					GeneratedInstrs.Add(new MOVLW("", VarValue, ldc.OpCode.ToString()));
					GeneratedInstrs.Add(new MOVWF("", VarName, stsfld.OpCode.ToString() + " " + StsfldOperand.Name));
					#endregion
				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0004", false, StsfldOperand.FieldType.FullName);
				return GeneratedInstrs;
			}

			/// <summary>
			/// Copies a static variable to another static variable
			/// </summary>
			/// <param name="origin">Origin static variable</param>
			/// <param name="dest">Destination static variable</param>
			protected List<AsmInstruction> CopyRegister(Instruction origin, Instruction dest) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				FieldReference OriginOp = origin.Operand as FieldReference;
				FieldReference DestOp = dest.Operand as FieldReference;
				ShowInfo.InfoDebug("Generating assembly code for copying static variable {0} to static variable {1}", OriginOp.Name, DestOp.Name);

				if(OriginOp.FieldType.FullName == typeof(byte).FullName && DestOp.FieldType.FullName == typeof(byte).FullName) {
					#region byte to byte
					string OriginName = OriginOp.Name;
					string DestName = DestOp.Name;
					GeneratedInstrs.Add(new MOVF("", OriginName, Destination.W, origin.OpCode.ToString()));
					GeneratedInstrs.Add(new MOVWF("", DestName, dest.OpCode.ToString()));
					#endregion
				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0004", false, OriginOp.FieldType.FullName + " || " + DestOp.FieldType.FullName);

				return GeneratedInstrs;
			}

			/// <summary>
			/// Increments a static variable by a constant
			/// </summary>
			/// <param name="LoadVar">Instruction which loads the current value</param>
			/// <param name="LdcInstr">Instruction which loads a constant on top of the stack and will be added to the variable</param>
			protected List<AsmInstruction> IncrStatVar(Instruction LoadVar, Instruction LdcInstr) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				// Name of the static variable being incremented
				string VarName = (LoadVar.Operand as FieldReference).Name;

				// Constant value which is added to its previous value
				byte IncrVal = Convert.ToByte(LdcInstr.GetLdcI4Value());

				ShowInfo.InfoDebug("Generating assembly code for incrementing static variable {0} by {1}", VarName, IncrVal);

				if(IncrVal == 1) {
					GeneratedInstrs.Add(new INCF("", VarName, Destination.F, "ldsfld uint8, ldc.*, add, conv.u1, stsfld uint8"));
				} else {
					GeneratedInstrs.Add(new MOVLW("", IncrVal, "ldc.*"));
					GeneratedInstrs.Add(new ADDWF("", VarName, Destination.F, "ldsfld uint8...add...stsfld uint8"));
				}

				return GeneratedInstrs;
			}

			/// <summary>
			/// Increments a static variable and then checks if it overflowed
			/// </summary>
			/// <param name="LoadVar">Instruction which loads the current value</param>
			/// <param name="LdcInstr">Instruction which loads a constant on top of the stack and will be added to the variable</param>
			protected List<AsmInstruction> IncrStatVarWOvrflwChck(Instruction LoadVar, Instruction LdcInstr) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				// Name of the static variable being incremented
				string VarName = (LoadVar.Operand as FieldReference).Name;

				// Constant value which is added to its previous value
				byte IncrVal = Convert.ToByte(LdcInstr.GetLdcI4Value());

				ShowInfo.InfoDebug("Generating assembly code for incrementing static variable \"{0}\" by {1} and checking if overflowed", VarName, IncrVal);

				//incrementing
				if(IncrVal == 1) {
					GeneratedInstrs.Add(new INCF("", VarName, Destination.F, "ldsfld uint8, ldc.*, add, conv.u1, stsfld uint8"));
				} else {
					GeneratedInstrs.Add(new MOVLW("", IncrVal, "ldc.*"));
					GeneratedInstrs.Add(new ADDWF("", VarName, Destination.F, "ldsfld uint8...add...stsfld uint8"));
				}

				//check overflow
				switch(config.Compilation.Exceptions) {
					case ImplExceptions.None:
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0006", false, i18n.str(142));
						break;
					case ImplExceptions.EndProgram:
						GeneratedInstrs.Add(new BTFSC("", "STATUS", new UInt3(false, false, false), i18n.str(144)));
						GeneratedInstrs.Add(new GOTO("", "EndOfApp", i18n.str(152)));
						break;
					default:
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0005", false);
						break;
				}

				return GeneratedInstrs;
			}

			/// <summary>
			/// Decrements a static variable by a constant
			/// </summary>
			/// <param name="LoadVar">Instruction which loads the current value</param>
			/// <param name="LdcInstr">Instruction which loads a constant on top of the stack and will be substracted from the variable</param>
			protected List<AsmInstruction> DecrStatVar(Instruction LoadVar, Instruction LdcInstr) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				// Name of the static variable being decremented
				string VarName = (LoadVar.Operand as FieldReference).Name;

				// Constant value which is substracted from its previous value
				byte DecrVal = Convert.ToByte(LdcInstr.GetLdcI4Value());

				ShowInfo.InfoDebug("Generating assembly code for decrementing static variable {0} by {1}", VarName, DecrVal);

				if(DecrVal == 1) {
					GeneratedInstrs.Add(new DECF("", VarName, Destination.F, "ldsfld uint8, ldc.*, sub, conv.u1, stsfld uint8"));
				} else {
					GeneratedInstrs.Add(new MOVLW("", DecrVal, "ldc.*"));
					GeneratedInstrs.Add(new SUBWF("", VarName, Destination.F, "ldsfld uint8...sub...stsfld uint8"));
				}

				return GeneratedInstrs;
			}

			/// <summary>
			/// Calls a static function
			/// </summary>
			/// <returns></returns>
			protected List<AsmInstruction> CallStatMethod(Dictionary<int, Instruction> instrs) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				ShowInfo.InfoDebug("Generating assembly code for calling a static method");
				if(instrs[0].CallsStaticFunction()) {
					ShowInfo.InfoDebug("Calling a parameter-less static method");
					GeneratedInstrs.Add(new Label("", instrs[0].Operand.ToString()));
				} else {
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0008", false);
				}

				return GeneratedInstrs;
			}

			/// <summary>
			/// Jumps to another instruction if a given static variable is bigger than a constant number
			/// </summary>
			/// <param name="LoadVar">Instruction which loads the static variable being tested</param>
			/// <param name="LdcInstr">Instruction which loads a constant value</param>
			/// <param name="JumpInstr">Instruction which jumps to another place if the condition is true</param>
			protected List<AsmInstruction> JumpIfStaticVarBiggerThanNumber(Instruction LoadVar, Instruction LdcInstr, Instruction JumpInstr) {
				List<AsmInstruction> GeneratedInstrs = new List<AsmInstruction>();

				string VarName = (LoadVar.Operand as FieldReference).Name;
				string StaticVarType = (LoadVar.Operand as FieldReference).FieldType.FullName;
				byte Num = Convert.ToByte(LdcInstr.GetLdcI4Value());
				string JumpTo = GetAsmLabel(JumpInstr.Operand as Instruction);

				ShowInfo.InfoDebug("Generating assembly code for jumping if the static variable [{0}]{1} is bigger than {2}", StaticVarType, VarName, Num);

				if(StaticVarType == typeof(byte).FullName) {
					GeneratedInstrs.Add(new MOVLW("", Num, "jumps when a uint8 static variable is bigger than a number"));
					GeneratedInstrs.Add(new SUBWF("", VarName, Destination.W, ""));
					GeneratedInstrs.Add(new BTFSC("", "STATUS", new UInt3(false, false, false), "bgt"));
					GeneratedInstrs.Add(new GOTO("", JumpTo, "jumping"));
				} else ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0004", false, StaticVarType);
				return GeneratedInstrs;
			}
		}
	}
}
