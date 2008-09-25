using System;
using Pigmeo;
using Mono.Cecil;
using System.Reflection;

namespace Pigmeo.Internal {
	// NOTE: these attributes are used internally (by the libraries of devices, compiler, debugger...). You won't find here attributes used by final users in their apps, such as [Inline]

	/// <summary>
	/// This attribute must be inserted into all the device libraries, such as PIC16F716.cs/dll, so when loading it the compiler and debugger can recognize it as a device library
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class DeviceLibrary:Attribute {
		public readonly Architecture arch;
		public readonly Family family;
		public readonly Branch branch;

        public DeviceLibrary(Architecture arch, Family family, Branch branch) {
			this.arch = arch;
			this.family = family;
			this.branch = branch;
        }
	}

	/// <summary>
	/// This attribute is added to all bundled assemblies and specifies the path where the device library is located, so the compiler and debugger can load it easily and retrieve all the information of the target device from it
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly), Obsolete("We now use Pigmeo.Internal.Reflection and PIR instead of a CIL bundle")]
	public class DeviceTarget:Attribute {
		public readonly Architecture arch;
		public readonly Branch branch;
		public readonly string path;

		/// <summary>
		/// Represents an assembly to be compiled for the specified architecture and branch
		/// </summary>
		/// <param name="arch">Target architecture</param>
		/// <param name="branch">Target branch</param>
		/// <param name="path">Path to the device library which contains all the informacion about the target device</param>
		public DeviceTarget(Architecture arch, Branch branch, string path) {
			this.arch = arch;
			this.branch = branch;
			this.path = path;
		}

        /// <summary>
        /// Represents an assembly to be compiled for the specified architecture and branch
        /// </summary>
        /// <param name="arch">Target architecture</param>
        /// <param name="branch">Target branch</param>
        /// <param name="path">Path to the device library which contains all the informacion about the target device</param>
        public DeviceTarget(string arch, string branch, string path) {
            this.arch = (Architecture)System.Enum.Parse(typeof(Architecture), arch);
            this.branch = (Branch)System.Enum.Parse(typeof(Branch), branch);
            this.path = path;
        }

		/// <summary>
		/// Returns a new DeviceTarget instance from a given AssemblyDefinition
		/// </summary>
		/// <param name="AssemblyToRead">Assembly which is being parsed to create the DeviceTarget object</param>
		/// <returns>DeviceTarget instance containing basic information about the given assembly</returns>
		public static DeviceTarget GetDeviceTarget(AssemblyDefinition AssemblyToRead) {
			Architecture arch = Architecture.Unknown;
			Branch branch = Branch.Unknown;
			string path = "";
			foreach(CustomAttribute attr in AssemblyToRead.CustomAttributes) {
				attr.Resolve();
				if(attr.Constructor.DeclaringType.FullName == "Pigmeo.Internal.DeviceTarget") {
					arch = (Architecture)System.Enum.Parse(typeof(Architecture), (string)attr.ConstructorParameters[0]);
					branch = (Branch)System.Enum.Parse(typeof(Branch), (string)attr.ConstructorParameters[1]);
					path = (string)attr.ConstructorParameters[2];
				}
			}
			return new DeviceTarget(arch, branch, path);
		}

		/// <summary>
		/// Gets a InfoDevice object based on the information stored in this DeviceTarget object
		/// </summary>
		/// <returns></returns>
		public InfoDevice GetDeviceInfo() {
			InfoDevice NewInfDev = null;
			Assembly ass = Assembly.LoadFile(path);
			MethodInfo InfoMethod = (ass.GetModules().GetValue(0) as Module).GetType("Pigmeo.MCU.Info").GetMethod("GetInfo");
			if(InfoMethod == null) throw new Exception(string.Format("The assembly {0} doesn't seem to be a Device Library (it doesn't contain Pigmeo.MCU.Info.GetInfo() method)"));

			switch(arch) {
				case Architecture.PIC:
					NewInfDev = InfoMethod.Invoke(null, null) as InfoPIC;
					break;
				default:
					throw new Exception("Unsupported architecture");
			}

			return NewInfDev;
		}
	}


	[AttributeUsage(AttributeTargets.Method)]
	public class InternalImpl:Attribute {
		public InternalImpl() { }
	}

	/// <summary>
	/// The following method needs work on it. It should be rewritten or modified. Read PigmeoToDo.reason for more information
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class PigmeoToDo:Attribute {
		public readonly string reason;

		public PigmeoToDo(string reason) {
			this.reason = reason;
		}
	}
}
