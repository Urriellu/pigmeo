using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Contains the individual enable bits for the peripheral interrupts.
		/// </summary>
		public static class PIE1 {
			/// <summary>
			/// A/D Converter (ADC) Interrupt Enable bit. true = Enables the ADC interrupt. false = Disables the ADC interrupt
			/// </summary>
			[AsmName(""), Location(true)]
			public volatile static bool ADIE = false;

			/// <summary>
			/// CCP1 Interrupt Enable bit. true = Enables the CCP1 interrupt. false = Disables the CCP1 interrupt
			/// </summary>
			[AsmName(""), Location(true)]
			public volatile static bool CCP1IE = false;

			/// <summary>
			/// Timer2 to PR2 Match Interrupt Enable bit. true = Enables the Timer2 to PR2 match interrupt. false = Disables the Timer2 to PR2 match interrupt
			/// </summary>
			[AsmName(""), Location(true)]
			public volatile static bool TMR2IE = false;

			/// <summary>
			/// Timer1 Overflow Interrupt Enable bit. true = Enables the Timer1 overflow interrupt. false = Disables the Timer1 overflow interrupt
			/// </summary>
			[AsmName(""), Location(true)]
			public volatile static bool TMR1IE = false;
		}
	}
}