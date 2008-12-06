using System;
using Pigmeo;

namespace Pigmeo.Internal {
	/// <summary>
	/// Contains all the required information about one device, one branch from one architecture
	/// </summary>
	/// <remarks>
	/// This information is retrieved from the library of the specified branch. For example if you want information about the PIC16F716 a InfoDevice object is instantiated as 'new InfoDevice("PIC16F716")', the library PIC16F716.dll is loaded using reflection and the information is retrieved from that library.</remarks>
	public abstract class InfoDevice {
		/// <summary>
		/// The target architecture
		/// </summary>
		public Architecture Architecture;

		/// <summary>
		/// The target family
		/// </summary>
		public Family Family;

		/// <summary>
		/// The target branch/device
		/// </summary>
		public Branch Branch;

		/// <summary>
		/// Pointer size, in bytes
		/// </summary>
		public byte PointerSize { get; protected set; }
	}
}
