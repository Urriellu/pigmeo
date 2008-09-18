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
		public ReferenceCollection References;
		//public ReferencesCollection AllReferences;

		public TypeCollection Types {
			get {
				if(_Types == null) {
					_Types = new TypeCollection(CclAssembly.MainModule.Types.Count);
					foreach(ModuleDefinition Module in CclAssembly.Modules) {
						foreach(TypeDefinition Tp in Module.Types) {
							//there is always an empty class called "<Module>". We don't want it
							if(Tp.FullName == "<Module>" && Tp.Fields.Count == 0 && Tp.Methods.Count == 0) continue;
							else _Types.Add(new Type(this, Tp));
						}
					}
				}
				return _Types;
			}
		}
		protected TypeCollection _Types;

		public Assembly(string File) {
			ShowExternalInfo.InfoDebug("Loading assembly " + File);

			ReflectedFile = File;
			CclAssembly = AssemblyFactory.GetAssembly(File);

			#region retrieve list of references
			List<AssemblyNameReference> RefList = new List<AssemblyNameReference>();
			foreach(ModuleDefinition Module in CclAssembly.Modules) {
				foreach(AssemblyNameReference ANR in Module.AssemblyReferences) {
					if(!RefList.Contains(ANR)) RefList.Add(ANR);
				}
			}
			Reference[] Refs = new Reference[RefList.Count];
			for(int i = 0 ; i < RefList.Count ; i++) {
				Refs[i] = new Reference(RefList[i]);
			}
			References = new ReferenceCollection(Refs);
			#endregion

			/*#region retrieve references recursively
			List<Reference> KnownRefs = new List<Reference>();
			KnownRefs.AddRange(References);
			foreach(Reference MyRef in References) {
				Console.WriteLine("Mi referencia (de "+KnownRefs.Count+"): "+MyRef.Name); System.Threading.Thread.Sleep(100);
				List<Reference> NewRefs = MyRef.Assembly.GetAllReferences(KnownRefs);
				Console.WriteLine(MyRef.Name+" tiene "+NewRefs.Count+" referencias"); System.Threading.Thread.Sleep(100);
				KnownRefs.AddRange(NewRefs);
			}
			AllReferences = new ReferencesCollection(KnownRefs.ToArray());
			#endregion*/


		}

		/*public List<Reference> GetAllReferences(List<Reference> Ignore) {
			List<Reference> NewRefs = new List<Reference>();
			foreach(Reference Ref in References) {
				Console.WriteLine(Ref.Name +" es referencia"); System.Threading.Thread.Sleep(100);
				//if(!Ignore.Contains(Ref)) NewRefs.Add(Ref);
				bool Contained = false;
				foreach(Reference Ignored in Ignore) {
					if(Ignored.FullName == Ref.FullName) Contained = true;
				}
				if(!Contained) {
					Console.WriteLine("Añadiendo nueva referencia: "+Ref.Name); System.Threading.Thread.Sleep(100);
					NewRefs.Add(Ref);
				}
			}
			return NewRefs;
		}*/

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
			} catch(BadImageFormatException) {
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

		/// <summary>
		/// Indicates if this .NET Assembly is a device library, it is, libraries which contains all the information about a device/microcontroller . For example PIC16F887.dll, PIC16F59.dll...
		/// </summary>
		public bool IsDeviceLibrary {
			get {
				if(!_IsDeviceLibrary.HasValue) {
					_IsDeviceLibrary = false;
					foreach(CustomAttribute attr in CclAssembly.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") _IsDeviceLibrary = true;
					}
				}
				return _IsDeviceLibrary.Value;
			}
		}
		protected bool? _IsDeviceLibrary = null;

		/// <summary>
		/// The device library this assembly references to. Device libraries (such as PIC16F877.dll) contain all the information, registers and integrated peripherals of the device/microcontroller this program is being compiled to. It returns null when no device library is referenced (so this program cannot be compiled)
		/// </summary>
		public Assembly DeviceLibrary {
			get {
				if(_DeviceLibrary == null) {
					foreach(Reference PossibleDevLib in References) {
						if(PossibleDevLib.Assembly.IsDeviceLibrary) {
							return PossibleDevLib.Assembly;
						}
					}
				}
				return _DeviceLibrary;
			}
		}
		protected Assembly _DeviceLibrary = null;

		/// <summary>
		/// If this file can be compiled, TargetArch indicates the architecture it can be compiled for. If it can't be compiled, TargetArch==Unknown
		/// </summary>
		public Architecture TargetArch {
			get {
				if(_TargetArch == null) {
					_TargetArch = Architecture.Unknown;
					foreach(CustomAttribute attr in DeviceLibrary.CclAssembly.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							_TargetArch = (Architecture)attr.ConstructorParameters[0];
						}
					}
				}
				return _TargetArch.Value;
			}
		}
		protected Architecture? _TargetArch = null;

		/// <summary>
		/// If this file can be compiled, TargetBranch indicates the branch/device/microcontroller it can be compiled for. If it can't be compiled, TargetBranch==Unknown
		/// </summary>
		public Branch TargetBranch {
			get {
				if(_TargetBranch == null) {
					_TargetBranch = Branch.Unknown;
					foreach(CustomAttribute attr in DeviceLibrary.CclAssembly.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							_TargetBranch = (Branch)attr.ConstructorParameters[1];
						}
					}
				}
				return _TargetBranch.Value;
			}
		}
		protected Branch? _TargetBranch = null;
		#endregion

		#region public methods
		public override string ToString() {
			string Output = "";
			Output += "Assembly: " + CclAssembly.Name + "\n\n";

			Output += "References: " + References.ToString() + "\n\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output.TrimEnd('\n');
		}
		#endregion
	}
}
