using Mono.Cecil;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Collections.Generic;
using Pigmeo.Compiler;

namespace Pigmeo.Compiler.BackendPIC14 {
	public static partial class CompileToAsm {
		private static Asm AsmLangApp;
		private static Asm AsmHeader;
		private static Asm AsmDirectives;
		private static List<CompiledStaticFunction> StaticFunctions;
		public static Dictionary<RegisterAddress, string> StaticVariables;
		private static Asm EndOfApp;
		public static InfoPIC8bit TargetDeviceInfo;

		/// <summary>
		/// Compiles the whole .NET assembly to assembly language
		/// </summary>
		/// <param name="assembly">.NET assembly to compile</param>
		/// <returns>The code in assembly language</returns>
		public static Asm Run(AssemblyDefinition assembly) {
			ShowInfo.InfoDebug("Compiling to 8-bit PIC assembly language");
			AsmLangApp = new Asm();
			StaticFunctions = new List<CompiledStaticFunction>();
			StaticVariables = new Dictionary<RegisterAddress, string>();
			TargetDeviceInfo = config.Compilation.TargetDeviceInfo as InfoPIC8bit;

			#region compile all the parts
			ShowInfo.InfoDebug("Building header");
			BuildAsmHeader(assembly);
			ShowInfo.InfoDebug("Building directives");
			BuildAsmDirectives(assembly);
			ShowInfo.InfoDebug("Getting static variables");
			GetStaticVariables(assembly);
			ShowInfo.InfoDebug("Getting static functions");
			GetStaticFunctions(assembly);
			ShowInfo.InfoDebug("Building end of application");
			BuildEndOfApp(assembly);
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
				AsmLangApp.Instructions.Add(new EQU(kv.Value, kv.Key.Address.ToAsmString(), ""));
			}
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding EntryPoint and interrupts");
			AsmLangApp.Instructions.Add(new ORG(((byte)0).ToAsmString(), ""));
			AsmLangApp.Instructions.Add(new GOTO("", assembly.EntryPoint.Name, ""));
			AsmLangApp.Instructions.Add(new ORG(((byte)4).ToAsmString(), "interruption vector"));
			AsmLangApp.Instructions.Add(new GOTO("", "EndOfApp", "Interruptions not implemented"));
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding static functions");
			foreach(CompiledStaticFunction StaticFunct in StaticFunctions) {
				AsmLangApp.Instructions.AddRange(StaticFunct.AsmCode.Instructions); //compiled automatically
				AddAsmSeparator(AsmLangApp);
			}
			AddAsmSeparator(AsmLangApp);

			ShowInfo.InfoDebug("Adding EndOfApp");
			AsmLangApp.Instructions.AddRange(EndOfApp.Instructions);
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
			AsmHeader.Instructions.Add(new Label("", i18n.str(139, config.Internal.UserApp)));
			AsmHeader.Instructions.Add(new Label("", i18n.str(140, config.Internal.FileAsm)));
			AsmHeader.Instructions.Add(new Label("", " " + String.Format("{0:F}", DateTime.Now)));
			AsmHeader.Instructions.Add(new Label("", " ========================================================================================"));
		}

		/// <summary>
		/// Generates the directives required for this file. It specifies the target branch, includes, configuration bits...
		/// </summary>
		private static void BuildAsmDirectives(AssemblyDefinition assembly) {
			AsmDirectives = new Asm();
			AsmDirectives.Instructions.Add(new INCLUDE(TargetDeviceInfo.IncludeFile, ""));
			AsmDirectives.Instructions.Add(new PROCESSOR(TargetDeviceInfo.branch.ToString(), ""));
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
		/// Generates the instructions executed when the application ends
		/// </summary>
		private static void BuildEndOfApp(AssemblyDefinition assembly) {
			EndOfApp = new Asm();
			switch(config.Compilation.EndOfApp) {
				case EndsOfApp.InfiniteLoop:
					EndOfApp.Instructions.Add(new GOTO("EndOfApp", "EndOfApp", i18n.str(131)));
					break;
				case EndsOfApp.RestartProgram:
					EndOfApp.Instructions.Add(new GOTO("", assembly.EntryPoint.Name, ""));
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "BE0007", false, config.Compilation.EndOfApp.ToString());
					break;
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
