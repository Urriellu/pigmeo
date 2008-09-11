namespace Pigmeo {
	/// <summary>
	/// List of available architectures
	/// </summary>
	public enum Architecture:ushort {
		Unknown,
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
