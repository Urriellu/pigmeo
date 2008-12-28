using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// Contains various enable and flag bits for the TMR0 register overflow, RB Port change and external RB0/INT pin interrupts
		/// </summary>
		public static class INTCON {
			/// <summary>
			/// Global Interrupt Enable bit. true = Enables all unmasked interrupts. false = Disables all interrupts
			/// </summary>
			[AsmName("GIE"), Location(true)]
			public volatile static bool GIE = false;

			/// <summary>
			/// Peripheral Interrupt Enable bit. true = Enables all unmasked peripheral interrupts. false = Disables all peripheral interrupts
			/// </summary>
			[AsmName("PEIE"), Location(true)]
			public volatile static bool PEIE = false;

			/// <summary>
			/// Timer0 Overflow Interrupt Enable bit. true = Enables the Timer0 interrupt. false = Disables the Timer0 interrupt
			/// </summary>
			[AsmName("T0IE"), Location(true)]
			public volatile static bool T0IE = false;

			/// <summary>
			/// RB0/INT External Interrupt Enable bit. true = Enables the RB0/INT external interrupt. false = Disables the Timer0 interrupt
			/// </summary>
			[AsmName("T0IE"), Location(true)]
			public volatile static bool INTE = false;

			/// <summary>
			/// PORTB Change Interrupt Enable bit. true = Enables the PORTB change interrupt. false = Disables the PORTB change interrupt
			/// </summary>
			/// <remarks>
			/// IOCB register must also be enabled
			/// </remarks>
			[AsmName("RBIE"), Location(true)]
			public volatile static bool RBIE = false;

			/// <summary>
			/// Timer0 Overflow Interrupt Flag bit. true = TMR0 register has overflowed. false = TMR0 register did not overflow
			/// </summary>
			/// <remarks>
			/// T0IF bit is set when Timer0 rolls over. Timer0 is unchanged on Reset and should be initialized before clearing T0IF bit
			/// </remarks>
			[AsmName("RBIE"), Location(true)]
			public volatile static bool T0IF = false;

			/// <summary>
			/// RB0/INT External Interrupt Flag bit. true = The RB0/INT external interrupt occurred. false = The RB0/INT external interrupt did not occur
			/// </summary>
			[AsmName("INTF"), Location(true)]
			public volatile static bool INTF = false;

			/// <summary>
			/// PORTB Change Interrupt Flag bit. true = When at least one of the PORTB general purpose I/O pins changed state. false = None of the PORTB general purpose I/O pins have changed state
			/// </summary>
			[AsmName("RBIF"), Location(true)]
			public volatile static bool RBIF = false;
		}
	}
}