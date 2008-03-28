using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;

namespace Pigmeo.Compiler.BackendPIC14 {
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
			protected int pos{
				get{
					return _pos;
				}
				set {
					_pos = value;
					instr.Clear();
					for(int i = 0 ; i < OriginalMethod.Body.Instructions.Count - pos ; i++) {
						instr.Add(i, OriginalMethod.Body.Instructions[pos + i]);
					}
					ShowInfo.InfoDebug("OriginalMethod has {0} instructions. We are at instruction {1}. Now instr[] has {2} instructions", OriginalMethod.Body.Instructions.Count, pos, instr.Count);
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
				for(pos = 0 ; instr.Count>0 ;) {
					//NOTE: in each condition you MUST increment 'pos' by the amount of instructions parsed in that condition
					if(instr[0].IsLdc() && instr[1].OpCode == OpCodes.Stsfld) {
						_AsmCode.Instructions.AddRange(StoreCnstInStatVar(instr[0], instr[1]));
						pos += 2;
					} else {
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0003", false, instr[0].OpCode.ToString());
						pos += 1;
					}
				}
			}

			/// <summary>
			/// A constant must be stored in a registers. It is a 'ldc' followed by a stsfld
			/// </summary>
			protected List<AsmInstruction> StoreCnstInStatVar(Instruction ldc, Instruction stsfld) {
				ShowInfo.InfoDebug("Generating assembly code for storing the constant {0} into static variable {1} ({2})", ldc.OpCode.ToString(), (stsfld.Operand as FieldReference).DeclaringType.FullName+"."+(stsfld.Operand as FieldReference).Name, (stsfld.Operand as FieldReference).FieldType.FullName);
				
				List<AsmInstruction> instrs = new List<AsmInstruction>();
				/* WORK IN PROGRESS
				switch(stsfld.Operand.GetType().FullName) {
					case typeof(byte).FullName:
						ShowInfo.InfoDebug("This constant is being stored as a uint8 ({0})", typeof(byte).FullName);
						break;
				}*/

				return instrs;
			}
		}
	}
}
