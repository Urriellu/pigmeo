using System;
using System.Collections.Generic;
using Mono.Cecil;
using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Compiler.UI;

namespace Pigmeo.Compiler {
	public class ExeReport {
		public static List<string> BuildReport(string FilePath) {
			List<string> ReportStrings = new List<string>();
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
			ReportStrings.Add(i18n.str("ModulesN", assembly.Modules.Count));
			ReportStrings.Add(i18n.str("DefTypes", assembly.MainModule.Types.Count));
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
	}
}
