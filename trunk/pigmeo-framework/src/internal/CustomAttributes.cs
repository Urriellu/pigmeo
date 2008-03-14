using System;
using Pigmeo;

namespace Pigmeo.Internal {
	// NOTE: these attributes are used internally (by the libraries of devices, compiler, debugger...). You won't find here attributes used by final users in their apps, such as [Inline]

	/// <summary>
	/// This attribute must be inserted into all the device libraries, such as PIC16F716.cs/dll, so when loading it the compiler and debugger can recognize it as a device library
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class DeviceLibrary:Attribute {
		public readonly Architecture arch;
		public readonly Branch branch;

        public DeviceLibrary(Architecture arch, Branch branch) {
			this.arch = arch;
			this.branch = branch;
        }
	}

	/// <summary>
	/// This attribute is added to all bundled assemblies and specifies the path where the device library is located, so the compiler and debugger can load it easily and retrieve all the information of the target device from it
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
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
	}


	[AttributeUsage(AttributeTargets.Method)]
	public class InternalImpl:Attribute {
		public InternalImpl() { }
	}

	/// <summary>
	/// The following method hasn't been implemented yet
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class Unimplemented:Attribute {
		public Unimplemented() { }
	}
}
