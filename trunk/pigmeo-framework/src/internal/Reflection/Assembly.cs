using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Binary;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using System.IO;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Assembly (.exe or .dll)
	/// </summary>
	public partial class Assembly {
		protected readonly AssemblyDefinition CclAssembly;
		protected readonly string ReflectedFile;
		public ReferencesCollection References;

		public Assembly(string File) {
			ReflectedFile = File;
			CclAssembly = AssemblyFactory.GetAssembly(File);
			References = new ReferencesCollection(CclAssembly);
		}

		#region static methods
		/// <summary>
		/// Indicates if the given file is a valid .NET assembly or not
		/// </summary>
		/// <param name="File"></param>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">The path parameter is an empty string ("") or does not exist.</exception>
		public static bool IsAssembly(string File) {
			try {
				if(System.Reflection.Assembly.LoadFile(File).FullName != null) return true;
			} catch(BadImageFormatException e) {
				return false;
			}
			return false;
		}
		#endregion

		#region properties
		public string ReflectedFileName {
			get {
				return Path.GetFileName(ReflectedFile);
			}
		}
		#endregion
	}
}
