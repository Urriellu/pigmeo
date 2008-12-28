using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Holding Register for the Least Significant Byte of the 16-bit TMR1 Register
		/// </summary>
		[AsmName("TMR1L"), Location(true)]
		public volatile static byte TMR1L = 0;

		/// <summary>
		/// Holding Register for the Most Significant Byte of the 16-bit TMR1 Register
		/// </summary>
		[AsmName("TMR1H"), Location(true)]
		public volatile static byte TMR1H = 0;

		/// <summary>
		/// It's used to control Timer1 and select the various features of the Timer1 module
		/// </summary>
		public static class T1CON {
			/// <summary>
			/// Timer1 Input Clock Prescale Select bit 1
			/// </summary>
			[AsmName("T1CKPS1"), Location(true)]
			public volatile static bool T1CKPS1 = false;

			/// <summary>
			///  Timer1 Input Clock Prescale Select bit 0
			/// </summary>
			[AsmName("T1CKPS0"), Location(true)]
			public volatile static bool T1CKPS0 = false;

			/// <summary>
			/// Timer1 Oscillator Enable Control bit. true = Timer1 oscillator is enabled, false = Timer1 oscillator is disabled
			/// </summary>
			[AsmName("T1OSCEN"), Location(true)]
			public volatile static bool T1OSCEN = false;

			/// <summary>
			/// Timer1 External Clock Input Synchronization Control bit. INVERTED. If TMR1CS==false {This bit is ignored. Timer1 uses the internal clock}. If TMR1CS==true {true = Do not synchronize external clock input, false = Synchronize external clock input}
			/// </summary>
			[AsmName("NOT_T1SYNC"), Location(true)]
			public volatile static bool _T1SYNC = false;

			/// <summary>
			/// Timer1 Clock Source Select bit. true = External clock from T1CKI pin (on the rising edge). false = Internal clock (Fosc/4)
			/// </summary>
			[AsmName("TMR1CS"), Location(true)]
			public volatile static bool TMR1CS = false;

			/// <summary>
			/// Timer1 On bit. true = Enables Timer1. false = Stops Timer1
			/// </summary>
			[AsmName("TMR1ON"), Location(true)]
			public volatile static bool TMR1ON = false;
		}
	}
}