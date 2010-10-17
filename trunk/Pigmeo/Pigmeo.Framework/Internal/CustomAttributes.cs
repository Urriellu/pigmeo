using System;
using Pigmeo;
using Mono.Cecil;
using System.Reflection;

namespace Pigmeo.Internal {
	// NOTE: these attributes are used internally (by the libraries of devices, compiler, debugger...). You won't find here attributes used by final users in their apps, such as [Inline]

	/// <summary>
	/// Custom attributes which indicates that an assembly is a Device Library with all information required to support a microcontroller
	/// </summary>
	/// <remarks>
	/// This attribute must be inserted into all the device libraries, such as PIC16F716.cs/dll, so when loading it the compiler and debugger can recognize it as a device library
	/// </remarks>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class DeviceLibrary:Attribute {
		/// <summary>
		/// Target Architecture
		/// </summary>
		public readonly Architecture arch;

		/// <summary>
		/// Target Family
		/// </summary>
		public readonly Family family;

		/// <summary>
		/// Target Branch
		/// </summary>
		public readonly Branch branch;

		/// <summary>
		/// Indicates that an assembly is a Device Library with all information required to support a microcontroller
		/// </summary>
		/// <param name="arch">Target Architecture</param>
		/// <param name="family">Target Family</param>
		/// <param name="branch">Target Branch</param>
		public DeviceLibrary(Architecture arch, Family family, Branch branch) {
			this.arch = arch;
			this.family = family;
			this.branch = branch;
		}
	}

	/// <summary>
	/// Methods tagged with this attribute have got a body which is executed on managed environments, but Pigmeo Compiler will reimplement this depending on the target architecture
	/// </summary>
	/// <remarks>
	/// System.Runtime.CompilerServices.MethodImpl(MethodImplOptions.InternalCall) can't be used because we want to have both managed and internal implementations
	/// </remarks>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class InternalImplementation:Attribute {
		Architecture TargetArch;

		public InternalImplementation() {
		}

		public InternalImplementation(Architecture TargetArch) {
			this.TargetArch = TargetArch;
		}
	}

	/// <summary>
	/// The following method needs work on it. It should be rewritten or modified. Read PigmeoToDo.reason for more information
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property)]
	public class PigmeoToDo:Attribute {
		public readonly string reason;

		public PigmeoToDo(string reason) {
			this.reason = reason;
		}
	}
}
