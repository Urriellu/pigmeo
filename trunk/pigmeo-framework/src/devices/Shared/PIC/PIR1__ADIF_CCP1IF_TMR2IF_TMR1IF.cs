using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Contains the individual flag bits for the peripheral interrupts
		/// </summary>
		public static class PIR1 {
			/// <summary>
			/// A/D Interrupt Flag bit. true = A/D conversion complete. false = A/D conversion has not completed or has not been started
			/// </summary>
			[AsmName("ADIF"), Location(true)]
			public volatile static bool ADIF = false;

			/// <summary>
			/// CCP1 Interrupt Flag bit. Capture Mode {true = A TMR1 register capture occurred (must be cleared in software), false = No TMR1 register capture occurred}. Compare Mode {true = A TMR1 register compare match occurred (must be cleared in software), false = No TMR1 register compare match occurred}. PWM Mode {Unused in this mode}
			/// </summary>
			[AsmName("CCP1IF"), Location(true)]
			public volatile static bool CCP1IF = false;

			/// <summary>
			/// Timer2 to PR2 Match Interrupt Flag bit. true = Timer2 to PR2 match occurred (must be cleared in software). false = Timer2 to PR2 match occurred (must be cleared in software)
			/// </summary>
			[AsmName("TMR2IF"), Location(true)]
			public volatile static bool TMR2IF = false;

			/// <summary>
			/// Timer1 Overflow Interrupt Flag bit. true = Timer1 register overflowed (must be cleared in software). false = Timer1 register overflowed (must be cleared in software)
			/// </summary>
			[AsmName("TMR1IF"), Location(true)]
			public volatile static bool TMR1IF = false;
		}
	}
}