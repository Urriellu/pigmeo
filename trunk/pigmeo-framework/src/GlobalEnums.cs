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
		PIC16F716
	}

	public enum LogicType:ushort { Negative, Positive }

	public enum OnOffStatus:ushort { OFF, ON }

	public enum DigitalValue:ushort { Low, High }

	public enum DigitalEdge:ushort { Rising, Falling }
}
