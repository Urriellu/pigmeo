using System;
using System.Collections.Generic;

namespace Pigmeo.Internal
{
	public class i18n {
		public static string lang;

		public static Dictionary<string, Dictionary<UInt32, string>> languages = new Dictionary<string, Dictionary<uint, string>>();

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		public static string str(UInt32 ID) {
			string str="";
			if(languages.ContainsKey(lang) && languages[lang].ContainsKey(ID)) str = languages[lang][ID];
			else {
				if(languages["eng"].ContainsKey(ID)) str = languages["eng"][ID];
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		/// <param name="replacements">Strings that replace {0}, {1}, {2}... in the original string</param>
		public static string str(UInt32 ID, params string[] replacements) {
			string str = "";
			if(languages.ContainsKey(lang) && languages[lang].ContainsKey(ID)) str = string.Format(languages[lang][ID], replacements);
			else {
				if(languages["eng"].ContainsKey(ID)) str = string.Format(languages["eng"][ID], replacements);
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Static constructor. It loads all the strings
		/// </summary>
		static i18n() {
			languages.Add("eng", new Dictionary<uint, string>()); //english
			languages.Add("spa", new Dictionary<uint, string>()); //spanish

			//NOTE: if you want to change a string don't do it. Add a new one instead, reference it from wherever you want and ignore the old one
			//languages["eng"].Add(, "");
			languages["eng"].Add(0, "hello world");
			languages["eng"].Add(1, "File");
			languages["eng"].Add(2, "Open");
			languages["eng"].Add(3, "Exit");
			languages["eng"].Add(4, "About {0}");
			languages["eng"].Add(5, "About");
			languages["eng"].Add(6, "Help");
			languages["eng"].Add(7, "This application takes a .NET executable and converts it to assembly language for microcontrollers or embedded systems.");
			languages["eng"].Add(8, "Developers:");
			languages["eng"].Add(9, "For more information, visit the project website");
			languages["eng"].Add(10, "Running WinForms user interface");
			languages["eng"].Add(11, "Compilation finished successfully");
			languages["eng"].Add(12, "Error");
			languages["eng"].Add(13, "This functionality hasn't been implemented yet");
			languages["eng"].Add(14, "Go to website");
			languages["eng"].Add(15, ".NET executable file being compiled:");
			languages["eng"].Add(16, "Path to the bundled .exe:");
			languages["eng"].Add(17, "This file contains a modified version of the original executable file, but with a different hierarchy, ready for being converted to assembly language");
			languages["eng"].Add(18, "Assembly language file:");
			languages["eng"].Add(19, "This is the file where the generated assembly language will be written to");
			languages["eng"].Add(20, "View");
			languages["eng"].Add(21, "Compilation");
			languages["eng"].Add(22, "Compiler settings");
			languages["eng"].Add(23, "Compilation settings");
			languages["eng"].Add(24, "Compile");
			languages["eng"].Add(25, "Clear");
			languages["eng"].Add(26, "Warning");
			languages["eng"].Add(27, "Error");
			languages["eng"].Add(28, ". Extra info: {0}");
			languages["eng"].Add(29, "    See http://pigmeo.org/InfoError.php?id={0}");
			languages["eng"].Add(30, "Trying to throw error/warning {0}");
			languages["eng"].Add(31, "Unknown exception");
			languages["eng"].Add(32, "Unknown error or warning");
			languages["eng"].Add(33, "Unimplemented");
			languages["eng"].Add(34, "System.Windows.Forms libraries not available. Switching to console-based interface");
			languages["eng"].Add(35, "Invalid compilation progress value. Min=0, Max=100");
			languages["eng"].Add(36, "You are using an old config file version");
			languages["eng"].Add(37, "Found unknown optimization in the config file. It will be ignored");
			languages["eng"].Add(38, "Unknown version of config file");
			languages["eng"].Add(39, "XML node \"PigmeoCompilerConfig\" not found");
			languages["eng"].Add(40, "Unsupported config file version");
			languages["eng"].Add(41, "Required XML Node not found in the config file");
			languages["eng"].Add(42, "Wrong XML syntax or structure");
			languages["eng"].Add(43, "Invalid resource in the XML node \"ResourceFiles\"");
			languages["eng"].Add(44, "File not found");
			languages["eng"].Add(45, "Unable to load assembly");
			languages["eng"].Add(46, "Exception thrown by MonoMerge");
			languages["eng"].Add(47, "Unable to find the device library");
			languages["eng"].Add(48, "The assembly doesn't contain a path to a device library");
			languages["eng"].Add(49, "Unable to find a field definition within any of the referenced assemblies");
			languages["eng"].Add(50, "Unknown CIL OpCode");
			languages["eng"].Add(51, "Unsupported target architecture");
			languages["eng"].Add(52, "Language strings loaded");
			languages["eng"].Add(53, "These settings only affect the compiler itself, not the current file being compiled");
			languages["eng"].Add(54, "Bundle strings");
			languages["eng"].Add(55, "Assembly name:");
			languages["eng"].Add(56, "Main module name:");
			languages["eng"].Add(57, "Global namespace name:");
			languages["eng"].Add(58, "Global static things name:");
			languages["eng"].Add(59, "Default");
			languages["eng"].Add(60, "Generated assembly language file");
			languages["eng"].Add(61, "Line ending style");
			languages["eng"].Add(62, "Numeral system");
			languages["eng"].Add(63, "Binary");
			languages["eng"].Add(64, "Decimal");
			languages["eng"].Add(65, "Hexadecimal");
			languages["eng"].Add(66, "Octal");
			languages["eng"].Add(67, "Add comments exlaining where the code comes from (useful for debugging assembly language code)");
			languages["eng"].Add(68, "Path to the error file:");
			languages["eng"].Add(69, "Path to the symbol table file:");
			languages["eng"].Add(70, "Path to the summary file");
			languages["eng"].Add(71, "Select destination for the error file");
			languages["eng"].Add(72, "Error files (*.err)|*.err|All files (*.*)|*.*");
			languages["eng"].Add(73, "Select destination for the symbol table file");
			languages["eng"].Add(74, "Symbol table files (*.sym)|*.sym|All files (*.*)|*.*");
			languages["eng"].Add(75, "Select destination for the summary file");
			languages["eng"].Add(76, "Text files (*.txt)|*.sym|All files (*.*)|*.*");
			languages["eng"].Add(77, "Generate error file");
			languages["eng"].Add(78, "Generate symbol table file");
			languages["eng"].Add(79, "Generate summary file");
			languages["eng"].Add(80, "Save generated assembly language code to file");
			languages["eng"].Add(81, "Verbosity");
			languages["eng"].Add(82, "Quiet");
			languages["eng"].Add(83, "Verbose");
			languages["eng"].Add(84, "Debug (includes verbose)");



			languages["spa"].Add(0, "hola mundo");
			languages["spa"].Add(1, "Archivo");
			languages["spa"].Add(2, "Abrir");
			//...
			languages["spa"].Add(55, "Nombre del ensamblado (assembly):");
			languages["spa"].Add(56, "Nombre del módulo principal del ensamblado:");
			//...
			languages["spa"].Add(59, "Predeterminado");
		}
	}
}
