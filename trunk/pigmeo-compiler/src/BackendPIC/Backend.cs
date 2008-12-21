using System;
using Mono.Cecil;
using System.Collections.Generic;
using Pigmeo;
using Pigmeo.Compiler.PIR.PIC;
using Pigmeo.Compiler.UI;
using Pigmeo.Internal;
using Pigmeo.Extensions;

namespace Pigmeo.Compiler.BackendPIC {
	/// <summary>
	/// Converts a .NET assembly to assembly language for a 8-bit Microchip PIC microcontroller
	/// </summary>
	public class Backend {
		protected static UInt16 TitleLength = 76;
		protected static char TitleChar = '=';

		protected static string GenerateTitleComment() {
			return new string(TitleChar, TitleLength);
		}

		protected static string GenerateTitleComment(string title) {
			return new string(TitleChar, TitleLength / 2 - title.Length / 2 - 1) + " " + title + " " + new string(TitleChar, TitleLength / 2 - title.Length / 2 - 1);
		}

		/// <summary>
		/// Runs the PIC Backend
		/// </summary>
		/// <returns>
		/// Compiled source code in assembly language. One line per index
		/// </returns>
		public static string[] Run(Program UserProgram) {
			ShowInfo.InfoDebug("Running the PIC Backend");

			OptimizeProgram(UserProgram);
			AsmCode UserProgamCode = ConvertToAsm(UserProgram);
			OptimizeAsmCode(UserProgamCode);

			return UserProgamCode.Code;
		}

		/// <summary>
		/// Optimizes the PIR for the PIC Architecture
		/// </summary>
		/// NOTE FOR DEVELOPERS: do NOT change the order these optimizations are done or the compilation won't work properly
		protected static void OptimizeProgram(Program UserProgram) {
			ShowInfo.InfoDebug("Optimizing the program {0}", UserProgram.Name);

			#region optimizations that don't have influence on other optimizations
			//optimizations here
			#endregion

			#region optimizations that DO have influence on other optimizations
			bool KeepOptimizing = true;
			while(KeepOptimizing) {
				KeepOptimizing = false;
				//optimizations here
			}
			#endregion

			UserProgram.AssignLocations();
			UserProgram.MakeOperationsUseW();
		}

		/// <summary>
		/// Generates the source code in assembly language from a given PIR Program
		/// </summary>
		/// <remarks>
		/// This method converts everything in the program to asm. All the optimizations and modifications to the PIR Program must be made BEFORE calling this method
		/// </remarks>
		/// <param name="UserProgram">PIR Program being converted to asm</param>
		protected static AsmCode ConvertToAsm(Program UserProgram) {
			ShowInfo.InfoDebug("Converting \"{0}\" to assembly language", UserProgram.Name);
			AsmCode Code = new AsmCode();

			Code.Add(GenerateHeader(UserProgram)); Code.Add(new Label("", "")); Code.Add(new Label("", ""));
			Code.Add(GenerateDirectives(UserProgram)); Code.Add(new Label("", "")); Code.Add(new Label("", ""));
			Code.Add(GenerateStaticVarsCode(UserProgram)); Code.Add(new Label("", "")); Code.Add(new Label("", ""));
			Code.Add(GenerateMethodsCode(UserProgram)); Code.Add(new Label("", "")); Code.Add(new Label("", ""));
			Code.Add(GenerateEndOfAppCode(UserProgram));

			return Code;
		}

		protected static AsmCode GenerateHeader(Program UserProgram) {
			ShowInfo.InfoDebug("Generating the header comments for the assembly file");
			AsmCode Code = new AsmCode();

			Code.Add(new Label("", GenerateTitleComment()));
			Code.Add(new Label("", i18n.str("AsmLangFileGenBy", SharedSettings.AppVersion)));
			Code.Add(new Label("", i18n.str("VisitMoreInfo", SharedSettings.PrjWebsite)));
			Code.Add(new Label("", ""));
			Code.Add(new Label("", i18n.str("OrigFile", config.Internal.UserApp)));
			Code.Add(new Label("", i18n.str("SavedTo", config.Internal.FileAsm)));
			Code.Add(new Label("", String.Format("{0:F}", DateTime.Now)));
			Code.Add(new Label("", GenerateTitleComment()));

			return Code;
		}

		protected static AsmCode GenerateDirectives(Program UserProgram) {
			ShowInfo.InfoDebug("Generating the directives");
			AsmCode Code = new AsmCode();

			Code.Add(new PROCESSOR(UserProgram.Target.Branch.ToString(), ""));
			Code.Add(new INCLUDE(UserProgram.Target.IncludeFile, ""));
			Code.Add(new ERRORLEVEL("-302", "Disable warning \"Operand not in bank 0, check to ensure bank bits are correct\""));

			return Code;
		}

