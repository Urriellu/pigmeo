using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pigmeo.Internal {
	public class i18n {
		/// <summary>
		/// Gets or sets the current language
		/// </summary>
		public static string CurrentLanguage {
			get {
				if(_CurrentLanguage == null) _CurrentLanguage = "en";
				return _CurrentLanguage;
			}
			set {
				if(languages.ContainsKey(value)) _CurrentLanguage = value;
				else throw new Exception("Unknown language: " + value);
			}
		}
		private static string _CurrentLanguage;

		public static List<string> AvailableLanguages {
			get {
				List<string> list = new List<string>(languages.Count);
				foreach(string key in languages.Keys) {
					list.Add(key);
				}
				return list;
			}
		}

		public static string GetLangFromNativeName(string NativeName) {
			string TwoLetterName = "";
			foreach(CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
				if(culture.NativeName == NativeName) TwoLetterName = culture.TwoLetterISOLanguageName;
			}
			return TwoLetterName;
		}

		private static Dictionary<string, Dictionary<UInt32, string>> languages = new Dictionary<string, Dictionary<uint, string>>();

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		public static string str(UInt32 ID) {
			string str="";
			if(languages.ContainsKey(CurrentLanguage) && languages[CurrentLanguage].ContainsKey(ID)) str = languages[CurrentLanguage][ID];
			else {
				if(languages["en"].ContainsKey(ID)) str = languages["en"][ID];
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Gets a string written in the current configured language. If it hasn't been translated yet it will be returned in english
		/// </summary>
		/// <param name="ID">The identification of the string</param>
		/// <param name="replacements">Strings that replace {0}, {1}, {2}... in the original string</param>
		public static string str(UInt32 ID, params object[] replacements) {
			string str = "";
			if(languages.ContainsKey(CurrentLanguage) && languages[CurrentLanguage].ContainsKey(ID)) str = string.Format(languages[CurrentLanguage][ID], replacements);
			else {
				if(languages["en"].ContainsKey(ID)) str = string.Format(languages["en"][ID], replacements);
				else throw new Exception("Unknown i18n ID: " + ID.ToString());
			}
			return str;
		}

		/// <summary>
		/// Static constructor. It loads all the strings
		/// </summary>
		static i18n() {
			languages.Add("en", new Dictionary<uint, string>()); //english
			languages.Add("es", new Dictionary<uint, string>()); //spanish
				
			//NOTE: if you want to change a string don't do it. Add a new one instead, reference it from wherever you want and ignore the old one
			languages["en"].Add(0, "hello world");
			languages["en"].Add(1, "File");
			languages["en"].Add(2, "Open");
			languages["en"].Add(3, "Exit");
			languages["en"].Add(4, "About {0}");
			languages["en"].Add(5, "About");
			languages["en"].Add(6, "Help");
			languages["en"].Add(7, "This application takes a .NET executable and converts it to assembly language for microcontrollers or embedded systems.");
			languages["en"].Add(8, "Developers:");
			languages["en"].Add(9, "For more information, visit the project website");
			languages["en"].Add(10, "Running WinForms user interface");
			languages["en"].Add(11, "Compilation finished successfully");
			languages["en"].Add(12, "Error");
			languages["en"].Add(13, "This feature hasn't been implemented yet");
			languages["en"].Add(14, "Go to website");
			languages["en"].Add(15, ".NET executable file being compiled:");
			languages["en"].Add(16, "Path to the bundled .exe:");
			languages["en"].Add(17, "This file contains a modified version of the original executable file, but with a different hierarchy, ready for being converted to assembly language");
			languages["en"].Add(18, "Assembly language file:");
			languages["en"].Add(19, "This is the file where the generated assembly language will be written to");
			languages["en"].Add(20, "View");
			languages["en"].Add(21, "Compilation");
			languages["en"].Add(22, "Compiler settings");
			languages["en"].Add(23, "Compilation settings");
			languages["en"].Add(24, "Compile");
			languages["en"].Add(25, "Clear");
			languages["en"].Add(26, "Warning");
			languages["en"].Add(27, "Error");
			languages["en"].Add(28, ". Extra info: {0}");
			languages["en"].Add(29, "    See http://pigmeo.org/InfoError.php?id={0}");
			languages["en"].Add(30, "Trying to throw error/warning {0}");
			languages["en"].Add(31, "Unknown exception");
			languages["en"].Add(32, "Unknown error or warning");
			languages["en"].Add(33, "Unimplemented");
			languages["en"].Add(34, "System.Windows.Forms libraries not available. Switching to console-based interface");
			languages["en"].Add(35, "Invalid compilation progress value. Min=0, Max=100");
			languages["en"].Add(36, "You are using an old config file version");
			languages["en"].Add(37, "Found an unknown optimization in the compilation config file. It will be ignored");
			languages["en"].Add(38, "Unknown version of compilation config file");
			languages["en"].Add(39, "XML node \"PigmeoCompilerConfig\" not found");
			languages["en"].Add(40, "Unsupported compilation config file version");
			languages["en"].Add(41, "Required XML Node not found in the config file");
			languages["en"].Add(42, "Wrong XML syntax or structure");
			languages["en"].Add(43, "Invalid resource in the XML node \"ResourceFiles\"");
			languages["en"].Add(44, "File not found");
			languages["en"].Add(45, "Unable to load assembly");
			languages["en"].Add(46, "Exception thrown by MonoMerge");
			languages["en"].Add(47, "Unable to find the device library");
			languages["en"].Add(48, "The assembly doesn't contain a path to a device library");
			languages["en"].Add(49, "Unable to find a field definition within any of the referenced assemblies");
			languages["en"].Add(50, "Unknown CIL OpCode");
			languages["en"].Add(51, "Unsupported target architecture");
			languages["en"].Add(52, "Language strings loaded");
			languages["en"].Add(53, "These settings only affect the compiler itself, not the current file being compiled");
			languages["en"].Add(54, "Bundle strings");
			languages["en"].Add(55, "Assembly name:");
			languages["en"].Add(56, "Main module name:");
			languages["en"].Add(57, "Global namespace name:");
			languages["en"].Add(58, "Global static things name:");
			languages["en"].Add(59, "Default");
			languages["en"].Add(60, "Generated assembly language file");
			languages["en"].Add(61, "Line ending style");
			languages["en"].Add(62, "Numeral system");
			languages["en"].Add(63, "Binary");
			languages["en"].Add(64, "Decimal");
			languages["en"].Add(65, "Hexadecimal");
			languages["en"].Add(66, "Octal");
			languages["en"].Add(67, "Add comments exlaining where the code comes from (useful for debugging assembly language code)");
			languages["en"].Add(68, "Path to the error file:");
			languages["en"].Add(69, "Path to the symbol table file:");
			languages["en"].Add(70, "Path to the summary file:");
			languages["en"].Add(71, "Select destination for the error file");
			languages["en"].Add(72, "Error files (*.err)|*.err|All files (*.*)|*.*");
			languages["en"].Add(73, "Select destination for the symbol table file");
			languages["en"].Add(74, "Symbol table files (*.sym)|*.sym|All files (*.*)|*.*");
			languages["en"].Add(75, "Select destination for the summary file");
			languages["en"].Add(76, "Text files (*.txt)|*.sym|All files (*.*)|*.*");
			languages["en"].Add(77, "Generate error file");
			languages["en"].Add(78, "Generate symbol table file");
			languages["en"].Add(79, "Generate summary file");
			languages["en"].Add(80, "Save generated assembly language code to file");
			languages["en"].Add(81, "Verbosity");
			languages["en"].Add(82, "Quiet");
			languages["en"].Add(83, "Verbose");
			languages["en"].Add(84, "Debug (includes verbose)");
			languages["en"].Add(85, "Language:");
			languages["en"].Add(86, "These settings are related to the current file being compiled. They don't affect the logic of your application, and are saved in the following file.");
			languages["en"].Add(87, "Loading compilation settings from file {0}");
			languages["en"].Add(88, "Select compilation settings file");
			languages["en"].Add(89, "Configuration files (*.conf)|*.conf|All files (*.*)|*.*");
			languages["en"].Add(90, "Load");
			languages["en"].Add(91, "Save");
			languages["en"].Add(92, "Select a .NET executable to compile");
			languages["en"].Add(93, ".NET executable files (*.exe)|*.exe|All files (*.*)|*.*");
			languages["en"].Add(94, "Select a destination for the bundle");
			languages["en"].Add(95, "Compilation settings file:");
			languages["en"].Add(96, "Select a destination file for the assembly language");
			languages["en"].Add(97, "Assembly language files (*.asm)|*.asm|All files (*.*)|*.*");
			languages["en"].Add(98, "Personal notes. Write whatever you want here, it won't affect the compilation :-)");
			languages["en"].Add(99, "Personal notes:");
			languages["en"].Add(100, "Running Console-based user interface");
			languages["en"].Add(101, "Unknown parameter: {0}");
			languages["en"].Add(102, "pigmeo [options] UserApp.exe");
			languages["en"].Add(103, "\t--about\t\tShow information about {0} and exit");
			languages["en"].Add(104, "\t--debug\t\tGet much more info. Useful only for developers");
			languages["en"].Add(105, "\t-h, --help\tDisplay this help and exit");
			languages["en"].Add(106, "\t--quiet\tPrint only a few important messages");
			languages["en"].Add(107, "\t--ui VALUE, --UI VALUE\tChoose the user interface. Value can be Console or WinForms. Case insensitive");
			languages["en"].Add(108, "\t-v, --verbose\tGet more info when running the compiler");
			languages["en"].Add(109, "\t--version\tPrint the version number of {0}");
			languages["en"].Add(110, "\tSample: pigmeo MyApp.exe");
			languages["en"].Add(111, "{0}, the CIL compiler from {1} project");
			languages["en"].Add(112, "Running the PIC14 backend");
			languages["en"].Add(113, "Compiling {0} for {1} ({2})");
			languages["en"].Add(114, "Compilation status: {0}%");
			languages["en"].Add(115, "Close file");
			languages["en"].Add(116, "The file {0} has been modified. Do you want to save the changes?");
			languages["en"].Add(117, "Assembly language editor");
			languages["en"].Add(118, "Edit");
			languages["en"].Add(119, "Undo");
			languages["en"].Add(120, "Redo");
			languages["en"].Add(121, "Cut");
			languages["en"].Add(122, "Copy");
			languages["en"].Add(123, "Paste");
			languages["en"].Add(124, "Delete");
			languages["en"].Add(125, "Select all");
			languages["en"].Add(126, "Format");
			languages["en"].Add(127, "Word wrap");





			languages["es"].Add(0, "hola mundo");
			languages["es"].Add(1, "Archivo");
			languages["es"].Add(2, "Abrir");
			languages["es"].Add(3, "Salir");
			languages["es"].Add(4, "Acerca de {0}");
			languages["es"].Add(5, "Acerca de");
			languages["es"].Add(6, "Ayuda");
			languages["es"].Add(7, "Esta aplicación convierte un ejecutable de .NET a código en lenguaje ensamblador para microcontroladores o sistemas embebidos.");
			languages["es"].Add(8, "Desarrolladores:");
			languages["es"].Add(9, "Para más información, visita el sitio web del proyecto");
			languages["es"].Add(10, "Ejecutando la interfaz gráfica basada en WinForms");
			languages["es"].Add(11, "La compilación ha finalizado satisfactoriamente");
			languages["es"].Add(12, "Error");
			languages["es"].Add(13, "Esta función aún no ha sido implementada");
			languages["es"].Add(14, "Ir al sitio web");
			languages["es"].Add(15, "Archivo ejecutable de .NET compilándose:");
			languages["es"].Add(16, "Ruta al alchivo .exe empaquetado:");
			languages["es"].Add(17, "Este archivo contiene una versión modificada del ejecutable original, pero con una jerarquía diferente, listo para ser convertido a lenguaje ensamblador");
			languages["es"].Add(18, "Archivo en lenguaje ensamblador:");
			languages["es"].Add(19, "Este es el archivo donde se almacenará el código fuente generado en lenguaje ensamblador");
			languages["es"].Add(20, "Ver");
			languages["es"].Add(21, "Compilación");
			languages["es"].Add(22, "Configuración del compilador");
			languages["es"].Add(23, "Configuración de la compilación");
			languages["es"].Add(24, "Compilar");
			languages["es"].Add(25, "Limpiar");
			languages["es"].Add(26, "Aviso");
			languages["es"].Add(27, "Error");
			languages["es"].Add(28, ". Más información: {0}");
			languages["es"].Add(29, "    Ver http://pigmeo.org/InfoError.php?id={0}");
			languages["es"].Add(30, "Intentando lanzar el error o aviso {0}");
			languages["es"].Add(31, "Excepción desconocida");
			languages["es"].Add(32, "Error o aviso desconocido");
			languages["es"].Add(33, "No implementado");
			languages["es"].Add(34, "Las librerías System.Windows.Forms no están disponibles. Cambiando a interfaz solo-texto (consola)");
			languages["es"].Add(35, "Valor de progreso de compilación no válido. Mínimo=0, Máximo=100");
			languages["es"].Add(36, "Versión del archivo de configuración obsoleta");
			languages["es"].Add(37, "Se encontró una optimización desconocida en el archivo de configuración de la compilación. Esta optimización será ignorada");
			languages["es"].Add(38, "Versión del archivo de configuración de compilación desconocida");
			languages["es"].Add(39, "El nodo XML \"PigmeoCompilerConfig\" no fue localizado");
			languages["es"].Add(40, "Versión del archivo de configuración de compilación no soportada");
			languages["es"].Add(41, "Un nodo XML necesario no fue encontrado en el archivo de configuración");
			languages["es"].Add(42, "Estructura o sintaxis XML incorrecta");
			languages["es"].Add(43, "Recurso inválido en el nodo XML \"ResourceFiles\"");
			languages["es"].Add(44, "Archivo no encontrado");
			languages["es"].Add(45, "No pudo cargarse el archivo ensamblado de .NET (assembly)");
			languages["es"].Add(46, "Excepción lanzada por MonoMerge");
			languages["es"].Add(47, "No pudo localizarse la librería de dispositivo");
			languages["es"].Add(48, "El ensamblado de .NET (assembly) no contiene ningura referencia a una librería de dispositivo");
			languages["es"].Add(49, "No pudo localizarse la definición de un campo en ninguno de los ensamblados de .NET (assemblies) a los que se hace referencia");
			languages["es"].Add(50, "Código de operando de lenguaje intermedio de .NET (OpCode de CIL) desconocido");
			languages["es"].Add(51, "La arquitectura de destino no está soportada");
			languages["es"].Add(52, "Las cadenas de caracteres (strings) del idioma fueron cargadas");
			languages["es"].Add(53, "Estas opciones sólo afectan al compilador en sí mismo, no al archivo que esté siendo compilado");
			languages["es"].Add(54, "Cadenas de caracteres (strings) del ejecutable empaquetado (bundle)");
			languages["es"].Add(55, "Nombre del ensamblado (assembly):");
			languages["es"].Add(56, "Nombre del módulo principal del ensamblado:");
			languages["es"].Add(57, "Nombre del namespace global:");
			languages["es"].Add(58, "Nombre para las cosas estáticas globales:");
			languages["es"].Add(59, "Predeterminado");
			languages["es"].Add(60, "Archivo generado en lenguaje ensamblador");
			languages["es"].Add(61, "Estilo de fin de línea");
			languages["es"].Add(62, "Sistema numérico");
			languages["es"].Add(63, "Binario");
			languages["es"].Add(64, "Decimal");
			languages["es"].Add(65, "Hexadecimal");
			languages["es"].Add(66, "Octal");
			languages["es"].Add(67, "Añadir comentarios explicando de dónde viene el código (útil para depurar el código generado en lenguaje ensamblador)");
			languages["es"].Add(68, "Ruta al archivo de errores:");
			languages["es"].Add(69, "Ruta al archivo de tabla de símbolos:");
			languages["es"].Add(70, "Ruta al archivo de resumen:");
			languages["es"].Add(71, "Elegir destino para el archivo de errores");
			languages["es"].Add(72, "Archivos de error (*.err)|*.err|Todos los archivos (*.*)|*.*");
			languages["es"].Add(73, "Elegir destino para el archivo de tabla de símbolos");
			languages["es"].Add(74, "Archivos de tabla de símbolos (*.sym)|*.sym|Todos los archivos (*.*)|*.*");
			languages["es"].Add(75, "Elegir destino para el archivo de resumen");
			languages["es"].Add(76, "Archivos de texto (*.txt)|*.sym|Todos los archivos (*.*)|*.*");
			languages["es"].Add(77, "Generar archivo de error");
			languages["es"].Add(78, "Generar archivo de tabla de símbolos");
			languages["es"].Add(79, "Generar archivo de resumen");
			languages["es"].Add(80, "Guardar en disco el código fuente generado en lenguaje ensamblador");
			languages["es"].Add(81, "Cantidad de mensajes mostrados");
			languages["es"].Add(82, "Silencioso");
			languages["es"].Add(83, "Detallado (\"verbose\", muestra muchos mensajes)");
			languages["es"].Add(84, "Depuración (incluye \"verbose\")");
			languages["es"].Add(85, "Idioma:");
			languages["es"].Add(86, "Estas opciones están relacionadas con el archivo que está siendo compilado actualmente. No afectan a la lógica de la aplicación. Se almacenan en el archivo siguiente.");
			languages["es"].Add(87, "Cargando opciones de configuración desde el archivo {0}");
			languages["es"].Add(88, "Elegir archivo de opciones de compilación");
			languages["es"].Add(89, "Archivos de configuración (*.conf)|*.conf|ATodos los archivos (*.*)|*.*");
			languages["es"].Add(90, "Cargar");
			languages["es"].Add(91, "Guardar");
			languages["es"].Add(92, "Elige un ejecutable de .NET para compilar");
			languages["es"].Add(93, "Archivos ejecutables de .NET (*.exe)|*.exe|Todos los archivos (*.*)|*.*");
			languages["es"].Add(94, "Elegir destino para el ejecutable empaquetado (bundle)");
			languages["es"].Add(95, "Archivo de opciones de compilación:");
			languages["es"].Add(96, "Elegir destino para el código en lenguaje ensamblador");
			languages["es"].Add(97, "Archivos de código en lenguaje ensamblador (*.asm)|*.asm|Todos los archivos (*.*)|*.*");
			languages["es"].Add(98, "Notas personales. Escribe aquí lo que quieras, no afectará a la compilación :-)");
			languages["es"].Add(99, "Notas personales:");
			languages["es"].Add(100, "Ejecutando interfaz solo-texto (consola)");
		}
	}
}
