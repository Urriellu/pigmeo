using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Binary;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;
using System.IO;
using Pigmeo.Extensions;

namespace Pigmeo.Internal.Reflection {
	/// <summary>
	/// Represents a reflected .NET Assembly (.exe or .dll)
	/// </summary>
	public partial class Assembly {
		/// <summary>
		/// List of reflected assemblies already in RAM, so we don't need to load them again. The Key (<see cref="String"/>) is the path to the assembly, and the Value (<see cref="Assembly"/>) is the object which represents the reflected .NET Assembly
		/// </summary>
		public static Dictionary<string, Assembly> KnownAssemblies = new Dictionary<string, Assembly>();

		/// <summary>
		/// This assembly being reflected, as represented by Mono.Cecil
		/// </summary>
		protected readonly AssemblyDefinition OriginalAssembly;

		/// <summary>
		/// Path to the .NET Assembly being reflected
		/// </summary>
		public readonly string ReflectedFile;

		/// <summary>
		/// Cache for faster execution of GetOwnerOfType()
		/// </summary>
		protected Dictionary<string, Assembly> CacheOwnerOfType = new Dictionary<string, Assembly>();

		/// <summary>
		/// List of referenced assemblies by this one
		/// </summary>
		public ReferenceCollection References {
			get {
				if(_References == null) {
					ShowExternalInfo.InfoDebug("Retrieving References of {0}", Name);
					_References = new ReferenceCollection();
					foreach(ModuleDefinition Module in OriginalAssembly.Modules) {
						foreach(AssemblyNameReference ANR in Module.AssemblyReferences) {
							if(!_References.ContainsFullName(ANR.FullName)) _References.Add(new Reference(ANR));
						}
					}
					ShowExternalInfo.InfoDebug("References in {0}: {1}", Name, _References.Names.CommaSeparatedList());
				}
				return _References;
			}
		}
		protected ReferenceCollection _References;

