﻿using Mono.Cecil;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Collections.Generic;

namespace Pigmeo.Compiler.BackendPIC14 {
	public static partial class CompileToAsm {
		private static Asm AsmLangApp;
		private static Asm AsmHeader;
		private static Asm AsmDirectives;
		private static List<CompiledStaticFunction> StaticFunctions = new List<CompiledStaticFunction>();
		public static Dictionary<RegisterAddress, string> StaticVariables = new Dictionary<RegisterAddress, string>();

		/// <summary>
		/// Compiles the whole .NET assembly to assembly language
		/// </summary>
		/// <param name="assembly">.NET assembly to compile</param>
		/// <returns>The code in assembly language</returns>
		public static Asm Run(AssemblyDefinition assembly) {
			ShowInfo.InfoDebug("Compiling to 8-bit PIC assembly language");
			AsmLangApp = new Asm();

			#region compile all the parts
			ShowInfo.InfoDebug("Building header");
			BuildAsmHeader(assembly);
			ShowInfo.InfoDebug("Building directives");
			BuildAsmDirectives(assembly);
			ShowInfo.InfoDebug("Getting static variables");
			GetStaticVariables(assembly);
			ShowInfo.InfoDebug("Getting static functions");
			GetStaticFunctions(assembly);
			#endregion


			#region join all the parts
			ShowInfo.InfoDebug("Adding header");
			AsmLangApp.Instructions.AddRange(AsmHeader.Instructions);
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding directives");
			AsmLangApp.Instructions.AddRange(AsmDirectives.Instructions);
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding global variables");
			foreach(KeyValuePair<RegisterAddress,string> kv in StaticVariables) {
				switch(config.Internal.NumeralSystem) {
					case NumeralSystems.Binary:
						AsmLangApp.Instructions.Add(new EQU(kv.Value, "B'" + Convert.ToString(kv.Key.Address, 2) + "'", ""));
						break;
					case NumeralSystems.Decimal:
						AsmLangApp.Instructions.Add(new EQU(kv.Value, "D'" + Convert.ToString(kv.Key.Address, 10) + "'", ""));
						break;
					case NumeralSystems.Hexadecimal:
						AsmLangApp.Instructions.Add(new EQU(kv.Value, "0x" + kv.Key.Address.ToString("X2"), ""));
						break;
					case NumeralSystems.Octal:
						AsmLangApp.Instructions.Add(new EQU(kv.Value, "O'" + Convert.ToString(kv.Key.Address, 8) + "'", ""));
						break;
					default:
						ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0002", false, config.Internal.NumeralSystem.ToString());
						break;
				}
			}
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding EntryPoint and interrupts");
			AsmLangApp.Instructions.Add(new ORG("0x00", ""));
			AsmLangApp.Instructions.Add(new GOTO("", "EntryPoint", ""));
			AsmLangApp.Instructions.Add(new ORG("0x04", "interruption vector"));
			AsmLangApp.Instructions.Add(new GOTO("", "EndOfApp", "Interruptions not implemented"));
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding static functions");
			foreach(CompiledStaticFunction StaticFunct in StaticFunctions) {
				AsmLangApp.Instructions.AddRange(StaticFunct.AsmCode.Instructions); //compiled automatically
				AddAsmSeparator(AsmLangApp);
			}
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding EndOfApp");
			AsmLangApp.Instructions.Add(new GOTO("EndOfApp", "EndOfApp", i18n.str(131)));
			AddAsmSeparator(AsmLangApp);

			AsmLangApp.Instructions.Add(new END(""));
			AddAsmSeparator(AsmLangApp); //final empty line

			#endregion

			return AsmLangApp;
		}

		/// <summary>
		/// Generates the header strings. It includes info about the file, pigmeo, date of compilation...
		/// </summary>
		private static void BuildAsmHeader(AssemblyDefinition assembly) {
			AsmHeader = new Asm();
			AsmHeader.Instructions.Add(new Label("", " ========================================================================================"));
			AsmHeader.Instructions.Add(new Label("", i18n.str(132, config.Internal.AppName, config.Internal.AppVersion)));
			AsmHeader.Instructions.Add(new Label("", i18n.str(133, config.Internal.PrjWebsite)));
			AsmHeader.Instructions.Add(new Label("", " "));
			AsmHeader.Instructions.Add(new Label("", " " + config.Internal.UserApp + " => " + config.Internal.FileAsm));
			AsmHeader.Instructions.Add(new Label("", " " + String.Format("{0:F}", DateTime.Now)));
			AsmHeader.Instructions.Add(new Label("", " ========================================================================================"));
		}

		/// <summary>
		/// Generates the directives required for this file. It specifies the target branch, includes, configuration bits...
		/// </summary>
		private static void BuildAsmDirectives(AssemblyDefinition assembly) {
			AsmDirectives = new Asm();
			AsmDirectives.Instructions.Add(new INCLUDE("MODEL.INC", ""));
		}

		/// <summary>
		/// Gets all the static functions within the specified .NET assembly
		/// </summary>
		/// <remarks>
		/// If local variables of static functions are required to be compiled as static variables they will be processed at CompiledStaicFunction->AsmCode, not here
		/// </remarks>
		[PigmeoToDo("assign an address to the remaining variables")]
		private static void GetStaticVariables(AssemblyDefinition assembly) {
			//get all the static variables
			ShowInfo.InfoDebug("There are {0} static variables in {1}", assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields.Count.ToString(), config.Internal.GlobalStaticThingsFullName);
			foreach(FieldDefinition field in assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Fields) {
				ShowInfo.InfoDebug("Found new static variable: " + field.Name);
				
				RegisterAddress addr = null;
				foreach(CustomAttribute cAttr in field.CustomAttributes) {
					if(cAttr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.PIC14.Location") {
						byte bank = (byte)cAttr.ConstructorParameters[0];
						byte address = (byte)cAttr.ConstructorParameters[1];
						ShowInfo.InfoDebug("This static variable has got a fixed address: bank " + bank + ", address " + address);
						addr = new RegisterAddress(bank, address);
					}
				}
				if(addr == null) {
					ShowInfo.InfoDebug("This static variable hasn't got a fixed address, it will be choosen later");
					addr = new RegisterAddress();
				}

				StaticVariables.Add(addr, field.Name);
			}

			//assign an address to the remaining variables
			//UNINPLEMENTED

			ShowInfo.InfoDebug("Found " + StaticVariables.Count + " global/static variables");
		}

		/// <summary>
		/// Gets all the static functions found within the specified .NET assembly
		/// </summary>
		private static void GetStaticFunctions(AssemblyDefinition assembly) {
			foreach(MethodDefinition method in assembly.MainModule.Types[config.Internal.GlobalStaticThingsFullName].Methods) {
				if(!IsAlreadyCompiledStaticFunct(method)) {
					StaticFunctions.Add(new CompiledStaticFunction(method));
				}
			}
		}

		/// <summary>
		/// Checks if the specified method in already within the StaticFunctions list
		/// </summary>
		private static bool IsAlreadyCompiledStaticFunct(MethodDefinition method) {
			bool result = false;
			foreach(CompiledStaticFunction funct in StaticFunctions) {
				if(funct.OriginalMethod == method) result = true;
			}
			return result;
		}

		/// <summary>
		/// Adds and empty line at the end of the specified Asm code
		/// </summary>
		/// <param name="asm"></param>
		private static void AddAsmSeparator(Asm asm) {
			asm.Instructions.Add(new Label("", ""));
		}
	}
}