		protected static AsmCode GenerateStaticVarsCode(Program UserProgram) {
			ShowInfo.InfoDebug("Retrieving and declaring static fields");
			AsmCode Code = new AsmCode();

			Code.Add(new Label("", GenerateTitleComment("Static variables")));
			foreach(PIR.Type t in UserProgram.Types) {
				foreach(Field f in t.Fields) {
					if(f.IsStatic) {
						if(f.Location.DefinedInHeader) Code.Add(new Label("", i18n.str("StatFldDefIn", f.AsmName, UserProgram.Target.IncludeFile)));
						else {
							if(f.Location.Address.Undefined) ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0002", false, "Location of static field "+f.FullName+" undefined");
							Code.Add(new EQU(f.AsmName, UInt16Extensions.ToAsmString(f.Location.Address.FullAddress, Architecture.PIC), ""));
							if(f.Location.IncludeBit) Code.Add(new EQU(f.AsmName + "_bit", uint8Extensions.ToAsmString(f.Location.Address.Bit, Architecture.PIC), ""));
						}
					}
				}
			}
			Code.Add(new Label("", GenerateTitleComment()));

			return Code;
		}


		protected static AsmCode GenerateMethodsCode(Program UserProgram) {
			ShowInfo.InfoDebug("Adding EntryPoint and interrupts");
			AsmCode Code = new AsmCode();

			Code.Add(new Label("", GenerateTitleComment("Initial declarations")));
			Code.Add(new ORG(uint8Extensions.ToAsmString(0, UserProgram.Target.Architecture), "")); // ((byte)0).ToAsmString(UserProgram.Target.Architecture), ""   - doesn't work due to a mono bug
			Code.Add(new GOTO("", UserProgram.EntryPoint.AsmName, ""));
			Code.Add(new ORG(uint8Extensions.ToAsmString(4, UserProgram.Target.Architecture), "")); // ((byte)4).ToAsmString(UserProgram.Target.Architecture), "interruption vector"   - doesn't work due to a mono bug
			Code.Add(new GOTO("", "EndOfApp", "Interruptions not implemented"));
			Code.Add(new Label("", GenerateTitleComment()));

			Code.Add(new Label("", "")); Code.Add(new Label("", ""));

			foreach(PIR.Type t in UserProgram.Types) {
				foreach(Method m in t.Methods) {
					Code.Add(new Label("", GenerateTitleComment("Method \"" + m.AsmName + "\"")));
					Code.Add(GetCodeFromPirMethod(m));
					Code.Add(new Label("", GenerateTitleComment()));
				}
			}

			return Code;
		}

		protected static AsmCode GetCodeFromPirMethod(Method M) {
			ShowInfo.InfoDebug("Converting method \"{0}\" to PIC assembly language source code", M.FullName);
			AsmCode Code = new AsmCode();

			Code.Add(new Label("", "Original name: UNKNOWN (UNIMPLEMENTED)"));
			Code.Add(new Label("", "Software stack size: UNKNOWN (UNIMPLEMENTED)"));
			Code.Add(new Label("", "Parameters: UNKNOWN (UNIMPLEMENTED)"));
			Code.Add(new Label("", "Operations: " + M.Operations.Count));
			Code.Add(new Label("", "Return type: " + M.ReturnType.Name));
			Code.Add(new Label("", ""));
			Code.Add(new Label(M.AsmName, ""));
			foreach(PIR.Operation O in M.Operations) {
				Code.Add(PirOperationToAsm.GetCodeFromOperation(O));
			}

			return Code;
		}

		protected static AsmCode GenerateEndOfAppCode(Program UserProgram) {
			ShowInfo.InfoDebug("Generating the EndOfApp code");
			AsmCode Code = new AsmCode();

			Code.Add(new Label("", GenerateTitleComment("End Of Application. Style: " + config.Compilation.EndOfApp.ToString())));
			switch(config.Compilation.EndOfApp) {
				case EndsOfApp.InfiniteLoop:
					Code.Add(new GOTO("EndOfApp", "EndOfApp", ""));
					break;
				case EndsOfApp.RestartProgram:
					Code.Add(new GOTO("", UserProgram.EntryPoint.AsmName, ""));
					break;
				default:
					ErrorsAndWarnings.Throw(ErrorsAndWarnings.errType.Error, "INT0003", false, "EndOfApp: " + config.Compilation.EndOfApp.ToString());
					break;
			}
			Code.Add(new Label("", ""));
			Code.Add(new END(""));
			Code.Add(new Label("", GenerateTitleComment()));

			return Code;
		}

		/// <summary>
		/// Optimizes the assembly-language source code
		/// </summary>
		protected static void OptimizeAsmCode(AsmCode Code) {
			Code.DelRedundantBanksels();
		}
	}
}
