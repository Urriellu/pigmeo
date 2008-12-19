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
