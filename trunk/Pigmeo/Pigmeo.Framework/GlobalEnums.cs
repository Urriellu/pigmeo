namespace Pigmeo {
	/// <summary>
	/// List of available architectures
	/// </summary>
	/// <remarks>
	/// Each architecture has its own backend and PIR-derived classes. Differences in instruction sets are managed by different Families
	/// </remarks>
	public enum Architecture:ushort {
		Unknown,
		/// <summary>
		/// Baseline and mid-range Microchip 8-bit microcontrollers (PIC10F, PIC12F, PIC16F...)
		/// </summary>
		PIC
	}


	public enum Family:ushort {
		Unknown,
		/// <summary>
		/// Microchip microcontrollers. 8-bit registers, 12-bit opcodes. PIC10F, some PIC12F and some PIC16F
		/// </summary>
		PIC12,
		/// <summary>
		/// Microchip microcontrollers. 8-bit registers, 14-bit opcodes. PIC12F and most PIC16F
		/// </summary>
		PIC14
	}

	/// <summary>
	/// List of available branches
	/// </summary>
	/// <remarks>
	/// This list contains the branches of ALL architectures because is easier to work in this way than having a separate list for each arch
	/// </remarks>
	public enum Branch:ushort {
		Unknown,
		PIC10F202,
		PIC16F59,
		PIC16F716,
		PIC16F887
	}

	/// <summary>
	/// Type of digital logic (positive or negative)
	/// </summary>
	public enum LogicType:ushort { Negative, Positive }

	public enum OnOffStatus:ushort { OFF, ON }

	/// <summary>
	/// Available digital values (0 and 1, or Low and High)
	/// </summary>
	public enum DigitalValue:ushort { Low, High }

	public enum DigitalIOConfig { Input, Output }

	/// <summary>
	/// Posible transitions between values in digital logic
	/// </summary>
	public enum DigitalEdge:ushort {
		/// <summary>
		/// Transtition of a digital signal from Low to High (0 to 1 or false to true)
		/// </summary>
		Rising,
		/// <summary>
		/// Transtition of a digital signal from High to Low (1 to 0 or true to false)
		/// </summary>
		Falling
	}
}
