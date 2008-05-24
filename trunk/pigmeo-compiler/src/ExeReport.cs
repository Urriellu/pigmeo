using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	public class ExeReport {
		protected static List<string> ReportStrings;

		public static List<string> BuildReport(string FilePath) {
			ReportStrings = new List<string>();
			string FileName = System.IO.Path.GetFileName(FilePath);
			ShowInfo.InfoDebug("Retrieving information about {0}", FilePath);
			AssemblyDefinition assembly = AssemblyFactory.GetAssembly(FilePath);
			CilFrontend.AssemblyMgmt ExeInfo = new CilFrontend.AssemblyMgmt();
			Architecture TargetArch = Architecture.Unknown;
			Branch TargetBranch = Branch.Unknown;
			string DevLibPath = ExeInfo.FindDeviceLibrary(CilFrontend.ListOfReferences(FilePath, false), ref TargetArch, ref TargetBranch);
			DeviceTarget target = new DeviceTarget(TargetArch, TargetBranch, DevLibPath);
			InfoDevice InfoDev = target.GetDeviceInfo();

			ReportStrings.Add(i18n.str("InfoAbout", FileName));
			//ReportStrings.Add(i18n.str("ModulesN", assembly.Modules.Count));
			//ReportStrings.Add(i18n.str("DefTypes", assembly.MainModule.Types.Count));

			foreach(ModuleDefinition module in assembly.Modules) {
				ReportStrings.Add("     Module " + module.Name);
				foreach(TypeDefinition type in module.Types) {
					if(type.Name != "<Module>") {
						string TypeStr = "          ";
						if(type.IsPublic) TypeStr += "public ";
						else TypeStr += "private ";
						if(type.IsAbstract) TypeStr += "abstract ";
						if(type.IsSealed) TypeStr += "sealed ";
						if(type.IsClass) TypeStr += "class ";
						if(type.IsEnum) TypeStr += "enum ";
						if(type.IsInterface) TypeStr += "interface ";
						TypeStr += type.Name;
						//TypeStr += ":" + type.BaseType.Name;
						ReportStrings.Add(TypeStr);
						foreach(FieldDefinition field in type.Fields) {
							ReportStrings.Add("               " + field.FieldType.Name + " " + field.Name);
						}
						foreach(MethodDefinition method in type.Methods) {
							BuildMethodReport(method);
						}
						foreach(MethodDefinition method in type.Constructors) {
							BuildMethodReport(method);
						}
					}
				}
			}

			ReportStrings.Add("");
			ReportStrings.Add(i18n.str("TargetInfo"));
			ReportStrings.Add(i18n.str("ArchIs", target.arch));
			ReportStrings.Add(i18n.str("BranchIs", target.branch));
			switch(TargetArch) {
				case Architecture.PIC14:
					InfoPIC8bit InfoDev14 = InfoDev as InfoPIC8bit;
					ReportStrings.Add(i18n.str("MaxWords", InfoDev14.MaxWords));
					ReportStrings.Add(i18n.str("TotalRam", InfoDev14.TotalRAM));
					ReportStrings.Add(i18n.str("TotalSfr", InfoDev14.SfrSize));
					ReportStrings.Add(i18n.str("TotalGpr", InfoDev14.GprSize));
					for(int i = 0 ; i < InfoDev14.DataMemory.Length ; i++) {
						DataMemoryBankPIC bank = InfoDev14.DataMemory[i];
						ReportStrings.Add(i18n.str("MemBankN", i));
						ReportStrings.Add(i18n.str("SfrSize", bank.SfrSize));
						ReportStrings.Add(i18n.str("GprSize", bank.GprSize));
						ReportStrings.Add(i18n.str("TotalRegs", bank.Size));
					}
					break;
			}
			return ReportStrings;
		}

		protected static void BuildMethodReport(MethodDefinition method) {
			string MethodStr = "               ";
			if(method.IsAbstract) MethodStr += "abstract ";
			if(method.IsPrivate) MethodStr += "private ";
			if(method.IsPublic) MethodStr += "public ";
			if(method.IsStatic) MethodStr += "static ";
			if(method.IsVirtual) MethodStr += "virtual ";
			if(!method.IsConstructor) MethodStr += method.ReturnType.ReturnType.Name.ToLower() + " ";
			MethodStr += method.Name + "(";
			foreach(ParameterDefinition param in method.Parameters) {
				MethodStr += param.ParameterType.Name + " " + param.Name + ", ";
			}
			if(method.Parameters.Count > 0) MethodStr = MethodStr.Substring(0, MethodStr.Length - 2);
			MethodStr += ")";
			ReportStrings.Add(MethodStr);
			foreach(VariableDefinition variable in method.Body.Variables) {
				ReportStrings.Add("                    " + variable.VariableType.Name + " " + variable.Name);
			}
			if(method.Body.Variables.Count>0) ReportStrings.Add("");
			foreach(Instruction instr in method.Body.Instructions) {
				string InstrStr = "                    " + instr.OpCode.ToString();
				if(instr.Operand != null) InstrStr += " " + instr.Operand.ToString();
				ReportStrings.Add(InstrStr);
			}
		}
	}
}
