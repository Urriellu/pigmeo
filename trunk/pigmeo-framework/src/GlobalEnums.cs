namespace Pigmeo {
	/// <summary>
	/// List of available architectures
	/// </summary>
	public enum Architecture:ushort {
		Unknown,
		PIC10,
		PIC12,
		PIC16,
		PIC18,
		PIC24,
		dsPIC
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
}
