namespace Pigmeo.Compiler.PIR.PIC {
	/// <summary>
	/// Represents the entire Data Memory (RAM) of a Microchip PIC
	/// </summary>
	public class DataMemory {
		protected readonly Program ParentProgram;

		/// <summary>
		/// The static memory of a PIC. This is, the portion of its Data Memory (RAM) used by static variables/fields
		/// </summary>
		public readonly StaticMemory StaticMemory;

		public DataMemory(Program ParentProgram) {
			this.ParentProgram = ParentProgram;
			StaticMemory = new StaticMemory(ParentProgram);
		}

		public float Assigned {
			get {
				return StaticMemory.Percent;
			}
		}

		public float Unassigned {
			get {
				return 100 - Assigned;
			}
		}
	}
}