		/// <summary>
		/// Types (classes) found in this .NET Assembly
		/// </summary>
		public TypeCollection Types {
			get {
				if(_Types == null) {
					_Types = new TypeCollection(OriginalAssembly.MainModule.Types.Count);
					foreach(ModuleDefinition Module in OriginalAssembly.Modules) {
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

		/// <summary>
		/// Instantiates a new object that represents a reflected .NET Assembly, given its representation by Mono.Cecil and the path to the reflected file
		/// </summary>
		/// <param name="OriginalAssembly">This assembly, as represented by Mono.Cecil</param>
		/// <param name="File">Path to the reflected file</param>
		public Assembly(AssemblyDefinition OriginalAssembly, string File) {
			this.OriginalAssembly = OriginalAssembly;
			this.ReflectedFile = File;
			KnownAssemblies.Add(FullName, this);
		}

		/// <summary>
		/// Reflects a .NET Assembly from a given file. If that file has been already loaded, it's not loaded again
		/// </summary>
		public static Assembly GetFromFile(string File) {
			ShowExternalInfo.InfoDebug("Loading assembly from file " + File);
			AssemblyDefinition CclAssembly = AssemblyFactory.GetAssembly(File);
			if(KnownAssemblies.ContainsKey(CclAssembly.Name.FullName)) {
				ShowExternalInfo.InfoDebug("Reflecting file (previously reflected) {0}", File);
				return KnownAssemblies[CclAssembly.Name.FullName];
			} else {
				ShowExternalInfo.InfoDebug("Reflecting file (NOT previously reflected) {0}", File);
				return new Assembly(CclAssembly, File);
			}
		}

		/// <summary>
		/// Reflects an assembly from its Full Name (Name, version, culture, and public key token). If that file has been already loaded, it's not loaded again
		/// </summary>
		public static Assembly GetFromFullName(string FullName) {
			ShowExternalInfo.InfoDebug("Loading assembly from its full name " + FullName);
			string FullPath = "";
			try {
				FullPath = System.Reflection.Assembly.Load(FullName).Location;
			} catch {
				//the following is done because I didn't manage to load an assembly located in the working directory (if it is the same as the directory where the original assembly (UserApp) is placed), even when it is supposed to work with Assembly.Load()
				try {
					FullPath = System.Reflection.Assembly.LoadFile(FullName.Split(',')[0] + ".dll").Location;
				} catch {
					try {
						FullPath = System.Reflection.Assembly.LoadFile(FullName.Split(',')[0] + ".exe").Location;
					} catch {
						throw new ReflectionException("Assembly not found: " + FullName);
					}
				}
			}
			return GetFromFile(FullPath);
		}

		/// <summary>
		/// Finds the assembly which contains the definition of type given its full name (including namespace). This method looks for the definition in this assembly and all of its references
		/// </summary>
		/// <remarks>
		/// This method uses a cache so we don't need to look for it again and again (which is CPU expensive)
		/// </remarks>
		public Assembly GetOwnerOfType(string TypeFullName) {
			if(!CacheOwnerOfType.ContainsKey(TypeFullName)) {
				if(Types.Contains(TypeFullName)) CacheOwnerOfType.Add(TypeFullName, this);
				else CacheOwnerOfType.Add(TypeFullName, References.GetOwnerOfType(TypeFullName));
			}
			return CacheOwnerOfType[TypeFullName];
		}

		/// <summary>
		/// Finds the object which represents a type given its full name (including namespace). This method looks for its definition in this assembly and all of its references
		/// </summary>
		/// <param name="TypeFullName">Full name of the <see cref="Type"/> being retrieved</param>
		public Type GetAType(string TypeFullName) {
			return GetOwnerOfType(TypeFullName).Types[TypeFullName];
		}

		/// <summary>
		/// Finds the object which represents a method given its full name (including namespaces and parent type). This method looks for its definition in this assembly and all of its references
		/// </summary>
		/// <param name="MethodFullName">Full name of the <see cref="Method"/> being retrieved</param>
		public Method GetAMethod(string MethodFullName) {
			int LastPoint = MethodFullName.LastIndexOf('.');
			string ParentTypeFullName = MethodFullName.Substring(0, LastPoint);
			string MethodName = MethodFullName.Substring(LastPoint + 1, MethodFullName.Length - LastPoint - 1);
			ShowExternalInfo.InfoDebug("Trying to retrieve method {0} (class: {1}, name: {2})", MethodFullName, ParentTypeFullName, MethodName);
			return GetAType(ParentTypeFullName).Methods[MethodName];
		}

		#region static methods
		/// <summary>
		/// Indicates if the given file is a valid .NET assembly or not
		/// </summary>
		/// <param name="File">Path to the file being tested</param>
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
		/// <summary>
		/// Name of this .NET Assembly
		/// </summary>
		public string Name {
			get {
				return OriginalAssembly.Name.Name;
			}
		}

		/// <summary>
		/// Full name of this .NET Assembly, including its name, version, culture and public key token
		/// </summary>
		public string FullName {
			get {
				return OriginalAssembly.Name.FullName;
			}
		}

		/// <summary>
		/// Name (not the full path) of the file being reflected
		/// </summary>
		public string ReflectedFileName {
			get {
				return Path.GetFileName(ReflectedFile);
			}
		}

		public Method EntryPoint {
			get {
				if(_EntryPoint == null) _EntryPoint = Types[OriginalAssembly.EntryPoint.DeclaringType.FullName].Methods[OriginalAssembly.EntryPoint.Name];
				return _EntryPoint;
			}
		}
		protected Method _EntryPoint;

		/// <summary>
		/// Indicates if this .NET Assembly is a device library, it is, libraries which contains all the information about a device/microcontroller . For example PIC16F887.dll, PIC16F59.dll...
		/// </summary>
		public bool IsDeviceLibrary {
			get {
				if(!_IsDeviceLibrary.HasValue) {
					_IsDeviceLibrary = false;
					foreach(CustomAttribute attr in OriginalAssembly.CustomAttributes) {
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
					foreach(CustomAttribute attr in DeviceLibrary.OriginalAssembly.CustomAttributes) {
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
		/// If this file can be compiled, TargetFamily indicates the processor family it can be compiled for. If it can't be compiled, TargetFamily==Unknown
		/// </summary>
		public Family TargetFamily {
			get {
				if(_TargetFamily == null) {
					_TargetFamily = Family.Unknown;
					foreach(CustomAttribute attr in DeviceLibrary.OriginalAssembly.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							_TargetFamily = (Family)attr.ConstructorParameters[1];
						}
					}
				}
				return _TargetFamily.Value;
			}
		}
		protected Family? _TargetFamily = null;

		/// <summary>
		/// If this file can be compiled, TargetBranch indicates the branch/device/microcontroller it can be compiled for. If it can't be compiled, TargetBranch==Unknown
		/// </summary>
		public Branch TargetBranch {
			get {
				if(_TargetBranch == null) {
					_TargetBranch = Branch.Unknown;
					foreach(CustomAttribute attr in DeviceLibrary.OriginalAssembly.CustomAttributes) {
						attr.Resolve();
						if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceLibrary") {
							_TargetBranch = (Branch)attr.ConstructorParameters[2];
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
			Output += "Assembly: " + OriginalAssembly.Name + "\n\n";
			Output += "References: " + References.ToString() + "\n\n";

			foreach(Type t in Types) Output += t.ToString() + "\n";

			return Output.TrimEnd('\n');
		}
		#endregion
	}
}
