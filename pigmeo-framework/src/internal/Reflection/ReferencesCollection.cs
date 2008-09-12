using System;
using System.Collections.Generic;
using Mono.Cecil;

namespace Pigmeo.Internal.Reflection
{
	public class ReferencesCollection
	{
		protected readonly AssemblyDefinition CclAssembly;

		public ReferencesCollection(AssemblyDefinition ReflectedAssembly) {
			this.CclAssembly = ReflectedAssembly;
		}

		/// <summary>
		/// List of referenced assemblies (only their names)
		/// </summary>
		public string[] Names {
			get {
				if(_Names == null) {
					List<string> references = new List<string>(CclAssembly.MainModule.AssemblyReferences.Count);
					foreach(AssemblyNameReference ResName in CclAssembly.MainModule.AssemblyReferences) references.Add(ResName.Name);
					_Names = references.ToArray();
				}
				return _Names;
			}
		}
		protected static string[] _Names;

		/// <summary>
		/// List of referenced assemblies (file names with extension)
		/// </summary>
		public string[] Files {
			get {
				if(_Files == null) {
					List<string> references = new List<string>(CclAssembly.MainModule.AssemblyReferences.Count);
					foreach(string Name in Names) references.Add(Name+".dll");
					_Files = references.ToArray();
				}
				return _Files;
			}
		}
		protected static string[] _Files;

		/// <summary>
		/// List of referenced assemblies with full names (includes Name, Version, Culture and PublicKeyToken)
		/// </summary>
		public string[] FullNames {
			get {
				if(_FullNames == null) {
					List<string> references = new List<string>(CclAssembly.MainModule.AssemblyReferences.Count);
					foreach(AssemblyNameReference ResName in CclAssembly.MainModule.AssemblyReferences) references.Add(ResName.FullName);
					_FullNames = references.ToArray();
				}
				return _FullNames;
			}
		}
		protected static string[] _FullNames;

		public string[] FullPaths {
			get {
				if(_FullPaths == null) {
					List<string> references = new List<string>(FullNames.Length);
					foreach(string Ref in FullNames) {
						string ResPath = "";
						try {
							ResPath = System.Reflection.Assembly.Load(Ref).Location;
						} catch {
							//the following is done because I didn't manage to load an assembly located in the working directory (if it is the same as the directory where the original assembly (UserApp) is placed), even when it is supposed to work with Assembly.Load()
							try {
								ResPath = System.Reflection.Assembly.LoadFile(Ref.Split(',')[0] + ".dll").Location;
							} catch {
								throw new ReflectionException("Assembly not found: " + Ref);
							}
						}
						references.Add(ResPath);
					}
					_FullPaths = references.ToArray();
				}
				return _FullPaths;
			}
		}
		protected string[] _FullPaths;
	}
}
